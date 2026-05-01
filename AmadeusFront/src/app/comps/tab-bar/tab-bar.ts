import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Tab } from '../../models/Tab';

@Component({
  selector: 'app-tab-bar',
  imports: [],
  templateUrl: './tab-bar.html',
  styleUrl: './tab-bar.scss',
})
export class TabBar {
  @Input() tabs: Tab[] = [];
  @Output() tabSelect = new EventEmitter<string>();
  @Output() tabClose = new EventEmitter<string>();

  selectTab(tab: Tab): void {
    if (!tab.active) {
      this.tabSelect.emit(tab.id);
    }
  }

  closeTab(event: Event, tab: Tab): void {
    event.stopPropagation();
    if (tab.closeable) {
      this.tabClose.emit(tab.id);
    }
  }
}
