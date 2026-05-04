import { Component, Input, Output, EventEmitter } from '@angular/core';

export interface NavTab {
  id: string;
  label: string;
  icon?: string;
}

@Component({
  selector: 'app-tab-nav',
  imports: [],
  templateUrl: './tab-nav.html',
  styleUrl: './tab-nav.scss',
})
export class TabNav {
  @Input() tabs: NavTab[] = [];
  @Input() activeTabId: string = '';
  @Output() tabChange = new EventEmitter<string>();

  selectTab(tabId: string): void {
    if (this.activeTabId !== tabId) {
      this.tabChange.emit(tabId);
    }
  }
}
