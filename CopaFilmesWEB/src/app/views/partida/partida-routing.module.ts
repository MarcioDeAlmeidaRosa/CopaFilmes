import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PartidaComponent, ResultadoComponent } from '.';

const PartidaRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'partida',
        component: PartidaComponent
      },
      {
        path: 'partida/resultado',
        component: ResultadoComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(PartidaRoutes)],
  exports: [RouterModule]
})
export class PartidaRoutingModule { }
