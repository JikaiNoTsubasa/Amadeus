import { Component, Input, Output, EventEmitter, inject, OnInit, OnChanges } from '@angular/core';
import { Project } from '../../models/Project';
import { ProjectCard } from '../project-card/project-card';
import { ProjectListFilters } from '../project-list-filters/project-list-filters';
import { ProjectFilters, DEFAULT_FILTERS, SortField } from '../../models/ProjectFilters';
import { StorageService } from '../../services/storage.service';

@Component({
  selector: 'app-project-list-view',
  imports: [ProjectCard, ProjectListFilters],
  templateUrl: './project-list-view.html',
  styleUrl: './project-list-view.scss',
})
export class ProjectListView implements OnInit, OnChanges {
  @Input() projects: Project[] = [];
  @Output() projectOpen = new EventEmitter<Project>();

  private storageService = inject(StorageService);

  filters: ProjectFilters = { ...DEFAULT_FILTERS };
  filteredProjects: Project[] = [];

  ngOnInit(): void {
    this.loadFilters();
    this.applyFilters();
  }

  ngOnChanges(): void {
    this.applyFilters();
  }

  onFiltersChanged(filters: ProjectFilters): void {
    this.filters = filters;
    this.saveFilters();
    this.applyFilters();
  }

  onProjectClick(project: Project): void {
    this.projectOpen.emit(project);
  }

  private loadFilters(): void {
    const saved = this.storageService.get<ProjectFilters>(
      'myprojects',
      'filters',
      DEFAULT_FILTERS
    );
    if (saved) {
      this.filters = saved;
    }
  }

  private saveFilters(): void {
    this.storageService.set('myprojects', 'filters', this.filters);
  }

  private applyFilters(): void {
    let result = [...this.projects];

    if (this.filters.searchText) {
      const search = this.filters.searchText.toLowerCase();
      result = result.filter(p =>
        p.name.toLowerCase().includes(search) ||
        p.summary?.toLowerCase().includes(search) ||
        p.description?.toLowerCase().includes(search)
      );
    }

    if (this.filters.statusFilter !== 'ALL') {
      result = result.filter(p => p.status === this.filters.statusFilter);
    }

    result.sort((a, b) => {
      let comparison = 0;
      switch (this.filters.sortBy) {
        case SortField.NAME:
          comparison = a.name.localeCompare(b.name);
          break;
        case SortField.DATE:
          comparison = new Date(a.createdAt).getTime() - new Date(b.createdAt).getTime();
          break;
        case SortField.STATUS:
          comparison = a.status.localeCompare(b.status);
          break;
      }
      return this.filters.sortOrder === 'ASC' ? comparison : -comparison;
    });

    this.filteredProjects = result;
  }
}
