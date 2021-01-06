import {Pipe, PipeTransform} from '@angular/core';
import {ICurrencyItem} from './currency-converter.service'

@Pipe({
    name: 'currencyfilter'
})
export class CurrencyFilterPipe implements PipeTransform {
    transform(currencies: ICurrencyItem[], search: string = ''): ICurrencyItem[] {
        if (!search.trim())
        {
            return currencies
        }

        return currencies.filter(curr =>{
            return curr.title.toLowerCase().indexOf(search.toLowerCase()) !== -1
        })
    }
}
