import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { FilmeDataService } from 'src/app/services';
import { FilmeModel } from 'src/app/models';

@Component({
  selector: 'app-filme-disputa',
  templateUrl: './filme-disputa.component.html',
  styleUrls: ['./filme-disputa.component.css']
})
export class FilmeDisputaComponent implements OnInit, OnDestroy  {
  private listaFilmes: FilmeModel[] = [];
  private subscription: Subscription;
  constructor(
    private filmeDataService: FilmeDataService,
  ) {
    this.subscription = this.filmeDataService.ListaFilme().subscribe(listaFilmes => { this.listaFilmes = listaFilmes; });
  }

  get ListaFilmes() {
    return this.listaFilmes;
  }

  MudarSelecionado(filme) {
    filme.selecionado = !filme.selecionado;
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
