import { Component, OnInit } from '@angular/core';

import { ClickEventHelper } from 'src/app/helpers/click-event.helper';
import { FilmesAPIService, FilmeDataService } from 'src/app/services';
import { FilmeModel } from 'src/app/models';


@Component({
  selector: 'app-partida',
  templateUrl: './partida.component.html',
  styleUrls: ['./partida.component.css']
})
export class PartidaComponent implements OnInit {
  

  constructor(
    private clickEventHelper: ClickEventHelper,
    private filmesAPIService: FilmesAPIService,
    private filmeDataService: FilmeDataService,
  ) { }

  consultaFilmes() {
    // TODO:COLOCAR TRATAMENTO DE AGUARDE
    this.filmesAPIService.listarFilmes().subscribe((data:  FilmeModel[]) => {
      this.filmeDataService.ListaFilme = data;
    });
  }

  gerarMeuCampeonato() {
    // TODO: BLOQUEAR AÇÃO DO BOTÃO
    console.log('cliquei no processar');
  }

  ngOnInit() {
    this.clickEventHelper.events$.forEach(event => this.gerarMeuCampeonato());
    this.consultaFilmes();
  }

}
