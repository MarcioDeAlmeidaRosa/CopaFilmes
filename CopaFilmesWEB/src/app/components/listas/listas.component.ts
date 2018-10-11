import { Input, Component, OnInit } from '@angular/core';
import { FilmeModel } from 'src/app/models';

@Component({
  selector: 'app-listas',
  templateUrl: './listas.component.html',
  styleUrls: ['./listas.component.css']
})
export class ListasComponent implements OnInit {

  @Input() ListaFilme: FilmeModel[];
  @Input() ListagemSelecao: boolean;
  constructor() { }

  ngOnInit() {
  }

}
