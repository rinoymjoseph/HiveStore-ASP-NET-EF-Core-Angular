"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var user_component_1 = require("./components/user/user.component");
var product_component_1 = require("./components/product/product.component");
var order_component_1 = require("./components/order/order.component");
var login_component_1 = require("./components/login/login.component");
var role_component_1 = require("./components/role/role.component");
var auth_guard_1 = require("./services/auth.guard");
exports.routes = [
    { path: '', component: user_component_1.UserComponent, pathMatch: 'full', canActivate: [auth_guard_1.AuthGuard] },
    { path: 'login', component: login_component_1.LoginComponent },
    { path: 'user', component: user_component_1.UserComponent, canActivate: [auth_guard_1.AuthGuard] },
    { path: 'product', component: product_component_1.ProductComponent, canActivate: [auth_guard_1.AuthGuard] },
    { path: 'order', component: order_component_1.OrderComponent },
    { path: 'user', component: user_component_1.UserComponent },
    { path: 'role', component: role_component_1.RoleComponent },
];
exports.routing = router_1.RouterModule.forRoot(exports.routes);
//# sourceMappingURL=app.routing.js.map