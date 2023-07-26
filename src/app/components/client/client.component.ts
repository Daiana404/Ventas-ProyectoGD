import { Component, OnInit } from '@angular/core';
import { ApiclientService } from 'src/app/services/apiclient.service';
import { Response } from '../../models/response'
import { DialogClienteComponent } from './dialog/dialogcliente.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {

  public lst: any[''];
  public columnas = ['id', 'nombre', 'apellido'];
  constructor(
    private apiCliente: ApiclientService,
    public dialog: MatDialog
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
  openAdd() {
    const dialogRef = this.dialog.open(DialogClienteComponent, {
      width: '300'
    });
    dialogRef.afterClosed().subscribe(result => {
      this.getClientes();
    })
  }
}
