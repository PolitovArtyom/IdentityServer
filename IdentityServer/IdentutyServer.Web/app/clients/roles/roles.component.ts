import { Input, Component } from '@angular/core';
import { Router } from '@angular/router';

import { RoleService, AlertService } from '../../services/index';
import { Role } from '../../models/index';

@Component({
    selector: 'roles-list',
    moduleId: module.id,
    providers: [RoleService],
    templateUrl: 'roles.component.html'
})

export class RolesComponent {
    _clientId: number;

    @Input()
    set clientId(id: number) {
        if (id) {
            this._clientId = 0;
            this.loadRoles(id);
        }
    }

    loading: boolean = false;
    roles: Array<Role> = new Array<Role>();
    activeRole: Role;

    constructor(
        private router: Router,
        private alertService: AlertService,
        private roleService: RoleService) {
    }

    loadRoles(clientId: number): void {
        this.loading = true;
        this.roleService.loadClientRoles(clientId)
            .subscribe(
            data => {
                this.loading = false;
                this.roles = data;
            },
            error => {
                this.alertService.error(error);
                this.loading = false;
                this.roles = new Array<Role>();
            });
    }

    setActiveRole(colId: number): void {
        this.activeRole = this.roles[colId];
       
       
    }

}

