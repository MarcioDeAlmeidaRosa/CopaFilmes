import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

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
  public mensagemerroservico: string;

  constructor(
    private filmesAPIService: FilmesAPIService,
    private filmeDataService: FilmeDataService,
    private currentUrlService: CurrentUrlService,
    private filmeVencedorDataService: FilmeVencedorDataService,
  ) {
    this.subscription = this.filmeDataService.ListaFilme().subscribe(listaFilmes => { this.listaFilmes = listaFilmes; });
  }

  consultaFilmes() {
    this.filmesAPIService.listarFilmes().subscribe(
      (data: FilmeModel[]) => this.filmeDataService.CarregarFilmes(data),
      (err) => {
        this.filmeDataService.CarregarFilmes([]);
        this.mensagemerroservico = err.error.message;
      }
    );
  }
  get totalnecessarioregistro(){
    return Constants.QUANTIDADE_SELECAO_CAMPEONATO;
  }

  get liberabotao(){
    return !(this.listaFilmes.filter(f => f.selecionado).length === this.totalnecessarioregistro);
  }

  gerarmeucampeonato() {
    if (!this.liberabotao){
      if (!this.listaFilmes.length) { return; }
      const selecionados = this.listaFilmes.filter(f => f.selecionado);
      if (!selecionados.length) { return; }
      if (selecionados.length !== this.totalnecessarioregistro) { return; }
      const ids = selecionados.map(i => i.id, []);
      this.filmesAPIService.iniciarPartida(ids).subscribe((data: FilmeModel[]) => {
        this.filmeVencedorDataService.FimleVencedor = data;
        this.currentUrlService.redirectUrl('/partida/resultado');
      });
    }
  }

  ngOnInit() {
    this.consultaFilmes();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
