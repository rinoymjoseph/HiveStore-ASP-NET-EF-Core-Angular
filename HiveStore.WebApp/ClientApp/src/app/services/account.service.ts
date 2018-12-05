import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs'
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { SignIn } from '../models/sign-in.model';
import { User } from '../models/user.model';
import { BaseService } from '../services/base.service';

export class AccountService extends BaseService {

  signIn(singInDTO: SignIn): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const url = AppSettings.SIGN_IN_URL;
    return this.http.post<BaseResponse>(url, singInDTO, httpOptions).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }

  signOut(): Observable<string> {
    const url = AppSettings.SIGN_OUT_URL;

    return this.http.get<BaseResponse>(url).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }

  getSignedInUser(): Observable<User> {
    const url = AppSettings.GET_SIGNED_IN_USER;

    return this.http.get<BaseResponse>(url).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }
}
