import { Routes, RouterModule } from '@angular/router';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { ClientListComponent, ClientComponent } from './clients/index';
import { AuthGuard } from './guards/index';

const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'clients', component: ClientListComponent, canActivate: [AuthGuard] },
    { path: 'clients/:id', component: ClientComponent, canActivate: [AuthGuard] },
   // { path: '**', redirectTo: 'login' }
];

export const routing = RouterModule.forRoot(appRoutes);