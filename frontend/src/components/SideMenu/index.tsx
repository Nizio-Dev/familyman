import { AccountBox, Assignment, Group, Logout } from "@mui/icons-material";
import { Avatar, Button, CssBaseline, Divider, List, ListItem, ListItemButton, ListItemIcon, ListItemText } from "@mui/material";
import Box from "@mui/material/Box";
import Drawer, { DrawerProps } from "@mui/material/Drawer";
import { useNavigate } from "react-router-dom";

const menuItems: string[] = ['Profile', 'Todos', 'Families'];
const menuIcons: JSX.Element[] = [<AccountBox/>, <Assignment/>, <Group/>]

const menuWidth = 200;


const SideMenu = (props: DrawerProps) =>{

    let navigate = useNavigate(); 

    return(
        <Box flexGrow={1}>
        <CssBaseline />
            <Drawer
                variant="permanent"
                anchor="left"
                sx={{
                    width: menuWidth,
                    '& .MuiDrawer-paper': {
                        width: menuWidth,
                        bgcolor: 'secondary.main'
                    }
                }}
            >
                <Box p={4} display={'flex'} alignItems={'center'} justifyContent={'center'}>
                    <Button>
                        <Avatar>

                        </Avatar>
                    </Button>
                </Box>
                <Divider/>
                <List>
                {menuItems.map((name, index) => (
                    <ListItem button key={name}>
                        <ListItemIcon>
                            {menuIcons[index]}
                        </ListItemIcon>
                        <ListItemText primary={name} />
                    </ListItem>
                ))}
                    <Divider/>
                    <ListItemButton onClick={() => navigate('/')}>
                        <ListItemIcon>
                            <Logout/>
                        </ListItemIcon>
                        <ListItemText primary={'Logout'} />
                    </ListItemButton>
                </List>
            </Drawer>
        </Box>
    )
}


export default SideMenu;