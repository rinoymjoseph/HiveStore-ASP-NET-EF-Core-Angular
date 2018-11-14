export class AppSettings {

  //APIs
  public static EMPLOYEE_API = 'EmployeeAPI';
  public static PRODUCT_API = 'ProductAPI';

  //API URLs
  public static GET_ALL_EMPLOYEES_URL = AppSettings.EMPLOYEE_API + '/GetAllEmployees';
  public static SAVE_EMPLOYEE_URL = AppSettings.EMPLOYEE_API + '/SaveEmployee';
  public static GET_ALL_PRODUCTS_URL = AppSettings.PRODUCT_API + '/GetAllProducts';
  public static SAVE_PRODUCT_URL = AppSettings.PRODUCT_API + '/SaveProduct';
  public static TEST_FILE_TRANSFER = AppSettings.EMPLOYEE_API + '/TestFileTransfer';
}
