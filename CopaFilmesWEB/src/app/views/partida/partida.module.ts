import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { ReactiveFormsModule } from '@angular/forms';

import { PartidaRoutingModule } from './partida-routing.module';
import { CabecalhoModule } from 'src/app/components/cabecalho/cabecalho.module';
import { ComandosModule } from 'src/app/components/comandos/comandos.module';
import { ListasModule } from 'src/app/components/listas/listas.module';

import { PartidaComponent } from './partida.component';
import { ResultadoComponent } from './resultado/resultado.component';

@NgModule({
  imports: [
    PartidaRoutingModule,
    CommonModule,
    ReactiveFormsModule,
    TranslateModule,
    CabecalhoModule,
    ComandosModule,
    ListasModule,
  ],
  declarations: [
    PartidaComponent,
    ResultadoComponent,
  ],
  exports: [
    PartidaComponent,
    ResultadoComponent,
  ]
})
export class PartidaModule { }
