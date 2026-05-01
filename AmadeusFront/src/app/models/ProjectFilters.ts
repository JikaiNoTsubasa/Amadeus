import { ProjectStatus } from './Project';

export interface ProjectFilters {
  searchText: string;
  statusFilter: ProjectStatus | 'ALL';
  sortBy: SortField;
  sortOrder: SortOrder;
}

export enum SortField {
  NAME = 'NAME',
  DATE = 'DATE',
  STATUS = 'STATUS'
}

export enum SortOrder {
  ASC = 'ASC',
  DESC = 'DESC'
}

export const DEFAULT_FILTERS: ProjectFilters = {
  searchText: '',
  statusFilter: 'ALL',
  sortBy: SortField.DATE,
  sortOrder: SortOrder.DESC
};
