import { Component, OnInit } from '@angular/core';
import {ICurrencyItem, CurrencyConverterService} from '../shared/currency-converter.service'

@Component({
  selector: 'app-currency-converter-form',
  templateUrl: './currency-converter-form.component.html',
  styleUrls: ['./currency-converter-form.component.css']
})
export class CurrencyConverterFormComponent implements OnInit {

  amount: number = 0

  constructor(private currencyConverterService: CurrencyConverterService) { }

  ngOnInit(): void {
  }

  public calculate(){
    const currencyExchangeData: ICurrencyItem = {
      title: 'SuperDollars',    
      amount: this.amount,
      id: Date.now(),
      completed: false,
      date: new Date()
    }

    this.currencyConverterService.AddCurrencyTest(currencyExchangeData)
  }
 

}
