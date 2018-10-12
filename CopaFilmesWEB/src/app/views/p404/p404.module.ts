import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { ReactiveFormsModule } from '@angular/forms';

import { P404RoutingModule } from './p404-routing.module';
import { P404Component } from './p404.component';

@NgModule({
  imports: [
    P404RoutingModule,
    CommonModule,
    ReactiveFormsModule,
    TranslateModule,
  ],
  declarations: [
    P404Component,
  ],
  exports: [
    P404Component,
  ]
})
export class P404Module { }
