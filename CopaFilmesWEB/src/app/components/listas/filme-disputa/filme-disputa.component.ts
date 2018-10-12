import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Subscription, Observable } from 'rxjs';

import { FilmeDataService } from 'src/app/services';
import { FilmeModel } from 'src/app/models';

@Component({
  selector: 'app-filme-disputa',
  templateUrl: './filme-disputa.component.html',
  styleUrls: ['./filme-disputa.component.css']
})
export class FilmeDisputaComponent implements OnInit, OnDestroy {
  private filmes$: Observable<FilmeModel[]>;
  private subscription: Subscription;

  @Input() mensagemErroServico: string;

  constructor(
    private filmeDataService: FilmeDataService,
  ) {
    this.filmes$ = this.filmeDataService.ListaFilme()
    this.subscription = this.filmes$.subscribe();
  }

  get mensagemErroDoServico(){
    return this.mensagemErroServico;
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
