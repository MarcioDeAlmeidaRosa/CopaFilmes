import { Component, OnInit, OnDestroy } from '@angular/core';

import { FilmeModel } from 'src/app/models';
import { FilmeVencedorDataService } from 'src/app/services/filmes.vencedor.data.service.';

@Component({
  selector: 'app-filme-vencedor',
  templateUrl: './filme-vencedor.component.html',
  styleUrls: ['./filme-vencedor.component.css']
})
export class FilmeVencedorComponent implements OnInit, OnDestroy {
  private listaFilmes: FilmeModel[] = [];
  constructor(
    private filmeVencedorDataService: FilmeVencedorDataService,
  ) {
    this.listaFilmes = this.filmeVencedorDataService.FimleVencedor;
  }

  ngOnInit() {
  }

  ngOnDestroy() {

  }
}
