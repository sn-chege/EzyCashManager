// reactstrap components
import {
  Button,
  // Card,
  // CardHeader,
  // CardBody,
  // FormGroup,
  // Form,
  // Input,
  Container,
  Row,
  Col,
} from "reactstrap";


const Profile = () => {
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
              <h1 className="display-2 text-white">Hello Jesse</h1>
              <p className="text-white mt-0 mb-5">
                Welcome to <b>EzyCash Manager!</b> Your gateway to seamless self-service banking. 
                Enjoy the freedom to 
                <a href=""> deposit</a>, 
                <a href=""> withdraw</a> and 
                <a href=""> transfer</a> funds with utmost convenience.
              </p>
              <Button
                color="info"
                href="#pablo"
                onClick={(e) => e.preventDefault()}
              >
                My accounts
              </Button>

              <Button
                color="info"
                type="button"
                outline
                onClick={(e) => e.preventDefault()}
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

export default Profile;

