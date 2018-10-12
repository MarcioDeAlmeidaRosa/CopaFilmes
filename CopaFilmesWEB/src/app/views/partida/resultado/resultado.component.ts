import { Component, OnInit, OnDestroy } from '@angular/core';

import { FilmeVencedorDataService, CurrentUrlService } from 'src/app/services';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent implements OnInit, OnDestroy {

  constructor(
    private filmeVencedorDataService: FilmeVencedorDataService,
    private currentUrlService: CurrentUrlService,
  ) {
    if (this.filmeVencedorDataService.FimleVencedor.length == 0) {
      this.novocampeonato();
      return;
    }
  }

  novocampeonato() {
    this.currentUrlService.redirectUrl('/partida');
  }

  ngOnInit() {

  }

  ngOnDestroy() {
    
  }

}
