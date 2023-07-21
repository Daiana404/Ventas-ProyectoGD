import { Component, OnInit } from '@angular/core';
import { ApiclientService } from 'src/app/services/apiclient.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {

  constructor(
    private apiCliente: ApiclientService
  ) { 
    apiCliente.getClientes().subscribe(response => {
      console.log(response);
    })
    // :x 
  }

  ngOnInit(): void {

  }
}
