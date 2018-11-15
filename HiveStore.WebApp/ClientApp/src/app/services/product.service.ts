import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import { Observable } from 'rxjs/Observable';
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { Product } from '../models/product.model';
import { BaseService } from '../services/base.service';

export class ProductService extends BaseService {

  getAllProducts(): Observable<[Product]> {
    const getAllProductsURL = AppSettings.GET_ALL_PRODUCTS_URL;

    return this.http.get<BaseResponse>(getAllProductsURL)
      .map((res: BaseResponse) => this.extractData(res))
      .catch((res: HttpErrorResponse) => this.handleError(res));
  }

  saveProduct(product: Product): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const saveProductURL = AppSettings.SAVE_PRODUCT_URL;
    return this.http.post<BaseResponse>(saveProductURL, product, httpOptions)
      .map((res: BaseResponse) => this.extractData(res))
      .catch((res: HttpErrorResponse) => this.handleError(res));
  }
}
