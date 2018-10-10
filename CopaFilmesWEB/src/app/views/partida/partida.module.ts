import { Routes } from '@angular/router';

import {
   PartidaComponent, 
   ResultadoComponent 
} from '.';

export const PartidaModule: Routes = [
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
