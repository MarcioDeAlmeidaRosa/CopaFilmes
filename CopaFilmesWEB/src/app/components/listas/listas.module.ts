import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
  ListasComponent ,
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
    ListasComponent,
    FilmeDisputaComponent,
    FilmeVencedorComponent,
  ],
  exports: [
    ListasComponent,
    FilmeDisputaComponent,
    FilmeVencedorComponent,
  ]
})
export class ListasModule { }
