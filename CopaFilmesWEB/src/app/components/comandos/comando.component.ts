import { Component, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs';

import { FilmeDataService } from 'src/app/services';
import { FilmeModel } from 'src/app/models';

@Component({
  selector: 'app-comando',
  templateUrl: './comando.component.html',
  styleUrls: ['./comando.component.css']
})
export class ComandoComponent implements OnInit, OnDestroy {
  private listaFilmes: FilmeModel[] = [];
  private subscription: Subscription;

  @Output() botaoDisparado: EventEmitter<any> = new EventEmitter();
  
  constructor(
    private filmeDataService: FilmeDataService,
  ) {
    this.subscription = this.filmeDataService.ListaFilme().subscribe(listaFilmes => { this.listaFilmes = listaFilmes; });
  }

  get TotalSelecionado() {
    return this.listaFilmes.filter(f => f.selecionado).length;
  }

  onClick() {
    this.botaoDisparado.emit();
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
