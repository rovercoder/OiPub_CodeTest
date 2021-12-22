import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from 'react-router-dom';
import Home from './home';
import Books from './books/Books';
const Index = () => {
    return(
        <Router>
            <Route exact path="/" component={ Home } />
            <Route path = "/books" component={ Books } />
        </Router>
    );
};
export default Index;