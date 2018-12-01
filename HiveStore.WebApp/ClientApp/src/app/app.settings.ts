import { Subject } from "rxjs/Subject";
import { RequestInfo } from "./models/request-info.model";

export class AppSettings {

  public static RequestInfoEvent: Subject<RequestInfo> = new Subject<RequestInfo>();
  public static IsLoginPageEvent: Subject<Boolean> = new Subject<Boolean>();

  //APIs
  public static ACCOUNT_API = 'AccountAPI';
  public static EMPLOYEE_API = 'UserAPI';
  public static PRODUCT_API = 'ProductAPI';
  public static INFRASTRUCTURE_API = 'InfrastructureAPI';

  //API URLs
  public static SIGN_IN_URL = AppSettings.ACCOUNT_API + '/SignIn';
  public static SIGN_OUT_URL = AppSettings.ACCOUNT_API + '/SignOut';
  public static GET_ALL_EMPLOYEES_URL = AppSettings.EMPLOYEE_API + '/GetAllUsers';
  public static SAVE_EMPLOYEE_URL = AppSettings.EMPLOYEE_API + '/SaveUser';
  public static GET_ALL_PRODUCTS_URL = AppSettings.PRODUCT_API + '/GetAllProducts';
  public static SAVE_PRODUCT_URL = AppSettings.PRODUCT_API + '/SaveProduct';
  public static TEST_FILE_TRANSFER = AppSettings.EMPLOYEE_API + '/TestFileTransfer';
  public static GET_SERVER_INFO = AppSettings.INFRASTRUCTURE_API + '/GetRequestInfo';
}
