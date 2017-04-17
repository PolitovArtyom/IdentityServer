import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

import { Client } from '../models/index';
import { ServiceBase } from '../services/base.service';

@Injectable()
export class ClientService extends ServiceBase{
    constructor(private http: Http) {
        super();
     }
    private uri: string = "http://localhost:49536/";

    getClients(): Observable<Client[]> {
        let requestOptions: RequestOptions = super.getAuthHeader();
        return this.http.get(this.uri + '/api/client', requestOptions)
        .map((response: Response) =>
            {
                let clients = <Client[]> response.json();
                return clients;
            });
    }

    getClient(id: string): Observable<Client> {
        let requestOptions: RequestOptions = super.getAuthHeader();
        return this.http.get(this.uri + '/api/client/' + id, requestOptions)
            .map((response: Response) =>
            {
                let client = <Client>response.json();
                return client;
            });
    }

    updateClient(client: Client): Observable<Response> {
        let requestOptions: RequestOptions = super.getAuthHeader();
        return this.http.put(this.uri + '/api/client/', client, requestOptions);
    }

    addClient(client: Client): Observable<Response> {
        let requestOptions: RequestOptions = super.getAuthHeader();
        return this.http.post(this.uri + '/api/client/', client, requestOptions);
    }

    deleteClient(clientId: string): Observable<Response> {
        let requestOptions: RequestOptions = super.getAuthHeader();
        return this.http.delete(this.uri + '/api/client/' + clientId, requestOptions);
    }
}
