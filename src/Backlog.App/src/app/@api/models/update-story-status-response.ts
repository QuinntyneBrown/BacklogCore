/* tslint:disable */
import { StoryDto } from './story-dto';
export interface UpdateStoryStatusResponse {
  errors?: Array<string>;
  story?: StoryDto;
}
