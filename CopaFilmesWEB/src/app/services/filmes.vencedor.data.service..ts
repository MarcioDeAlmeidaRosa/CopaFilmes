import { Injectable } from '@angular/core';

import { FilmeModel } from '../models';

@Injectable({ providedIn: 'root' })
export class FilmeVencedorDataService {
  private filmeVencedor: FilmeModel[] = [];

  constructor() {
    this.LimparFilmes();
  }

  LimparFilmes() {
    this.filmeVencedor = [];
  }

  set FimleVencedor(value: FilmeModel[]) {
    this.filmeVencedor = value;
  }

  get FimleVencedor() {
    return this.filmeVencedor;
  }
}
