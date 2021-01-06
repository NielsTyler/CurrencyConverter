import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

export interface ICurrencyItem {
    id: number
    title: string
    completed: boolean
    date?: any
    amount: number
  }

@Injectable({providedIn: 'root'})
export class CurrencyConverterService {  
  public currencyConverterList: ICurrencyItem[] = []
    // public currencyConverterList: ICurrencyItem[]  = [
    //     {
    //       id: 1, title: 'USD', completed: false, date: new Date() 
    //     },
    //     {
    //       id: 2, title: 'RUB', completed: true, date: new Date() 
    //     },
    //     {
    //       id: 3, title: 'EUR', completed: true, date: new Date() 
    //     }
    //   ]

      constructor(private http: HttpClient ) { }

      public fetchCurrencies(): Observable<ICurrencyItem[]> {
        return this.http.get<ICurrencyItem[]>('http://localhost:59905/api/Currencies')
        .pipe(tap( curr => this.currencyConverterList = curr))
      }

      public onToggle(id: number) {
        const idx = this.currencyConverterList.findIndex(t => t.id === id)
    
        this.currencyConverterList[idx].completed = !this.currencyConverterList[idx].completed
      }

      public RemoveCurrency(id: number) {
        this.currencyConverterList = this.currencyConverterList.filter(t => t.id !== id)
      }

      public AddCurrencyTest(item: ICurrencyItem)
      {
          this.currencyConverterList.push(item);
      }
}
