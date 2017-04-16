import { Component, OnInit } from '@angular/core';
import { AlertService } from '../services/index';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

@Component({
    moduleId: module.id,
    selector: 'alert',
    templateUrl: 'alert.component.html'
})

export class AlertComponent {
    message: any;

    constructor(private alertService: AlertService) { }

    ngOnInit() {
        this.alertService.getMessage().subscribe(message =>  this.message = message );
    }


   
}