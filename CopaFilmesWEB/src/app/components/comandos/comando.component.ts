import { Component, OnInit, OnDestroy, Output, EventEmitter, Input } from '@angular/core';
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

  @Output() botaodisparado: EventEmitter<any> = new EventEmitter();
  @Input() desabilitarbotao: boolean = false;
  @Input() titulobotao: string;
  
  constructor(
    private filmeDataService: FilmeDataService,
  ) {
    this.subscription = this.filmeDataService.ListaFilme().subscribe(listaFilmes => { this.listaFilmes = listaFilmes; });
  }

  get totalselecionado() {
    return this.listaFilmes.filter(f => f.selecionado).length;
  }

  onClick() {
    this.botaodisparado.emit();
  }

  ngOnInit() {
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
