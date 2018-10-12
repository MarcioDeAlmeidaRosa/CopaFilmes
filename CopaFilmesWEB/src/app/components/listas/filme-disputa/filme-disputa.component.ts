import { Component, OnInit } from '@angular/core';

import { FilmeDataService } from 'src/app/services';

@Component({
  selector: 'app-filme-disputa',
  templateUrl: './filme-disputa.component.html',
  styleUrls: ['./filme-disputa.component.css']
})
export class FilmeDisputaComponent implements OnInit {
  constructor(
    private filmeDataService: FilmeDataService,
  ) { }

  get ListaFilmes() {
    return this.filmeDataService.ListaFilme;
  }
  
  ngOnInit() {
  }

}
