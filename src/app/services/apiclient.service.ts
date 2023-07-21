import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiclientService {

  //Conexión
  url: string = 'https://localhost:44351/api/cliente';

  constructor(
    private _http: HttpClient
  ) { }

  getClientes(): Observable<Response> {
    return this._http.get<Response>(this.url);
  }
}