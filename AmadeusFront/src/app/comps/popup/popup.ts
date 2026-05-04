import { Component, Input, Output, EventEmitter, ViewChild, ViewContainerRef, ComponentRef, OnInit, OnDestroy, HostListener, inject } from '@angular/core';
import { PopupInstance, PopupType, PopupSize } from '../../models/PopupConfig';
import { NgTemplateOutlet } from '@angular/common';
import { PopupService } from '../../services/popup.service';

@Component({
  selector: 'app-popup',
  imports: [NgTemplateOutlet],
  templateUrl: './popup.html',
  styleUrl: './popup.scss',
})
export class Popup implements OnInit, OnDestroy {
  @Input() popup!: PopupInstance;
  @Output() closed = new EventEmitter<string>();

  @ViewChild('dynamicComponent', { read: ViewContainerRef }) dynamicComponentContainer?: ViewContainerRef;

  private popupService = inject(PopupService);
  private componentRef?: ComponentRef<any>;

  PopupType = PopupType;
  PopupSize = PopupSize;

  ngOnInit(): void {
    if (this.popup.config.component && this.dynamicComponentContainer) {
      this.loadComponent();
    }
  }

  ngOnDestroy(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }
  }

  @HostListener('document:keydown.escape')
  handleEscape(): void {
    if (this.popup.config.closeOnEscape) {
      this.close();
    }
  }

  close(): void {
    this.popupService.close(this.popup.id);
  }

  onBackdropClick(): void {
    if (this.popup.config.closeOnBackdrop) {
      this.close();
    }
  }

  onContentClick(event: Event): void {
    event.stopPropagation();
  }

  async onButtonClick(action: () => void | Promise<void>): Promise<void> {
    await action();
    this.close();
  }

  private loadComponent(): void {
    if (!this.popup.config.component || !this.dynamicComponentContainer) return;

    this.dynamicComponentContainer.clear();
    this.componentRef = this.dynamicComponentContainer.createComponent(this.popup.config.component);

    if (this.popup.config.data && this.componentRef.instance) {
      Object.assign(this.componentRef.instance, this.popup.config.data);
    }
  }

  getIconClass(): string {
    switch (this.popup.config.type) {
      case PopupType.INFO:
        return 'fa fa-info-circle';
      case PopupType.WARNING:
        return 'fa fa-exclamation-triangle';
      case PopupType.ERROR:
        return 'fa fa-times-circle';
      case PopupType.SUCCESS:
        return 'fa fa-check-circle';
      case PopupType.CONFIRM:
        return 'fa fa-question-circle';
      default:
        return '';
    }
  }

  getTypeClass(): string {
    return `popup-${this.popup.config.type.toLowerCase()}`;
  }

  getSizeClass(): string {
    return `popup-size-${this.popup.config.size?.toLowerCase()}`;
  }
}
