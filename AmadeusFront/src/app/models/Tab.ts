export interface Tab {
  id: string;
  type: TabType;
  label: string;
  closeable: boolean;
  active: boolean;
  data?: any;
}

export enum TabType {
  PROJECT_LIST = 'PROJECT_LIST',
  PROJECT_DETAIL = 'PROJECT_DETAIL'
}
