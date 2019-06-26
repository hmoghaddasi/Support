import { Directive, TemplateRef, ViewContainerRef, Input, OnInit } from '@angular/core';
import { TokenStorageService } from '../services/token-storage.service';

// tslint:disable-next-line:directive-selector
@Directive({ selector: '[signed]' })
export class SignedDirective implements OnInit {
    constructor(private service: TokenStorageService,
                private templateRef: TemplateRef<any>,
                private viewContainer: ViewContainerRef) {
    }

    ngOnInit(): void {
        if (this.service.signed()) {
            this.viewContainer.createEmbeddedView(this.templateRef);
        } else {
            this.viewContainer.clear();
        }
    }

}
