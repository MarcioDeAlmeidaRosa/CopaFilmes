import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { 
  PartidaComponent, 
  ResultadoComponent 
} from './views/partida';

import { 
  P404Component, 
} from './views/p404';

const routes: Routes = [
  { path: 'partida', component: PartidaComponent },
  { path: 'partida/resultado', component: ResultadoComponent },
  { path: '', redirectTo: '/partida', pathMatch: 'full' },
  {
    path: '**', component: P404Component
  }
];

@NgModule({
  exports: [RouterModule],
  imports: [RouterModule.forRoot(routes)],
})

export class AppRoutingModule { }
