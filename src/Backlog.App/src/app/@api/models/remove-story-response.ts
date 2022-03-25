/* tslint:disable */
import { StoryDto } from './story-dto';
export interface RemoveStoryResponse {
  errors?: Array<string>;
  story?: StoryDto;
}
