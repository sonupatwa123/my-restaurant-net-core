import 'bootstrap/dist/css/bootstrap.css';

import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router';
import { createBrowserHistory } from 'history';

// Create browser history to use in the Redux store
ReactDOM.render(
    <h1>Hello, world
        <h2>
            Hello this is header 2
        </h2>
    </h1>,

    document.getElementById('root')
);