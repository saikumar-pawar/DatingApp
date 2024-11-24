export interface AppSetting {
  id: number;
  appName: string;
  key: string;
  value: string;
  createdBy: number;
  createdDate: Date;
  updatedBy?: number;
  updatedDate?: Date;
}
