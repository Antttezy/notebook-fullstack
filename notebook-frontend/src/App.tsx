import React from 'react';
import Home from './pages/Home';
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import NotFound from './pages/NotFound';
import AddNote from './pages/AddNote';

function App() {

  const router = createBrowserRouter([
    {
      path: "/",
      element: <Home />
    },
    {
      path: '/add',
      element: <AddNote />
    },
    {
      path: '*',
      element: <NotFound />
    }
  ]);


  return (
    <div className='wrapper'>
      <RouterProvider router={router} />
    </div>
  );
}

export default App;
