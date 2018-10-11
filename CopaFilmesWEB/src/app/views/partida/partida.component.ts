import { Component, OnInit } from '@angular/core';

import { ClickEventHelper } from 'src/app/helpers/click-event.helper';
import { FilmesAPIService } from 'src/app/services';
import { FilmeModel } from 'src/app/models';


@Component({
  selector: 'app-partida',
  templateUrl: './partida.component.html',
  styleUrls: ['./partida.component.css']
})
export class PartidaComponent implements OnInit {
  public listaFilmesSelecao: FilmeModel[];

  constructor(
    private clickEventHelper: ClickEventHelper,
    private serviceAPIFilme: FilmesAPIService,
  ) { }

  consultaFilmes() {
    // TODO:COLOCAR TRATAMENTO DE AGUARDE
    this.serviceAPIFilme.listarFilmes().subscribe((data:  FilmeModel[]) => {
      this.listaFilmesSelecao = data;
    });
  }

  gerarMeuCampeonato() {

  }

  ngOnInit() {
    this.clickEventHelper.events$.forEach(event => this.gerarMeuCampeonato());
    this.consultaFilmes();
  }

}
