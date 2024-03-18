import { Route, Routes } from "react-router-dom"
import Pocetna from "./pages/Pocetna"
import { RoutesNames } from "./constants"
import NavBar from "./components/NavBar";
import Programi from "./pages/programi/Programi";

function App() {
  return (
    <>
   
    <NavBar/>

      <Routes>
        <>
          <Route path={RoutesNames.HOME} element={<Pocetna />} />
          <Route path={RoutesNames.PROGRAMI_PREGELD} element={<Programi />} />
        </>
      </Routes>
    </>
  )
}
export default App;