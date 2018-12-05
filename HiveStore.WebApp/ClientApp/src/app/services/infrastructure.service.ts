import { HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs'
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { RequestInfo } from '../models/request-info.model';
import { BaseService } from '../services/base.service';

export class InfrastructureService extends BaseService {

  getRequestInfo(): Observable<RequestInfo> {
    const url = AppSettings.GET_SERVER_INFO;

    return this.http.get<BaseResponse>(url).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }
}
