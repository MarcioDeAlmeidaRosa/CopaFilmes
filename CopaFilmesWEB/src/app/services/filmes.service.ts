import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../app.constants';

@Injectable()
export class FilmesService {
  private default_url = Constants.DEFAULT_URL;
  private urlListaFilme = `${this.default_url}/api/Filme`;
  private urlIniciarPartida = `${this.default_url}/api/Partida`;

  constructor(
    private http: HttpClient
  ) { }

  listarFilmes() {
    return this.http.get(this.urlListaFilme, {responseType: 'json'});
  }

  iniciarPartida(body: string[]) {
    return this.http.post(this.urlIniciarPartida, body, {responseType: 'json'});
  }
}
