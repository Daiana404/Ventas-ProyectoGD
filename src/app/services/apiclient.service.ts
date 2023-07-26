import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from '../models/response';
import { Cliente } from '../models/cliente';

const httpOptions = {
  headers: new HttpHeaders({
    'Contend-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ApiclientService {

  //Conexión
  url = 'http://www.pruebaventasdf.somee.com/api/cliente/lista';
  urlPost = 'http://www.pruebaventasdf.somee.com/api/cliente/nuevo';
  // http://www.pruebaventasdf.somee.com/api/Cliente/Obtener/id

  constructor(
    private _http: HttpClient
  ) { }

  getClientes(): Observable<Response> {
    return this._http.get<Response>(this.url);
  }
  add(cliente: Cliente): Observable<Response> {
    return this._http.post<Response>(this.urlPost, cliente, httpOptions);
  }
}
