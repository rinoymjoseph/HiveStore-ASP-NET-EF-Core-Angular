import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import { Observable } from 'rxjs/Observable';
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { RequestInfo } from '../models/request-info.model';
import { BaseService } from '../services/base.service';

export class InfrastructureService extends BaseService {

  getRequestInfo(): Observable<RequestInfo> {
    const url = AppSettings.GET_SERVER_INFO;

    return this.http.get<BaseResponse>(url)
      .map((res: BaseResponse) => this.extractData(res))
      .catch((res: HttpErrorResponse) => this.handleError(res));
  }
}
