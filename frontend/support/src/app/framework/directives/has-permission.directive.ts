import { Directive, TemplateRef, ViewContainerRef, Input, OnInit } from '@angular/core';
import { AuthorizationService } from '../services/authorization.service';

// tslint:disable-next-line:directive-selector
@Directive({ selector: '[hasPermission]' })
export class HasPermissionDirective implements OnInit {

    @Input('hasPermission')permission: string;

    constructor(private service: AuthorizationService,
                private templateRef: TemplateRef<any>,
                private viewContainer: ViewContainerRef) {
    }

    ngOnInit(): void {
        if (this.service.hasPermission(this.permission)) {
            this.viewContainer.createEmbeddedView(this.templateRef);
        } else {
            this.viewContainer.clear();
        }
    }

}
