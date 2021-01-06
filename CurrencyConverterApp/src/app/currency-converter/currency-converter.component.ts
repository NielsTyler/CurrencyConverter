import { Component, OnInit } from '@angular/core';
import {CurrencyConverterService} from '../shared/currency-converter.service';
import {delay} from 'rxjs/operators';

@Component({
  selector: 'app-currency-converter',
  templateUrl: './currency-converter.component.html',
  styleUrls: ['./currency-converter.component.css']
})
export class CurrencyConverterComponent implements OnInit {  
  constructor(public currencyConverterService: CurrencyConverterService ) { }
  public loading: boolean = true
  public searchString: string = ''

  ngOnInit(): void {
    this.currencyConverterService.fetchCurrencies().pipe(delay(500)).subscribe(() => {
        this.loading = false
    })
  }

  onChange(id: number) {
    this.currencyConverterService.onToggle(id)
  }

  removeCur(id: number){
    this.currencyConverterService.RemoveCurrency(id)
  }

}
