import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  private readonly tabId: string;

  constructor() {
    let tabId = sessionStorage.getItem('tabId');
    if (!tabId) {
      tabId = `tab_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`;
      sessionStorage.setItem('tabId', tabId);
    }
    this.tabId = tabId;
  }

  set<T>(namespace: string, key: string, data: T): void {
    const storageKey = this.buildKey(namespace, key);
    try {
      localStorage.setItem(storageKey, JSON.stringify(data));
    } catch (error) {
      console.error('Error saving to localStorage:', error);
    }
  }

  get<T>(namespace: string, key: string, defaultValue?: T): T | null {
    const storageKey = this.buildKey(namespace, key);
    try {
      const item = localStorage.getItem(storageKey);
      if (item === null) {
        return defaultValue !== undefined ? defaultValue : null;
      }
      return JSON.parse(item) as T;
    } catch (error) {
      console.error('Error reading from localStorage:', error);
      return defaultValue !== undefined ? defaultValue : null;
    }
  }

  remove(namespace: string, key: string): void {
    const storageKey = this.buildKey(namespace, key);
    localStorage.removeItem(storageKey);
  }

  clearNamespace(namespace: string): void {
    const prefix = `${this.tabId}_${namespace}_`;
    const keys = Object.keys(localStorage).filter(k => k.startsWith(prefix));
    keys.forEach(key => localStorage.removeItem(key));
  }

  private buildKey(namespace: string, key: string): string {
    return `${this.tabId}_${namespace}_${key}`;
  }
}
