import { Component} from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Response } from '@angular/http';
import { Subscription } from 'rxjs/Subscription';
import { Observable } from 'rxjs/Observable';

import { AlertService, ClientService } from '../../services/index';
import { Client } from '../../models/index';


@Component({
    selector: 'my-app',
    moduleId: module.id,
    providers: [ClientService],
    templateUrl: 'client.component.html'
})
export class ClientComponent{
    loading: boolean = false;
    client: Client = new Client();

    constructor(
        private router: Router,
        private alertService:AlertService,
        private clientService: ClientService,
        private activatedRoute: ActivatedRoute) {
      
         activatedRoute.queryParams.subscribe(
             (queryParam: any) => {
                 if (queryParam && queryParam.id && queryParam.id !== "null")
                    this.setActiveClient(queryParam.id);
            });
    }

setActiveClient(id: string): void{
        this.loading = true;
        this.clientService.getClient(id)
            .subscribe(
                data => {
                    this.loading = false;
                    this.client = data;
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                    this.client = new Client();
                });
}

save(): void {
        this.loading = true;
        let response: Observable<Response>;
        if (this.client.id)
            response = this.clientService.updateClient(this.client);
        else {
            response = this.clientService.addClient(this.client);
        }

        response.subscribe(
            data => {
                this.loading = false;
                this.alertService.success("Success. Redirecting...");
                setTimeout(() => this.router.navigate(['/clients']), 2000);
            },
            error => {
                this.alertService.error(error);
                this.loading = false;
                this.client = new Client();
            });

    }
}
