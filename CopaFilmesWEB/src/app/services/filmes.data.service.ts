import { Injectable } from '@angular/core';

import { FilmeModel } from '../models';

@Injectable()
export class FilmeDataService {
  private listaFilme: FilmeModel[] = [];

  constructor() { }

  get ListaFilme(): FilmeModel[] {
    return this.listaFilme;
  }

  set ListaFilme(value: FilmeModel[]) {
    this.listaFilme = value;
  }

  get Selecionado(): FilmeModel[] {
    return this.ListaFilme.filter(f => f.selecionado);
  }

}
