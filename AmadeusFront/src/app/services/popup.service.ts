import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { PopupConfig, PopupInstance, PopupType, PopupSize, PopupButton } from '../models/PopupConfig';

@Injectable({
  providedIn: 'root'
})
export class PopupService {

  private popups$ = new BehaviorSubject<PopupInstance[]>([]);
  private idCounter = 0;

  constructor() { }

  getPopups(): Observable<PopupInstance[]> {
    return this.popups$.asObservable();
  }

  open(config: PopupConfig): string {
    const id = config.id || `popup_${++this.idCounter}`;

    const defaultConfig: Partial<PopupConfig> = {
      size: PopupSize.MEDIUM,
      closeOnBackdrop: true,
      closeOnEscape: true,
      showCloseButton: true,
      buttons: []
    };

    const popup: PopupInstance = {
      id,
      config: { ...defaultConfig, ...config, id },
      visible: true
    };

    const currentPopups = this.popups$.value;
    this.popups$.next([...currentPopups, popup]);

    return id;
  }

  close(id: string): void {
    const currentPopups = this.popups$.value;
    this.popups$.next(currentPopups.filter(p => p.id !== id));
  }

  closeAll(): void {
    this.popups$.next([]);
  }

  info(title: string, message: string, onClose?: () => void): string {
    return this.open({
      type: PopupType.INFO,
      title,
      message,
      buttons: [
        {
          label: 'OK',
          type: 'primary',
          action: () => {
            if (onClose) onClose();
          }
        }
      ]
    });
  }

  warning(title: string, message: string, onClose?: () => void): string {
    return this.open({
      type: PopupType.WARNING,
      title,
      message,
      buttons: [
        {
          label: 'OK',
          type: 'primary',
          action: () => {
            if (onClose) onClose();
          }
        }
      ]
    });
  }

  error(title: string, message: string, onClose?: () => void): string {
    return this.open({
      type: PopupType.ERROR,
      title,
      message,
      buttons: [
        {
          label: 'OK',
          type: 'danger',
          action: () => {
            if (onClose) onClose();
          }
        }
      ]
    });
  }

  success(title: string, message: string, onClose?: () => void): string {
    return this.open({
      type: PopupType.SUCCESS,
      title,
      message,
      buttons: [
        {
          label: 'OK',
          type: 'primary',
          action: () => {
            if (onClose) onClose();
          }
        }
      ]
    });
  }

  confirm(
    title: string,
    message: string,
    onConfirm: () => void | Promise<void>,
    onCancel?: () => void
  ): string {
    return this.open({
      type: PopupType.CONFIRM,
      title,
      message,
      closeOnBackdrop: false,
      buttons: [
        {
          label: 'Cancel',
          type: 'secondary',
          action: () => {
            if (onCancel) onCancel();
          }
        },
        {
          label: 'Confirm',
          type: 'primary',
          action: onConfirm
        }
      ]
    });
  }
}
