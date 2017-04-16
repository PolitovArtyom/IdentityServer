import { Component } from "@angular/core";
import { Router } from '@angular/router';
import { UserService } from "../services/index";

import { Observable } from "rxjs/Observable";

@Component({
    moduleId: module.id,
    selector: "myheader",
    templateUrl: "header.component.html"
})
export class HeaderComponent {
    authentificated = false;
    userName: string;

    constructor(private userService: UserService,
        private router: Router) {
        userService.authenticated
            .subscribe((value: boolean) => this.checkUserStatus(value));
    }

    private checkUserStatus(status: boolean): void {
        if (status) {
            this.authentificated = true;
            const userName = localStorage.getItem("userName");
            if (userName)
                this.userName = userName;
        } else {
            this.authentificated = false;
            this.userName = null;
            this.router.navigate(['/login']);
        }
    }

    logout() {
        this.userService.logout();
    }
}
