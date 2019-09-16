import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router } from '@angular/router';
import { AuthorizationService } from './authorization.service';

@Injectable({providedIn: 'root'})
export class AuthGuard implements CanActivate {
    constructor(private authService: AuthorizationService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const permission = route.data.permission as string;
debugger
        if (this.authService.hasPermission(permission)) {
            return true;
        }

        return this.router.navigate(['/access-denied']);
    }
}
