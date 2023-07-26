import { Component, OnInit } from '@angular/core';
import { ApiclientService } from 'src/app/services/apiclient.service';
import { Response } from '../../models/response'

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {

  public lst: any[''];
  public columnas = ['id', 'nombre', 'apellido'];
  constructor(
    private apiCliente: ApiclientService
  ) { 
  }

  ngOnInit(): void {
    this.getClientes()
  }

  getClientes() {
    // suscribe debido al observable
    this.apiCliente.getClientes().subscribe(response => {
      this.lst = response.data;
    })
  }
}
