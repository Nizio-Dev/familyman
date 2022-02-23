import { BrowserRouter, Route, Routes } from 'react-router-dom';
import GuestView from '../pages/Guest';
import UserView from '../pages/User';

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/*" element={<GuestView/>}/>
        <Route path="/user/*" element={<UserView/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
