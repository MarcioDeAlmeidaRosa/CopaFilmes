import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

import { FilmeModel } from '../models';

@Injectable({ providedIn: 'root' })
export class FilmeDataService {
  private subject = new Subject<any>();
  constructor() {
    this.LimparFilmes();
  }

  LimparFilmes() {
    this.subject.next();
  }

  ListaFilme(): Observable<FilmeModel[]> {
    return this.subject.asObservable();
  }

  CarregarFilmes(value: any) {
    this.subject.next(value);
  }
}
