import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { ClientService, AlertService } from '../../services/index';
import { Client } from '../../models/index';

@Component({
    selector: 'my-app',
    moduleId: module.id,
    providers: [ClientService],
    templateUrl: 'clientList.component.html'
})
export class ClientListComponent {
    loading: boolean = false;
    clients: Array<Client> = new Array<Client>();

    constructor(
        private router: Router,
        private alertService: AlertService,
        private clientService: ClientService) {
        this.loadClients();
    }

loadClients(): void{
        this.loading = true;
        this.clientService.getClients()
            .subscribe(
                data => {
                    this.loading = false;
                    this.clients = data;
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                    this.clients = new Array<Client>();
                });
}

deleteClient(clientId: string): void {
    this.loading = true;
    this.clientService.deleteClient(clientId)
        .subscribe(
        data => {
            this.loading = false;
            this.loadClients();
        },
        error => {
            this.alertService.error(error);
            this.loading = false;
        });
}
}
