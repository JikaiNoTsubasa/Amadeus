import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ProjectFilters, SortField, SortOrder } from '../../models/ProjectFilters';
import { ProjectStatus } from '../../models/Project';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-project-list-filters',
  imports: [FormsModule],
  templateUrl: './project-list-filters.html',
  styleUrl: './project-list-filters.scss',
})
export class ProjectListFilters {
  @Input() filters!: ProjectFilters;
  @Output() filtersChange = new EventEmitter<ProjectFilters>();

  ProjectStatus = ProjectStatus;
  SortField = SortField;
  SortOrder = SortOrder;

  statusOptions = [
    { value: 'ALL', label: 'All Statuses' },
    { value: ProjectStatus.NEW, label: 'New' },
    { value: ProjectStatus.IN_PROGRESS, label: 'In Progress' },
    { value: ProjectStatus.COMPLETED, label: 'Completed' },
    { value: ProjectStatus.CANCELLED, label: 'Cancelled' },
    { value: ProjectStatus.ARCHIVED, label: 'Archived' }
  ];

  sortOptions = [
    { value: SortField.NAME, label: 'Name' },
    { value: SortField.DATE, label: 'Date' },
    { value: SortField.STATUS, label: 'Status' }
  ];

  onSearchChange(value: string): void {
    this.filters.searchText = value;
    this.emitChange();
  }

  onStatusChange(value: string): void {
    this.filters.statusFilter = value as ProjectStatus | 'ALL';
    this.emitChange();
  }

  onSortChange(value: string): void {
    this.filters.sortBy = value as SortField;
    this.emitChange();
  }

  toggleSortOrder(): void {
    this.filters.sortOrder = this.filters.sortOrder === SortOrder.ASC
      ? SortOrder.DESC
      : SortOrder.ASC;
    this.emitChange();
  }

  clearFilters(): void {
    this.filters.searchText = '';
    this.filters.statusFilter = 'ALL';
    this.emitChange();
  }

  private emitChange(): void {
    this.filtersChange.emit({ ...this.filters });
  }
}
