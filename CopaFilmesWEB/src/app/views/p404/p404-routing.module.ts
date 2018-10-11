import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { P404Component } from '.';

const P404Routes: Routes = [
  {
    path: '**' , 
    component: P404Component
  }
];

@NgModule({
  imports: [RouterModule.forChild(P404Routes)],
  exports: [RouterModule]
})
export class P404RoutingModule {}
