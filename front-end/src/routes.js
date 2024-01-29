/*!

=========================================================
* Argon Dashboard React - v1.2.4
=========================================================

* Product Page: https://www.creative-tim.com/product/argon-dashboard-react
* Copyright 2024 Creative Tim (https://www.creative-tim.com)
* Licensed under MIT (https://github.com/creativetimofficial/argon-dashboard-react/blob/master/LICENSE.md)

* Coded by Creative Tim

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

*/
import Dashboard from "views/dashboard/index";
import Login from "views/auth/login";
import Register from "views/auth/register";
import Accounts from "views/account/index";
import DepositFunds from "views/funds/deposit";
import WithdrawFunds from "views/funds/withdraw";
import TransferFunds from "views/funds/transfer";
import ATM from "views/atm/index";
import Profile from "views/auth/profile";

var routes = [
  {
    path: "/index",
    name: "Dashboard",
    icon: "ni ni-tv-2 text-primary",
    component: <Dashboard/>,
    layout: "/admin",
  },
  {
    path: "/login",
    name: "Login",
    icon: "ni ni-tv-2 text-primary",
    component: <Login/>,
    layout: "/auth",
    invisible: true,
  },
  {
    path: "/register",
    name: "Register",
    icon: "ni ni-tv-2 text-primary",
    component: <Register/>,
    layout: "/auth",
    invisible: true,
  },
  {
    path: "/accounts",
    name: "Accounts",
    icon: "ni ni-money-coins text-orange",
    component: <Accounts/>,
    layout: "/admin",
  },
  {
    path: "/deposit-funds",
    name: "Deposit Funds",
    icon: "ni ni-archive-2 text-blue",
    component: <DepositFunds/>,
    layout: "/admin",
  },
  {
    path: "/withdraw-funds",
    name: "Withdraw Funds",
    icon: "ni ni-credit-card text-red",
    component: <WithdrawFunds/>,
    layout: "/admin",
  },
  {
    path: "/transfer-funds",
    name: "Transfer Funds",
    icon: "ni ni-send text-info",
    component: <TransferFunds/>,
    layout: "/admin",
  },
  {
    path: "/find-atm",
    name: "ATM Listing",
    icon: "ni ni-pin-3 text-pink",
    component: <ATM/>,
    layout: "/admin",
  },
  {
    path: "/profile",
    name: "Profile",
    icon: "ni ni-circle-08 text-red",
    component: <Profile/>,
    layout: "/admin",
    invisible: true,
  },
];


export default routes;