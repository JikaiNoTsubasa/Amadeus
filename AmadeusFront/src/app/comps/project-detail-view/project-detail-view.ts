import { Component, Input, inject, OnInit, OnChanges } from '@angular/core';
import { Project } from '../../models/Project';
import { DatePipe } from '@angular/common';
import { TabNav, NavTab } from '../tab-nav/tab-nav';
import { ProjectTasksList } from '../project-tasks-list/project-tasks-list';
import { StorageService } from '../../services/storage.service';

@Component({
  selector: 'app-project-detail-view',
  imports: [DatePipe, TabNav, ProjectTasksList],
  templateUrl: './project-detail-view.html',
  styleUrl: './project-detail-view.scss',
})
export class ProjectDetailView implements OnInit, OnChanges {
  @Input() project!: Project;

  private storageService = inject(StorageService);

  activeTabId: string = 'overview';

  tabs: NavTab[] = [
    { id: 'overview', label: 'Overview', icon: 'fa-info-circle' },
    { id: 'tasks', label: 'Tasks', icon: 'fa-tasks' }
    // Ajoutez facilement de nouveaux tabs ici:
    // { id: 'phases', label: 'Phases', icon: 'fa-list' },
    // { id: 'files', label: 'Files', icon: 'fa-file' },
  ];

  ngOnInit(): void {
    this.loadActiveTab();
  }

  ngOnChanges(): void {
    if (this.project) {
      this.loadActiveTab();
    }
  }

  onTabChange(tabId: string): void {
    this.activeTabId = tabId;
    this.saveActiveTab();
  }

  private loadActiveTab(): void {
    if (!this.project?.id) return;

    const savedTab = this.storageService.get<string>(
      'project_detail',
      `activeTab_${this.project.id}`,
      'overview'
    );

    const tabExists = this.tabs.some(tab => tab.id === savedTab);
    this.activeTabId = tabExists ? savedTab! : 'overview';
  }

  private saveActiveTab(): void {
    if (!this.project?.id) return;

    this.storageService.set(
      'project_detail',
      `activeTab_${this.project.id}`,
      this.activeTabId
    );
  }
}
