import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { CabecalhoComponent } from '.';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [
    CabecalhoComponent,
  ],
  exports: [
    CabecalhoComponent,
  ]
})
export class CabecalhoModule { }
