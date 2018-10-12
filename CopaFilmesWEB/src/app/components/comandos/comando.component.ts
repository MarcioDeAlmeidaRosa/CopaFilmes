import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { ClickEventHelper } from 'src/app/helpers/click-event.helper';
import { FilmeDataService } from 'src/app/services';
import { FilmeModel } from 'src/app/models';

@Component({
  selector: 'app-comando',
  templateUrl: './comando.component.html',
  styleUrls: ['./comando.component.css']
})
export class ComandoComponent implements OnInit, OnDestroy  {
  private listaFilmes: FilmeModel[] = [];
  private subscription: Subscription;
  constructor(
    private clickEventHelper: ClickEventHelper, // TODO: RETIRAR DEPOIS
    private filmeDataService: FilmeDataService,
  ) {
    this.subscription = this.filmeDataService.ListaFilme().subscribe(listaFilmes => { this.listaFilmes = listaFilmes; });
  }

  get TotalSelecionado() {
    return this.listaFilmes.filter(f => f.selecionado).length;
  }

  onClick() {
    this.clickEventHelper.callEvent('clicked!');
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
