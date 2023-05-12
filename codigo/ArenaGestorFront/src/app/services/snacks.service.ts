import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { SnackGetSnackDto } from '../models/Snacks/SnackGetSnackDto';
import { SnackDto } from '../models/Snacks/SnackDto';
import { Observable } from 'rxjs';
import { SnackInsertSnackDto } from '../models/Snacks/SnackInsertSnackDto';

@Injectable({
  providedIn: 'root'
})
export class SnacksService {

  private apiUrl: string

  constructor(private http: HttpClient) {
    this.apiUrl = environment.apiURL + "snacks"
  }

  ParamsFilters(filter?: SnackGetSnackDto): string {
    let params = "";

    if (filter) {
      if (filter.name.length > 0) {
        params = "?name=" + filter.name
      }
    }
    return params;
  }

  Get(filter: SnackGetSnackDto): Observable<Array<SnackDto>> {
    let url = this.apiUrl;

    url = url + this.ParamsFilters(filter);

    return this.http.get<Array<SnackDto>>(url)
  }

  GetById(id: Number): Observable<SnackGetSnackDto> {
    return this.http.get<SnackGetSnackDto>(this.apiUrl + "/" + id.toString())
  }

  Insert(snack: SnackInsertSnackDto): Observable<SnackDto> {
    return this.http.post<SnackDto>(this.apiUrl, snack)
  }

  Update(snack: SnackDto): Observable<SnackDto> {
    return this.http.put<SnackDto>(this.apiUrl, snack)
  }

  Delete(id: Number) {
    return this.http.delete(this.apiUrl + "/" + id.toString())
  }

  Buy(snackList: Array<SnackDto>): Observable<Array<SnackDto>>{
    return this.http.put<Array<SnackDto>>(this.apiUrl + "/cart", snackList)
  }
}
