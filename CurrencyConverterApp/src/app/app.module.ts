import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CurrencyConverterComponent } from './currency-converter/currency-converter.component';
import {HttpClientModule} from '@angular/common/http';
import { CurrencyConverterFormComponent } from './currency-converter-form/currency-converter-form.component';
import {FormsModule} from '@angular/forms';
import {CurrencyFilterPipe} from './shared/currencyFilter.pipe'

@NgModule({
  declarations: [
    AppComponent,
    CurrencyConverterComponent,
    CurrencyConverterFormComponent,
    CurrencyFilterPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
