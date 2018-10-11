import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
  FilmeDisputaComponent,
  FilmeVencedorComponent,
} from '.';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
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
