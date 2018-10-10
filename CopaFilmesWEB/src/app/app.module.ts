import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CabecalhoComponent } from './components/cabecalho/cabecalho.component';
import { ComandoComponent } from './components/comandos/comando.component';
import { ListasComponent } from './components/listas/listas.component';
import { FilmeDisputaComponent } from './components/listas/filme-disputa/filme-disputa.component';
import { FilmeVencedorComponent } from './components/listas/filme-vencedor/filme-vencedor.component';

@NgModule({
  declarations: [
    AppComponent,
    CabecalhoComponent,
    ComandoComponent,
    ListasComponent,
    FilmeDisputaComponent,
    FilmeVencedorComponent,
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
