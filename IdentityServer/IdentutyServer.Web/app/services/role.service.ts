import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

import { Role } from '../models/index';
import { ServiceBase } from '../services/base.service';

@Injectable()
export class RoleService extends ServiceBase {
    constructor(private http: Http) {
        super();
     }
     //TODO How to inject service uri?
    private uri: string = "http://localhost:49536/";

    loadClientRoles(clientId: number): Observable<Role[]> {
        let requestOptions: RequestOptions = super.getAuthHeader();
        return this.http.get(this.uri + '/api/role?clientId=' + clientId, requestOptions)
        .map((response: Response) =>
        {
            let roles =  <Role[]> response.json();
            return roles;
        });
    }


}
