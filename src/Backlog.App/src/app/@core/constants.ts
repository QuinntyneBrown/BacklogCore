import { InjectionToken } from "@angular/core";
import { environment } from "src/environments/environment";

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
  "Assigned","InProgress", "Done"
];

export const ckEditorConfig = {
  removeDialogTabs :'image:advanced;image:Link;link:advanced;link:upload',
  filebrowserImageUploadUrl: `https://localhost:5001/api/connector?command=upload`
};

export const accessTokenKey = "accessTokenKey";
export const usernameKey = "usernameKey";
export const storageKey = "backlog:storageKey";

