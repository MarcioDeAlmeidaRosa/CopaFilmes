import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing';
import {
  CurrentUrlService,
  FilmesAPIService,
  FilmeDataService,
  FilmeVencedorDataService,
} from './services';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    HttpClient,
    CurrentUrlService,
    FilmesAPIService,
    FilmeDataService,
    FilmeVencedorDataService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
