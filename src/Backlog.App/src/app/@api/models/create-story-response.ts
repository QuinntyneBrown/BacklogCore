/* tslint:disable */
import { StoryDto } from './story-dto';
export interface CreateStoryResponse {
  errors?: Array<string>;
  story?: StoryDto;
}
