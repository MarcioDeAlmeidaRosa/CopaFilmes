import { Component, OnInit, OnDestroy } from '@angular/core';

import { Subscription } from 'rxjs';
import { ClickEventHelper } from 'src/app/helpers/click-event.helper';
import { FilmesAPIService, FilmeDataService } from 'src/app/services';
import { FilmeModel } from 'src/app/models';


@Component({
  selector: 'app-partida',
  templateUrl: './partida.component.html',
  styleUrls: ['./partida.component.css']
})
export class PartidaComponent implements OnInit, OnDestroy {
  private subscription: Subscription;

  constructor(
    private clickEventHelper: ClickEventHelper,
    private filmesAPIService: FilmesAPIService,
    private filmeDataService: FilmeDataService,
  ) { }

  consultaFilmes() {
    // TODO:COLOCAR TRATAMENTO DE AGUARDE
    this.filmesAPIService.listarFilmes().subscribe((data:  FilmeModel[]) => {
      data.forEach(i => i.selecionado = false);
      this.filmeDataService.CarregarFilmes(data);
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

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
