import {Input, Component, OnInit } from '@angular/core';

import { FilmeModel } from 'src/app/models';

@Component({
  selector: 'app-filme-disputa',
  templateUrl: './filme-disputa.component.html',
  styleUrls: ['./filme-disputa.component.css']
})
export class FilmeDisputaComponent implements OnInit {
  
  @Input() ListaFilmeVerificacao: FilmeModel[];

  constructor() { }

  get ListaFilmes(){
    return this.ListaFilmeVerificacao;
  }

  ngOnInit() {
    
  }

}
