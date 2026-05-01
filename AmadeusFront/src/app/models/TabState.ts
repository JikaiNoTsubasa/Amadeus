export interface TabState {
  tabs: TabStateItem[];
  activeTabId: string;
}

export interface TabStateItem {
  id: string;
  type: string;
  label: string;
  projectId?: number;
}
