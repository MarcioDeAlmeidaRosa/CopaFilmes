import { Input, Component, OnInit } from '@angular/core';

import { ClickEventHelper } from 'src/app/helpers/click-event.helper';
import { FilmeModel } from 'src/app/models';

@Component({
  selector: 'app-comando',
  templateUrl: './comando.component.html',
  styleUrls: ['./comando.component.css']
})
export class ComandoComponent implements OnInit {

  @Input() ListaFilmeVerificacao: FilmeModel[];
  
  constructor(
    private clickEventHelper: ClickEventHelper
  ) { }

  get TotalSelecionado() {
    //  return this.ListaFilmeVerificacao.filter(filmes => filmes.selecionado === true );
    return 1;
  }

  onClick() {
    this.clickEventHelper.callEvent('clicked!');
  }
  
  ngOnInit() {
  }

}
