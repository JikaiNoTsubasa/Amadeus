import { Component, inject } from '@angular/core';
import { AmaService } from '../../services/AmaService';
import { StorageService } from '../../services/storage.service';
import { Project } from '../../models/Project';
import { Tab, TabType } from '../../models/Tab';
import { TabState } from '../../models/TabState';
import { TabContainer } from "../../comps/tab-container/tab-container";
import { ProjectListView } from "../../comps/project-list-view/project-list-view";
import { ProjectDetailView } from "../../comps/project-detail-view/project-detail-view";

@Component({
  selector: 'app-myprojects',
  imports: [TabContainer, ProjectListView, ProjectDetailView],
  templateUrl: './myprojects.html',
  styleUrl: './myprojects.scss',
})
export class MyProjects {

  amaService = inject(AmaService);
  storageService = inject(StorageService);

  loadingMyProjects: boolean = false;
  myProjects: Project[] = [];
  tabs: Tab[] = [];
  isFirstLoad: boolean = true;

  TabType = TabType;

  ngOnInit(): void {
    this.initializeTabs();
    this.refreshMyProjects();
  }

  ngOnDestroy(): void {
    this.saveTabState();
  }

  refreshMyProjects(): void {
    this.loadingMyProjects = true;
    this.amaService.fetchMyProjects().subscribe({
      next: (projects) => {
        this.myProjects = projects;
        this.loadingMyProjects = false;
        if (this.isFirstLoad) {
          this.restoreTabState();
          this.isFirstLoad = false;
        }
      },
      error: (error) => {
        console.error("Error fetching my projects:", error);
        this.loadingMyProjects = false;
      }
    });
  }

  onProjectOpen(project: Project): void {
    const existingTab = this.tabs.find(
      t => t.type === TabType.PROJECT_DETAIL && t.data?.id === project.id
    );

    if (existingTab) {
      this.switchTab(existingTab.id);
      this.refreshProjectDetail(existingTab);
    } else {
      const newTab: Tab = {
        id: `project_${project.id}_${Date.now()}`,
        type: TabType.PROJECT_DETAIL,
        label: project.name,
        closeable: true,
        active: false,
        data: project
      };
      this.tabs.push(newTab);
      this.switchTab(newTab.id);
      this.saveTabState();
      this.refreshProjectDetail(newTab);
    }
  }

  onTabChanged(tabId: string): void {
    this.switchTab(tabId);
    this.saveTabState();

    const tab = this.tabs.find(t => t.id === tabId);
    if (!tab) return;

    if (tab.type === TabType.PROJECT_LIST) {
      this.refreshMyProjects();
    } else if (tab.type === TabType.PROJECT_DETAIL && tab.data?.id) {
      this.refreshProjectDetail(tab);
    }
  }

  refreshProjectDetail(tab: Tab): void {
    const projectId = tab.data?.id;
    if (!projectId) return;

    this.amaService.fetchProjectById(projectId).subscribe({
      next: (project) => {
        tab.data = project;
        tab.label = project.name;

        const index = this.myProjects.findIndex(p => p.id === project.id);
        if (index !== -1) {
          this.myProjects[index] = project;
        }
      },
      error: (error) => {
        console.error(`Error fetching project ${projectId}:`, error);
      }
    });
  }

  onTabClosed(tabId: string): void {
    const tabIndex = this.tabs.findIndex(t => t.id === tabId);
    if (tabIndex === -1) return;

    const wasActive = this.tabs[tabIndex].active;
    this.tabs.splice(tabIndex, 1);

    if (wasActive && this.tabs.length > 0) {
      const newActiveIndex = Math.max(0, tabIndex - 1);
      this.tabs[newActiveIndex].active = true;
    }

    this.saveTabState();
  }

  private initializeTabs(): void {
    this.tabs = [{
      id: 'all_projects',
      type: TabType.PROJECT_LIST,
      label: 'All Projects',
      closeable: false,
      active: true
    }];
  }

  private switchTab(tabId: string): void {
    this.tabs.forEach(tab => {
      tab.active = tab.id === tabId;
    });
  }

  private saveTabState(): void {
    const state: TabState = {
      activeTabId: this.tabs.find(t => t.active)?.id || 'all_projects',
      tabs: this.tabs
        .filter(t => t.type === TabType.PROJECT_DETAIL)
        .map(t => ({
          id: t.id,
          type: t.type,
          label: t.label,
          projectId: t.data?.id
        }))
    };
    this.storageService.set('myprojects', 'tabState', state);
  }

  private restoreTabState(): void {
    const state = this.storageService.get<TabState>('myprojects', 'tabState');
    if (!state || !state.tabs || state.tabs.length === 0) return;

    state.tabs.forEach(savedTab => {
      if (savedTab.type === TabType.PROJECT_DETAIL && savedTab.projectId) {
        const project = this.myProjects.find(p => p.id === savedTab.projectId);
        if (project) {
          const tab: Tab = {
            id: savedTab.id,
            type: TabType.PROJECT_DETAIL,
            label: project.name,
            closeable: true,
            active: false,
            data: project
          };
          this.tabs.push(tab);

          this.amaService.fetchProjectById(savedTab.projectId).subscribe({
            next: (freshProject) => {
              tab.data = freshProject;
              tab.label = freshProject.name;
            },
            error: (error) => {
              console.error(`Error restoring project ${savedTab.projectId}:`, error);
            }
          });
        }
      }
    });

    if (state.activeTabId) {
      this.switchTab(state.activeTabId);
    }
  }

  get activeTab(): Tab | undefined {
    return this.tabs.find(t => t.active);
  }
}
