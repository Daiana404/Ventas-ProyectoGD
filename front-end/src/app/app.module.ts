
//root
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HomeComponent } from './components/home/home.component';
import { ClientComponent } from './components/client/client.component';

import {MatSidenavModule} from '@angular/material/sidenav';

import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ClientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,

    HttpClientModule //Solicitudes http para la conexión del servicio
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
