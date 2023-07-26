import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from '../models/response'

@Injectable({
  providedIn: 'root'
})
export class ApiclientService {

  //Conexión
  url = 'http://www.pruebaventasdf.somee.com/api/cliente/lista';
  // http://www.pruebaventasdf.somee.com/api/Cliente/Obtener/id

  constructor(
    private _http: HttpClient
  ) { }

  getClientes(): Observable<Response> {
    return this._http.get<Response>(this.url);
  }
}
