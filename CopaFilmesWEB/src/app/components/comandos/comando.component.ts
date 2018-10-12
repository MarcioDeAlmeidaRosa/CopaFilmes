import { Component, OnInit } from '@angular/core';

import { ClickEventHelper } from 'src/app/helpers/click-event.helper';
import { FilmeDataService } from 'src/app/services';

@Component({
  selector: 'app-comando',
  templateUrl: './comando.component.html',
  styleUrls: ['./comando.component.css']
})
export class ComandoComponent implements OnInit {
  constructor(
    private clickEventHelper: ClickEventHelper,
    private filmeDataService: FilmeDataService,
  ) { }

  get TotalSelecionado() {
    return this.filmeDataService.Selecionado.length;
  }

  onClick() {
    this.clickEventHelper.callEvent('clicked!');
  }

  ngOnInit() {
  }

}
