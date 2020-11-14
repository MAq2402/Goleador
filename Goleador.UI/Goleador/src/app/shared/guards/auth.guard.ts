import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    constructor(public auth: AuthService, public router: Router) { }
    canActivate(): boolean {
        console.log('xD');
        if (!this.auth.isLoggedIn()) {
            console.log('here');
            this.router.navigate(['login']);
            return false;
        }
        return true;
    }
}
