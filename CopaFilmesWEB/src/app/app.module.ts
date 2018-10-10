import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { AppComponent } from './app.component';


import {
  CabecalhoComponent,
  ComandoComponent,
  ListasComponent,
  FilmeDisputaComponent,
  FilmeVencedorComponent
} from './components/';

import { AppRoutingModule } from './app-routing';

import { 
  PartidaComponent ,
  P404Component
} from './views';
import { ResultadoComponent } from './views/partida/resultado/resultado.component';

@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  exports:[

  ],
  providers: [

  ],
  declarations: [
    AppComponent,
    CabecalhoComponent,
    ComandoComponent,
    ListasComponent,
    FilmeDisputaComponent,
    FilmeVencedorComponent,
    PartidaComponent,
    P404Component,
    ResultadoComponent,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
