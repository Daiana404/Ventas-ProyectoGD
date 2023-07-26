import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Cliente } from 'src/app/models/cliente';
import { ApiclientService } from 'src/app/services/apiclient.service';

@Component({
    templateUrl: 'dialogcliente.component.html',
    styleUrls: ['./dialogcliente.component.scss']
})

export class DialogClienteComponent {
    constructor(
        public dialogRef: MatDialogRef<DialogClienteComponent>,
        public apiCliente: ApiclientService,
        public snackBar: MatSnackBar
    ) {}

    close() {
        this.dialogRef.close();
    }

    addCliente() {
        console.log('agregar')
        const cliente: Cliente = { nombre : 'Fulanito', apellido: 'De Tal'};

        this.apiCliente.add(cliente).subscribe(response => {
            if( response.exito === 1) {
                this.dialogRef.close();
                this.snackBar.open('Cliente añadido con éxito', '', { duration: 2000 });
            }
        });
    }
}