/* tslint:disable */
import { StoryDto } from './story-dto';
export interface GetStoriesPageResponse {
  entities?: Array<StoryDto>;
  errors?: Array<string>;
  length?: number;
}
