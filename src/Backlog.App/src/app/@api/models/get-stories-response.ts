/* tslint:disable */
import { StoryDto } from './story-dto';
export interface GetStoriesResponse {
  errors?: Array<string>;
  stories?: Array<StoryDto>;
}
