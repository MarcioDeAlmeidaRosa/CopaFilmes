import { Input, Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

@Component({
  selector: 'app-cabecalho',
  templateUrl: './cabecalho.component.html',
  styleUrls: ['./cabecalho.component.css']
})
export class CabecalhoComponent implements OnInit {

  // @Input()
  // private _TextoCampoStatus: string;
  // public get TextoCampoStatus(): string {
  //   return this._TextoCampoStatus;
  // }
  // public set TextoCampoStatus(value: string) {
  //   this._TextoCampoStatus = value;
  // }

  constructor() { }

  ngOnInit() {
  }

}
