import { AccountBox, Assignment, Group, Logout } from '@mui/icons-material';
import { Avatar, Button, CssBaseline, Divider, List, ListItem, ListItemButton, ListItemIcon, ListItemText } from '@mui/material';
import Box from '@mui/material/Box';
import Drawer, { DrawerProps } from '@mui/material/Drawer';
import { NavLink, useNavigate } from 'react-router-dom';

const menuItems: string[] = ['Profile', 'Todos', 'Families'];
const menuIcons: JSX.Element[] = [<AccountBox/>, <Assignment/>, <Group/>]

const SideMenu = (props: DrawerProps) =>{

    let navigate = useNavigate(); 


    return(
        <Box 
        flexGrow={1}>
        <CssBaseline />
            <Drawer
                variant='permanent'
                anchor='left'
                sx={{
                    '& .MuiDrawer-paper':{
                        backgroundColor: 'primary.main'   
                    }
                }}>
                <Box height={100} p={2} display={'flex'} alignItems={'center'} justifyContent={'center'}>
                    <Button disableRipple>
                        <Avatar/>
                    </Button>
                </Box>
                <Divider/>
                <List sx={{p: 2}}>
                {menuItems.map((name, index) => (
                    <NavLink to='profile'>
                        <ListItem button key={name}>
                            <ListItemIcon>
                                {menuIcons[index]}
                            </ListItemIcon>
                            <ListItemText primary={name} />
                        </ListItem>
                    </NavLink>
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