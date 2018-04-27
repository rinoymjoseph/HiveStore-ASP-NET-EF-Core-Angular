import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import { Observable } from 'rxjs/Observable';
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../base-response.model';
import { BaseService } from '../base.service';
import { Employee } from './employee.model';

export class EmployeeService extends BaseService {

  getAllEmployees(): Observable<[Employee]> {
    const getAllEmployeesURL = AppSettings.GET_ALL_EMPLOYEES_URL;

    return this.http.get<BaseResponse>(getAllEmployeesURL)
      .map((res: BaseResponse) => this.extractData(res))
      .catch((res: HttpErrorResponse) => this.handleError(res));
  }

  saveEmployee(employee: Employee): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const saveEmployeeURL = AppSettings.SAVE_EMPLOYEE_URL;
    return this.http.post<BaseResponse>(saveEmployeeURL, employee, httpOptions)
      .map((res: BaseResponse) => this.extractData(res))
      .catch((res: HttpErrorResponse) => this.handleError(res));
  }
}
