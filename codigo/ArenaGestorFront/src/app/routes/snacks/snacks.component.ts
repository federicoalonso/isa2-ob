import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SnackGetSnackDto } from 'src/app/models/Snacks/SnackGetSnackDto';
import { SnackDto } from 'src/app/models/Snacks/SnackDto';
import { SnacksService } from 'src/app/services/snacks.service';

@Component({
  selector: 'app-snacks',
  templateUrl: './snacks.component.html',
  styleUrls: ['./snacks.component.scss']
})
export class SnacksComponent implements OnInit {

  snacksList: Array<SnackDto> = new Array<SnackDto>()
  filter: SnackGetSnackDto = new SnackGetSnackDto()
  snackToDelete: Number = 0;

  constructor(private toastr: ToastrService, private service: SnacksService, private router: Router) { }

  ngOnInit(): void {
    this.GetData()
  }

  GetData() {
    this.service.Get(this.filter).subscribe(res => {
      this.snacksList = res
    })
  }

  SetSnackToDelete(id: Number) {
    this.snackToDelete = id;
  }

  Delete() {
    this.service.Delete(this.snackToDelete).subscribe(res => {
      this.toastr.success("Snack eliminado correctamente", "Éxito")
      this.GetData();
    },
      err => {
        this.toastr.error(err.error, "Error")
      })
  }
}
