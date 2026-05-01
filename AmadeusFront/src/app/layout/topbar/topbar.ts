import { Component, HostListener, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { LocalUser } from '../../models/LocalUser';

@Component({
  selector: 'app-topbar',
  imports: [RouterLink],
  templateUrl: './topbar.html',
  styleUrl: './topbar.scss',
})
export class Topbar implements OnInit {
  userName: string = '';
  dropdownOpen = false;

  ngOnInit() {
    const raw = sessionStorage.getItem('user');
    if (raw) {
      const user: LocalUser = JSON.parse(raw);
      this.userName = user.name ?? '';
    }
  }

  toggleDropdown(event: MouseEvent) {
    event.stopPropagation();
    this.dropdownOpen = !this.dropdownOpen;
  }

  closeDropdown() {
    this.dropdownOpen = false;
  }

  @HostListener('document:click')
  onDocumentClick() {
    this.dropdownOpen = false;
  }
}
