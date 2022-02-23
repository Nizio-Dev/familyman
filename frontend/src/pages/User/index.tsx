import { Box, Container } from "@mui/material"
import SideMenu from "../../components/SideMenu"

const UserView = () =>{


    return(
        <Box display={'flex'} height={'100%'}>
          <SideMenu/>
          <Container disableGutters>
            
          </Container>
        </Box>
    )
}

export default UserView;