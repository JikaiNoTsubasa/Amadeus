import { inject, Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AmaService } from "./AmaService";
import { jwtDecode } from "jwt-decode";
import { LocalUser } from "../models/LocalUser";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  router = inject(Router);
  amaService = inject(AmaService);

  login(email: string, password: string) {
    this.amaService.authenticate(email, password).subscribe({
        next: (response) => {
          sessionStorage.setItem('token', response.access_token);
          let jwt = jwtDecode<any>(response.access_token);
          let user = new LocalUser();
          user.id = jwt.userid;
          user.name = jwt.username;
          user.email = jwt.email;
          sessionStorage.setItem('user', JSON.stringify(user));
          
          this.router.navigate(['']);
        },
        error: (error) => {
            console.error('Login failed', error);
        }
    });
  }

  logout() {
    sessionStorage.removeItem('user');
    sessionStorage.removeItem('token');
    this.router.navigate(['login']);
  }

  isLoggedIn() {
    let user = sessionStorage.getItem('user');
    if (user) {
      return true;
    } else {
      return false;
    }
  }
}