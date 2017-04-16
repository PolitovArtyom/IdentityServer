import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

import { Client } from '../models/index';

@Injectable()
export class ClientService {
    constructor(private http: Http) { }
    private uri: string = "http://localhost:49536/";

    getClients() {
        let requestOptions: RequestOptions = this.getOptions();
        return (this.http.get(this.uri + '/api/client', requestOptions));
    }

    getClient(id: string): Observable<Client> {
        let requestOptions: RequestOptions = this.getOptions();
        return this.http.get(this.uri + '/api/client/' + id, requestOptions)
            .map((response: Response) =>
            {
                let client = <Client>response.json();
                return client;
            });
    }

    updateClient(client: Client): Observable<Response> {
        let requestOptions: RequestOptions = this.getOptions();
        return this.http.put(this.uri + '/api/client/', client, requestOptions);
    }

    addClient(client: Client): Observable<Response> {
        let requestOptions: RequestOptions = this.getOptions();
        return this.http.post(this.uri + '/api/client/', client, requestOptions);
    }

    deleteClient(clientId: string): Observable<Response> {
        let requestOptions: RequestOptions = this.getOptions();
        return this.http.delete(this.uri + '/api/client/' + clientId, requestOptions);
    }

    private getOptions(): RequestOptions {
        var user = localStorage.getItem('userToken').toString();
        
        let headers: Headers = new Headers();
        headers.append('Authorization', "Bearer " + user);
        let requestOptions: RequestOptions = new RequestOptions({
            headers: headers
        });

        return requestOptions;
    }

}
