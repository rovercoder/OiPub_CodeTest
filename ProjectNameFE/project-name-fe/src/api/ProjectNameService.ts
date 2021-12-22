import { API_ROOT } from './API-config';
import * as axios from 'axios';

const headers = {
    //'Authorization': 'Bearer my-token'
};

class BooksRequest {
    title: string;
    sortByColumn: string;
}

function getBooksList(request: BooksRequest) {
    return axios
        .get(`${API_ROOT}/api/papers`, { headers });
        //.then(response => this.setState({ totalReactPackages: response.data.total }));
}
