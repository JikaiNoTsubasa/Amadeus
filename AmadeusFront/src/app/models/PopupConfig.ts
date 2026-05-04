import { TemplateRef, Type } from '@angular/core';

export interface PopupConfig {
  id?: string;
  type: PopupType;
  size?: PopupSize;
  title?: string;
  message?: string;
  component?: Type<any>;
  template?: TemplateRef<any>;
  data?: any;
  buttons?: PopupButton[];
  closeOnBackdrop?: boolean;
  closeOnEscape?: boolean;
  showCloseButton?: boolean;
}

export enum PopupType {
  INFO = 'INFO',
  WARNING = 'WARNING',
  ERROR = 'ERROR',
  SUCCESS = 'SUCCESS',
  CONFIRM = 'CONFIRM',
  CUSTOM = 'CUSTOM'
}

export enum PopupSize {
  SMALL = 'SMALL',
  MEDIUM = 'MEDIUM',
  LARGE = 'LARGE',
  FULLSCREEN = 'FULLSCREEN'
}

export interface PopupButton {
  label: string;
  type?: 'primary' | 'secondary' | 'danger';
  action: () => void | Promise<void>;
}

export interface PopupInstance {
  id: string;
  config: PopupConfig;
  visible: boolean;
}
