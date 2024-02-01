import React, { useEffect, useState } from "react";
import useIsAuthenticated from 'react-auth-kit/hooks/useIsAuthenticated';
import useAuthUser from 'react-auth-kit/hooks/useAuthUser';
import {
  Button,
  Container,
  Row,
  Col,
} from "reactstrap";

const Dashboard = () => {
  const isAuthenticated = useIsAuthenticated();
  const auth = useAuthUser();

  // Introduce state to store the user
  const [user, setUser] = useState(null);

  useEffect(() => {
    // Check if the user is authenticated
    if (isAuthenticated()) {
      // Update the state with the user information
      setUser(auth.user);
    }
  }, [isAuthenticated, auth.user]);

  return (
    <>
      <div
        className="header pb-8 pt-5 pt-lg-8 d-flex align-items-center"
        style={{
          minHeight: "600px",
          backgroundImage:
            "url(" + require("../../assets/img/theme/profile-cover.jpg") + ")",
          backgroundSize: "cover",
          backgroundPosition: "center top",
        }}
      >
        {/* Mask */}
        <span className="mask bg-gradient-default opacity-8" />
        {/* Header container */}
        <Container className="d-flex align-items-center" fluid>
          <Row>
            <Col lg="7" md="10">
              <h1 className="display-2 text-white">Hello {auth.user}</h1>
              <p className="text-white mt-0 mb-5">
                Welcome to <b>EzyCash Manager!</b> Your gateway to seamless self-service banking. 
                Enjoy the freedom to 
                <a href="/admin/deposit-funds"> deposit</a>, 
                <a href="/admin/withdraw-funds"> withdraw</a> and 
                <a href="/admin/transfer-funds"> transfer</a> funds with utmost convenience.
              </p>
              <Button
                color="info"
                href="/admin/accounts"
              
              >
                My accounts
              </Button>

              <Button
                color="info"
                type="button"
                href="/admin/find-atm"

                outline
                
              >
                Cash Machines
              </Button>
                
            </Col>
          </Row>
        </Container>
      </div>
    </>
  );
};

export default Dashboard;
