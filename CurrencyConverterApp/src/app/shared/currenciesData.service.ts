import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AppConfig } from '../config/Config';

export interface ICurrencyInfo {
  id: number
  title: string
  code: string
  rate: number
}

export interface ICurrencyRequest {
  sourceCurrencyCode: string
  targetCurrencyCode: string
  amount: number
  data?: any
}

@Injectable({ providedIn: 'root' })
export class CurrenciesDataService {
  private pathAPI: String = this.config.setting['PathAPI'];
  public currencyItemsList: ICurrencyInfo[] = []
  public targetAmount: number = 0
  //public currencyRequest: ICurrencyRequest

  public constructor(private http: HttpClient, private config: AppConfig) {
  }

  public fetchCurrencies(): Observable<ICurrencyInfo[]> {
    console.error(this.pathAPI);
    return this.http.get<ICurrencyInfo[]>(this.pathAPI + 'currenciesList')
      .pipe(tap(curr => this.currencyItemsList = curr))
  }

  public convert(sourceCurrencyCode: string, targetCurrencyCode: string, amount: number, data?: any): Observable<number> {
    const params = new HttpParams()
      .set('sourceCurrencyCode', sourceCurrencyCode)
      .set('targetCurrencyCode', targetCurrencyCode)
      .set('amount', amount.toString());

    //return this.http.get<number>(this.pathAPI + 'convert', { params })
    return this.http.get<number>(this.pathAPI + 'convert/' + sourceCurrencyCode + "/" + targetCurrencyCode + "/" + amount.toString())
  }

}
