import { Subject } from "rxjs";
import { RequestInfo } from "./models/request-info.model";

export class AppSettings {

  public static RequestInfoEvent: Subject<RequestInfo> = new Subject<RequestInfo>();
  public static IsLoginPageEvent: Subject<Boolean> = new Subject<Boolean>();

  //APIs
  public static ACCOUNT_API = 'AccountAPI';
  public static ROLE_API = 'RoleAPI';
  public static USER_API = 'UserAPI';
  public static PRODUCT_API = 'ProductAPI';
  public static INFRASTRUCTURE_API = 'InfrastructureAPI';

  //API URLs
  public static SIGN_IN_URL = AppSettings.ACCOUNT_API + '/SignIn';
  public static SIGN_OUT_URL = AppSettings.ACCOUNT_API + '/SignOut';
  public static GET_SIGNED_IN_USER = AppSettings.ACCOUNT_API + '/GetSignedInUser';
  public static GET_ALL_ROLES_URL = AppSettings.ROLE_API + '/GetAllRoles';
  public static SAVE_ROLE_URL = AppSettings.ROLE_API + '/SaveRole';
  public static GET_ALL_EMPLOYEES_URL = AppSettings.USER_API + '/GetAllUsers';
  public static SAVE_EMPLOYEE_URL = AppSettings.USER_API + '/SaveUser';
  public static GET_ALL_PRODUCTS_URL = AppSettings.PRODUCT_API + '/GetAllProducts';
  public static SAVE_PRODUCT_URL = AppSettings.PRODUCT_API + '/SaveProduct';
  public static GET_SERVER_INFO = AppSettings.INFRASTRUCTURE_API + '/GetRequestInfo';
}
