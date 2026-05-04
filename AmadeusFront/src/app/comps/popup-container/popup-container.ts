import { Component, inject, OnInit } from '@angular/core';
import { PopupService } from '../../services/popup.service';
import { PopupInstance } from '../../models/PopupConfig';
import { Popup } from '../popup/popup';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-popup-container',
  imports: [Popup, AsyncPipe],
  templateUrl: './popup-container.html',
  styleUrl: './popup-container.scss',
})
export class PopupContainer implements OnInit {
  private popupService = inject(PopupService);

  popups$!: Observable<PopupInstance[]>;

  ngOnInit(): void {
    this.popups$ = this.popupService.getPopups();
  }
}
