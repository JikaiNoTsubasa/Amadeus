import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { DatePipe } from '@angular/common';
import { AmaService } from '../../services/AmaService';
import { Project } from '../../models/Project';
import { TodoTask } from '../../models/TodoTask';
import { Toolbar } from '../../layout/toolbar/toolbar';
import { LoadingBar } from '../../comps/loading-bar/loading-bar';
import { Todo } from '../../comps/todo/todo';

type TabId = 'summary' | 'tasks' | 'documents';

@Component({
  selector: 'app-project-detail',
  imports: [Toolbar, LoadingBar, Todo, DatePipe, RouterLink],
  templateUrl: './project-detail.html',
  styleUrl: './project-detail.scss',
})
export class ProjectDetail implements OnInit {
  route = inject(ActivatedRoute);
  amaService = inject(AmaService);

  projectId: number | null = null;
  project: Project | null = null;
  tasks: TodoTask[] = [];

  loadingProject = false;
  loadingTasks = false;
  errorProject: string | null = null;
  errorTasks: string | null = null;

  activeTab: TabId = 'summary';

  tabs: { id: TabId; label: string; icon: string }[] = [
    { id: 'summary',   label: 'Summary',   icon: 'fa-solid fa-circle-info' },
    { id: 'tasks',     label: 'Tasks',     icon: 'fa-solid fa-list-check'  },
    { id: 'documents', label: 'Documents', icon: 'fa-solid fa-file'        },
  ];

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.projectId = +id;
        this.loadProject();
      }
    });
  }

  loadProject() {
    this.loadingProject = true;
    this.errorProject = null;
    this.amaService.fetchProjectById(this.projectId!).subscribe({
      next: (project) => {
        this.project = project;
        this.loadingProject = false;
      },
      error: (err) => {
        console.error('Error fetching project', err);
        this.errorProject = 'Failed to load project.';
        this.loadingProject = false;
      }
    });
  }

  loadTasks() {
    this.loadingTasks = true;
    this.errorTasks = null;
    this.amaService.fetchProjectTasks(this.projectId!).subscribe({
      next: (tasks) => {
        this.tasks = tasks;
        this.loadingTasks = false;
      },
      error: (err) => {
        console.error('Error fetching tasks', err);
        this.errorTasks = 'Failed to load tasks.';
        this.loadingTasks = false;
      }
    });
  }

  setTab(tab: TabId) {
    this.activeTab = tab;
    if (tab === 'tasks' && this.tasks.length === 0 && !this.errorTasks) {
      this.loadTasks();
    }
  }
}
