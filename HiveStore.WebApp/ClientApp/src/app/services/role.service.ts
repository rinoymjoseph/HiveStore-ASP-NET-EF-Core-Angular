import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import { Observable } from 'rxjs/Observable';
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { Role } from '../models/role.model';
import { BaseService } from '../services/base.service';

export class RoleService extends BaseService {

  getAllRoles(): Observable<[Role]> {
    const url = AppSettings.GET_ALL_ROLES_URL;
    return this.http.get<BaseResponse>(url)
      .map((res: BaseResponse) => this.extractData(res))
      .catch((res: HttpErrorResponse) => this.handleError(res));
  }

  saveRole(role: Role): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const url = AppSettings.SAVE_ROLE_URL;
    return this.http.post<BaseResponse>(url, role, httpOptions)
      .map((res: BaseResponse) => this.extractData(res))
      .catch((res: HttpErrorResponse) => this.handleError(res));
  }
}
