import {Headers, RequestOptions } from '@angular/http';

export class ServiceBase
{
        protected getAuthHeader(): RequestOptions {
        var user = localStorage.getItem('userToken').toString();
        
        let headers: Headers = new Headers();
        headers.append('Authorization', "Bearer " + user);
        let requestOptions: RequestOptions = new RequestOptions({
            headers: headers
        });

        return requestOptions;
    }
}