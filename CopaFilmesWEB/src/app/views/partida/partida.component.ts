import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { ClickEventHelper } from 'src/app/helpers/click-event.helper';
import { FilmeModel } from 'src/app/models';
import { Constants } from '../../app.constants';
import {
  FilmesAPIService,
  FilmeDataService,
  CurrentUrlService,
  FilmeVencedorDataService,
} from 'src/app/services';

@Component({
  selector: 'app-partida',
  templateUrl: './partida.component.html',
  styleUrls: ['./partida.component.css']
})
export class PartidaComponent implements OnInit, OnDestroy {
  private listaFilmes: FilmeModel[] = [];
  private subscription: Subscription;

  constructor(
    private clickEventHelper: ClickEventHelper,
    private filmesAPIService: FilmesAPIService,
    private filmeDataService: FilmeDataService,
    private currentUrlService: CurrentUrlService,
    private filmeVencedorDataService: FilmeVencedorDataService,
  ) {
    this.subscription = this.filmeDataService.ListaFilme().subscribe(listaFilmes => { this.listaFilmes = listaFilmes; });
  }

  consultaFilmes() {
    // TODO:COLOCAR TRATAMENTO DE AGUARDE
    this.filmesAPIService.listarFilmes().subscribe((data: FilmeModel[]) => {
      data.forEach(i => i.selecionado = false);
      this.filmeDataService.CarregarFilmes(data);
    });
  }

  gerarMeuCampeonato() {
    // TODO: BLOQUEAR AÇÃO DO BOTÃO
    if (!this.listaFilmes.length) { return; }
    const selecionados = this.listaFilmes.filter(f => f.selecionado);
    if (!selecionados.length) { return; }
    if (selecionados.length !== Constants.QUANTIDADE_SELECAO_CAMPEONATO) { return; }
    const ids = selecionados.map(i => i.id, []);
    this.filmesAPIService.iniciarPartida(ids).subscribe((data: FilmeModel[]) => {
      this.filmeVencedorDataService.FimleVencedor = data;
      this.currentUrlService.redirectUrl('/partida/resultado');
    });
  }

  ngOnInit() {
    this.clickEventHelper.events$.forEach(event => this.gerarMeuCampeonato());
    this.consultaFilmes();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
