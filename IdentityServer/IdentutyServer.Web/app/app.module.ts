import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { routing } from './app.routing';

import { AlertComponent, HeaderComponent} from './directives/index';
import { ClientListComponent, ClientComponent} from './clients/index';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';

import { UserService, AlertService, ClientService } from './services/index';
import {AuthGuard} from "./guards/index";

import { AppComponent } from './app.component';

@NgModule({
    imports:
        [BrowserModule,
        FormsModule,
        HttpModule,
        routing],
    declarations: [
        AppComponent,
        SignupComponent,
        LoginComponent,
        AlertComponent,
        ClientListComponent,
        ClientComponent,
        HeaderComponent
    ],
    bootstrap: [AppComponent],
    providers: [
        AuthGuard,
        UserService,
        AlertService,
        ClientService    ]
}
)
export class AppModule { }