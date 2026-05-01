import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Tab } from '../../models/Tab';
import { TabBar } from '../tab-bar/tab-bar';

@Component({
  selector: 'app-tab-container',
  imports: [TabBar],
  templateUrl: './tab-container.html',
  styleUrl: './tab-container.scss',
})
export class TabContainer {
  @Input() tabs: Tab[] = [];
  @Output() tabChanged = new EventEmitter<string>();
  @Output() tabClosed = new EventEmitter<string>();

  get activeTab(): Tab | undefined {
    return this.tabs.find(t => t.active);
  }

  onTabSelect(tabId: string): void {
    this.tabChanged.emit(tabId);
  }

  onTabClose(tabId: string): void {
    this.tabClosed.emit(tabId);
  }
}
