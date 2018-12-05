import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { BaseService } from '../services/base.service';
import { User } from '../models/user.model';

export class UserService extends BaseService {

  getAllUsers(): Observable<[User]> {
    const url = AppSettings.GET_ALL_EMPLOYEES_URL;

    return this.http.get<BaseResponse>(url).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }

  saveUser(employee: User): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const url = AppSettings.SAVE_EMPLOYEE_URL;
    return this.http.post<BaseResponse>(url, employee, httpOptions).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }

  getCountryList(): Observable<any> {
    const url = './app/assets/data/countries.json';

    return this.http.get<any>(url).pipe(
      map((res) =>
      {
        return res;
      }),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }
}
