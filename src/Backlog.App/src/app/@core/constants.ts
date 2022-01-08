import { InjectionToken } from "@angular/core";

export const baseUrl = "baseUrl";
export const BASE_URL = new InjectionToken("BASE_URL");
export const fullscreenDialogOptions = {
  panelClass:'g-dialog-panel',
  maxHeight:'100vh',
  maxWidth: '100vw',
  width:'100vw',
  height:'100vh'
}
export const storyStatus = [
  "Assigned","In Progress", "Done"
];

