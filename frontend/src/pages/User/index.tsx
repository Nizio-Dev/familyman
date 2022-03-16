import { Box, Container } from "@mui/material"
import { Route, Routes } from "react-router-dom";
import SideMenu from "../../components/SideMenu"

const UserView = () =>{


    return(
        <Box display={'flex'} height={'100%'}>
          <SideMenu/>
          <Container disableGutters>
            <Routes>
              <Route/>
            </Routes>
          </Container>
        </Box>
    )
}

export default UserView;