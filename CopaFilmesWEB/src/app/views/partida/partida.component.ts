import { Component, OnInit } from '@angular/core';

import { ClickEventHelper } from 'src/app/helpers/click-event.helper';
import { FilmesService } from 'src/app/services';

@Component({
  selector: 'app-partida',
  templateUrl: './partida.component.html',
  styleUrls: ['./partida.component.css']
})
export class PartidaComponent implements OnInit {

  constructor(
    private clickEventHelper: ClickEventHelper,
    private serviceFilme: FilmesService,
  ) { }

  consultaFilmes() {
    this.serviceFilme.listarFilmes().subscribe(
      res => {
        // this.roleList.forEach((element, index) => {
        //   this.roleList[index].name = res.Permissions[element.id];
        // });
        console.log(res);
      }
    );
  }

  ngOnInit() {
    this.clickEventHelper.events$.forEach(event => this.consultaFilmes());
  }

}
