import { Component, OnInit } from '@angular/core';

import { ClickEventHelper } from 'src/app/helpers/click-event.helper';

@Component({
  selector: 'app-comando',
  templateUrl: './comando.component.html',
  styleUrls: ['./comando.component.css']
})
export class ComandoComponent implements OnInit {

  constructor(
    private clickEventHelper: ClickEventHelper
  ) { }

  onClick() {
    this.clickEventHelper.callEvent('clicked!');
  }
  
  ngOnInit() {
  }

}
