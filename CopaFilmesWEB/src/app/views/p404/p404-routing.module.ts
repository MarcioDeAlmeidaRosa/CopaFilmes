import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { P404Component } from '.';

const PartidaRoutes: Routes = [
  {
    path: '**' , 
    component: P404Component
  }
];

@NgModule({
  imports: [RouterModule.forChild(PartidaRoutes)],
  exports: [RouterModule]
})
export class P404RoutingModule {}
