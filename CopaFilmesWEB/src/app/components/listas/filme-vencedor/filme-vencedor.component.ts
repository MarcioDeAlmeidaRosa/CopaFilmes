import { Component, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';

import { FilmeVencedorDataService } from 'src/app/services/filmes.vencedor.data.service.';

@Component({
  selector: 'app-filme-vencedor',
  templateUrl: './filme-vencedor.component.html',
  styleUrls: ['./filme-vencedor.component.css']
})
export class FilmeVencedorComponent implements OnInit, OnDestroy {
  @Output() botaoDisparado: EventEmitter<any> = new EventEmitter();
  constructor(
    private filmeVencedorDataService: FilmeVencedorDataService,
  ) { }

  onClick() {
    this.botaoDisparado.emit();
  }

  ngOnInit() {
  }

  ngOnDestroy() {

  }
}
