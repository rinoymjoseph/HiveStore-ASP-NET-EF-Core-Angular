import { Component, OnInit, Input } from '@angular/core';
import { InfrastructureService } from '../../services/infrastructure.service';
import { ServerInfo } from '../../models/server-info.model';
import { AppSettings } from '../../app.settings';

@Component({
  selector: 'app-server-info',
  templateUrl: './server-info.component.html',
  styleUrls: ['./server-info.component.css'],
  providers: [InfrastructureService]
})
export class ServerInfoComponent implements OnInit {

  serverInfo: ServerInfo;

  constructor(private infrastructureService: InfrastructureService) { }

  ngOnInit() {
    //this.infrastructureService.getServerInfo().subscribe(
    //  (res) => {
    //    console.log(res);
    //    this.serverInfo = res;
    //  },
    //  error => {
    //  });
    this.getServerInfo();
  }

  getServerInfo() {
    AppSettings.ServerInfo.subscribe(res => {
      this.serverInfo = res;
    });
  }
}
