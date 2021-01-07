import { CurrenciesDataService, ICurrencyInfo } from './../shared/currenciesData.service';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-cconverter-form',
  templateUrl: './cconverter-form.component.html',
  styleUrls: ['./cconverter-form.component.css']
})
export class CConverterFormComponent implements OnInit {
  public loading: Boolean = true
  public currencies: ICurrencyInfo[] = []
  public sourceAmount: number = 0
  public currencyCode: string = ''
  public targetCurrencyCode: string = ''
  public result: number = 0
  constructor(public currencyDataService: CurrenciesDataService) { }

  ngOnInit(): void {
    this.currencyDataService.fetchCurrencies().subscribe(() => {
      this.loading = false
      this.currencies = this.currencyDataService.currencyItemsList
    })
  }

  public convert(): void {
    console.log(this.currencyCode + " " + this.targetCurrencyCode + " " + this.sourceAmount)

    this.currencyDataService.convert(this.currencyCode, this.targetCurrencyCode, this.sourceAmount).subscribe(res => { this.result = res })
  }

}
