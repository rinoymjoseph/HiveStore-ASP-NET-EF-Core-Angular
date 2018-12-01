import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import { Observable } from 'rxjs/Observable';
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { BaseService } from '../services/base.service';
import { User } from '../models/user.model';

export class UserService extends BaseService {

  getAllUsers(): Observable<[User]> {
    const getAllUsersURL = AppSettings.GET_ALL_EMPLOYEES_URL;

    return this.http.get<BaseResponse>(getAllUsersURL)
      .map((res: BaseResponse) => this.extractData(res))
      .catch((res: HttpErrorResponse) => this.handleError(res));
  }

  saveUser(employee: User): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const saveUserURL = AppSettings.SAVE_EMPLOYEE_URL;
    return this.http.post<BaseResponse>(saveUserURL, employee, httpOptions)
      .map((res: BaseResponse) => this.extractData(res))
      .catch((res: HttpErrorResponse) => this.handleError(res));
  }

  testFileTransfer(formData1: FormData): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders()
    };
    const testFileTransferURL = AppSettings.TEST_FILE_TRANSFER;
    return this.http.post<BaseResponse>(testFileTransferURL, formData1, httpOptions)
      .map((res: BaseResponse) => this.extractData(res))
      .catch((res: HttpErrorResponse) => this.handleError(res));
  }
}
