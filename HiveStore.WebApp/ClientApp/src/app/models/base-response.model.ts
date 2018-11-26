export class BaseResponse {
  IsSuccess: boolean;
  Response: string;
  Message: string;
  ConnectionId: string;
  RemoteIpAddress: string;
  LocalIpAddress: string;
  RemotePort: string;
  LocalPort: string;
  RequestPath: string;
}
