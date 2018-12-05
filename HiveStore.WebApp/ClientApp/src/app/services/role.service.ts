import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { Role } from '../models/role.model';
import { BaseService } from '../services/base.service';

export class RoleService extends BaseService {

  getAllRoles(): Observable<[Role]> {
    const url = AppSettings.GET_ALL_ROLES_URL;
    return this.http.get<BaseResponse>(url).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }

  saveRole(role: Role): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const url = AppSettings.SAVE_ROLE_URL;
    return this.http.post<BaseResponse>(url, role, httpOptions).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }
}
