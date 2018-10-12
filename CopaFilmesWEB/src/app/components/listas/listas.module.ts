import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
  FilmeDisputaComponent,
  FilmeVencedorComponent,
} from '.';
import { ComandosModule } from '../comandos/comandos.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ComandosModule,
  ],
  declarations: [
    FilmeDisputaComponent,
    FilmeVencedorComponent,
  ],
  exports: [
    FilmeDisputaComponent,
    FilmeVencedorComponent,
  ]
})
export class ListasModule { }
