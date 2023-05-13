import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SnackInsertSnackDto } from 'src/app/models/Snacks/SnackInsertSnackDto';
import { SnacksService } from 'src/app/services/snacks.service';

@Component({
  templateUrl: './snack-form.component.html'
})
export class SnackInsertComponent implements OnInit {

  mode: String = "Insertar";
  model: SnackInsertSnackDto = new SnackInsertSnackDto();

  constructor(private toastr: ToastrService, private service: SnacksService, private router: Router) { }

  ngOnInit(): void {
  }

  Confirmar() {
    this.service.Insert(this.model).subscribe(res => {
      this.toastr.success("Snack agregado correctamente", "Éxito")
      this.router.navigate(["/administracion/snacks"])
    },
      err => {
        this.toastr.error(err.error, "Error")
      })
  }

}
