import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import 'rxjs/add/operator/map'
import Rx1 = require("../../node_modules/rxjs/Rx");

import { User } from '../models/index';


@Injectable()
export class UserService {
    constructor(private http: Http) { }
    public authenticated = new Rx1.BehaviorSubject(null);

    private uri: string = "http://localhost:49536";

    login(user: User) {
        let headers: Headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        let requestOptions: RequestOptions = new RequestOptions({
            headers: headers
        });

        let data = "grant_type=password&username=" + user.userName + "&password=" + user.password;

        return this.http.post(this.uri + '/token', data, requestOptions)
        .map((response: Response) => {
            // login successful if there's a jwt token in the response
            let responseUser = response.json();
            if (responseUser && responseUser.access_token) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('userToken', responseUser.access_token);
                localStorage.setItem('userName', user.userName);
                this.authenticated.next(true);
            }
        });
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('userToken');
        localStorage.removeItem('userName');
        this.authenticated.next(false);
    }

    register(user: User) {
        return this.http.post(this.uri +'/api/account/Register', user);
    }


    private jwt() {
        // create authorization header with jwt token
        let currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser && currentUser.token) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
            return new RequestOptions({ headers: headers });
        }
    }
}
