import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthService } from '../../services/AuthService';

@Component({
  selector: 'app-left-menu',
  imports: [CommonModule, RouterModule],
  templateUrl: './left-menu.html',
  styleUrl: './left-menu.scss',
})
export class LeftMenu {

  authService = inject(AuthService);

  onLogout(){
    this.authService.logout();
  }
}
