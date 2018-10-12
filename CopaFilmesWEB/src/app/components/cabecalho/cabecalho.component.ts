import { Input, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cabecalho',
  templateUrl: './cabecalho.component.html',
  styleUrls: ['./cabecalho.component.css']
})
export class CabecalhoComponent implements OnInit {

  @Input() textocampostatus: string;
  @Input() textocampoorientacao: string;

  constructor() { }

  ngOnInit() {
  }

}
