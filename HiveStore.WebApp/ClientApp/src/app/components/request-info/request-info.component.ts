import { Component, OnInit, Input } from '@angular/core';
import { InfrastructureService } from '../../services/infrastructure.service';
import { RequestInfo } from '../../models/request-info.model';
import { AppSettings } from '../../app.settings';

@Component({
  selector: 'app-server-info',
  templateUrl: './request-info.component.html',
  styleUrls: ['./request-info.component.css'],
  providers: [InfrastructureService]
})
export class RequestInfoComponent implements OnInit {

  serverInfo: RequestInfo;
  requests: RequestInfo[] = [];

  constructor(private infrastructureService: InfrastructureService) { }

  ngOnInit() {
    this.getRequestInfo();
  }

  getRequestInfo() {
    AppSettings.RequestInfoEvent.subscribe(res => {
      this.serverInfo = res;
      let requestsGridData = [...this.requests];
      requestsGridData.unshift(res);
      this.requests = requestsGridData;
    });
  }
}
