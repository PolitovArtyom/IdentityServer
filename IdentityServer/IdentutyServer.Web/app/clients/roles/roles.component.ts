import { Input, Component } from '@angular/core';
import { Router } from '@angular/router';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

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
            this._clientId = id;
            this.loadRoles();
        }
    }

    loading: boolean = false;
    roleRows: Array<RoleRow> = new Array<RoleRow>();


    constructor(
        private router: Router,
        private alertService: AlertService,
        private roleService: RoleService) {
    }

    loadRoles(): void {
        this.loading = true;
        this.roleService.loadClientRoles(this._clientId)
            .subscribe(
            data => {
                this.loading = false;
                this.roleRows = data.map((role: Role) => {
                    let mapped = new RoleRow();
                    mapped.role = role;
                    return mapped;
                });;
            },
            error => this.processError(error));
    }

    newRole(): void {
        let newRoleRow = new RoleRow();
        newRoleRow.isLocked = false;
        newRoleRow.role = new Role();
        newRoleRow.role.clientId = this._clientId;
        this.roleRows.push(newRoleRow);
    }

    saveRole(roleRow: RoleRow): void {
        roleRow.isLocked = true;
        this.loading = true;
        let response: Observable<Response>;
        if (roleRow.role.id)
            response = this.roleService.updateRole(roleRow.role);
        else {
            response = this.roleService.addRole(roleRow.role);
        }

        response.subscribe(
            data => {
                this.loading = false;
                this.loadRoles()
            },
            error => this.processError(error));
    }

    cancel(): void{
        this.loadRoles();
    }

    deleteRole(roleId: number): void {
        this.roleService.deleteRole(roleId)
            .subscribe((data) => this.loadRoles(), error => this.processError(error));
    }

    private processError(error: any): void {
        this.alertService.error(error);
        this.loading = false;
        this.roleRows = new Array<RoleRow>();
    }


}

class RoleRow {
    role: Role;
    isLocked: boolean = true;
}

