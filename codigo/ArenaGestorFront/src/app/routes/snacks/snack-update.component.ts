import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute } from '@angular/router'
import { SnackDto } from 'src/app/models/Snacks/SnackDto';
import { SnacksService } from 'src/app/services/snacks.service';

@Component({
  templateUrl: './snack-form.component.html'
})
export class SnackUpdateComponent implements OnInit {

  mode: String = "Actualizar"
  model: SnackDto = new SnackDto();

  constructor(private toastr: ToastrService, private service: SnacksService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.service.GetById(params["id"]).subscribe(snack => {
        this.model.snackId = snack.snackId
        this.model.name = snack.name
        this.model.price = snack.price;
        this.model.quantity = snack.quantity;
      })
    })
  }

  Confirmar() {
    this.service.Update(this.model).subscribe(res => {
      console.log(this.model)
      this.toastr.success("Snack actualizado correctamente", "Éxito")
      this.router.navigate(["/administracion/snacks"])
    },
      err => {
        this.toastr.error(err.error, "Error")
      })
  }
}
