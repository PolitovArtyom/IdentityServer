import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../services/index';
import { AlertService } from '../services/index';
import { User } from '../models/index';

@Component({
    selector: 'my-app',
    moduleId: module.id,
    providers: [UserService],
    templateUrl: 'signup.component.html'
})

export class SignupComponent {
    user: User = new User();
    loading = false;

    constructor(
        private router: Router,
        private userService: UserService,
        private alertService: AlertService)
        { }

    register() {
        this.loading = true;
        this.userService.register(this.user)
            .subscribe(
            data => {
                    this.loading = true;
                    this.alertService.success('Registration successful. Redirecting to login page...', true);
                setTimeout(() => this.router.navigate(['/login']), 2000);

            },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });

    }
}
