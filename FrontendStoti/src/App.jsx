import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"
import NavBar from "./components/NavBar"
import Programi from "./pages/programi/Programi"

import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css';
import ProgramiDodaj from "./pages/programi/ProgramiDodaj"
import ProgramiPromjeni from "./pages/programi/ProgramiPromjeni"

function App() {
  return (
    <>
   
    <NavBar/>

      <Routes>
        <>
          <Route path={RoutesNames.HOME} element={<Pocetna />} />
          <Route path={RoutesNames.PROGRAMI_PREGELD} element={<Programi />} />
          <Route path={RoutesNames.PROGRAMI_NOVI} element={<ProgramiDodaj />} />
          <Route path={RoutesNames.PROGRAMI_PROMJENI} element={<ProgramiPromjeni />} />
        </>
      </Routes>
    </>
  )
}

export default App