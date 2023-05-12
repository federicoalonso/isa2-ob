import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { ToastrService } from 'ngx-toastr';
import { SnackDto } from 'src/app/models/Snacks/SnackDto';
import { SnackGetSnackDto } from 'src/app/models/Snacks/SnackGetSnackDto';
import { TicketBuyTicketDto } from 'src/app/models/Tickets/TicketBuyTicketDto';
import { ConcertService } from 'src/app/services/concert.service';
import { SnacksService } from 'src/app/services/snacks.service';
import { TicketsService } from 'src/app/services/tickets.service';

@Component({
  selector: 'app-buy',
  templateUrl: './buy.component.html'
})
export class BuyComponent implements OnInit {

  selectedTourName: String = "";
  selectedId: Number = 0;
  amount : number = 0;
  subtotalSnack: number = 0;
  subtotalTour:number = 0;
  snacksList: Array<SnackDto> = new Array<SnackDto>()
  filter: SnackGetSnackDto = new SnackGetSnackDto()
  selectedSnacks: Array<SnackDto> = new Array<SnackDto>()
  total: number = 0;
  tourPrice: number = 0;

  constructor(private toastr: ToastrService, private snacksService: SnacksService, private ticketService: TicketsService, private service: ConcertService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.service.GetById(params["id"]).subscribe(concert => { 
        this.selectedTourName = concert.tourName
        this.selectedId = concert.concertId
        this.tourPrice = concert.price
      })
    })
    this.snacksService.Get(this.filter).subscribe(res => {
      this.snacksList = res
    })
  }

  Confirmar() {
    this.cleanList();
    let dto = new TicketBuyTicketDto();
    dto.Amount = this.amount;
    dto.concertId = this.selectedId;
    this.formatSnack();
    this.ticketService.Shopping(dto).subscribe(res => {
      this.snacksService.Buy(this.selectedSnacks).subscribe(r => {
        this.toastr.success("Ticket comprado con ID: " + res.ticketId + " y los snacks comprados con éxito.")
      }, error => {
        this.toastr.error("Ticket comprado con ID: " + res.ticketId + " pero los snaks no se pudieron comprar, surgió el siguiente error: " + error.error)
      })
    }, error => {
      this.toastr.error(error.error);
    })
  }

  formatSnack(){
    this.selectedSnacks.forEach(snack => {
      if(snack.snackId){
        let sn = this.snacksList.filter(obj => {return obj.snackId == snack.snackId})
        snack.name = sn[0].name
      }
    });
  }

  BorrarSnack(snackId?: number) {
    if(snackId || snackId == 0){
      this.selectedSnacks = this.selectedSnacks.filter(obj => {return obj.snackId !== snackId});
    }
    this.CalcularSubtotal();
  }

  AgregarSnack(){
    this.selectedSnacks.push(new SnackDto())
  }

  CalcularSubtotal(){
    this.subtotalSnack = 0;
    this.selectedSnacks.forEach(snack => {
      let found = false;
      for(let i=0; i < this.snacksList.length && !found; i++){
        let element = this.snacksList[i];
        if(element.snackId == snack.snackId){
          found = true;
          this.subtotalSnack += element.price * snack.quantity;
        }
      }
    });
    this.calcularTotal();
  }

  cleanList(){
    this.selectedSnacks = this.selectedSnacks.filter(snack => {
      return snack.snackId !== 0 && snack.quantity;
    });
  }

  CalcularSubtotalTour(){
    this.subtotalTour = this.amount * this.tourPrice;
    this.calcularTotal();
  }

  calcularTotal(){
    this.total = this.subtotalSnack + this.subtotalTour;
  }

  Cancelar(){
    this.router.navigate(["/home"])
  }
}
