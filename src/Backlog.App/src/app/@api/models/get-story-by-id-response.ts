/* tslint:disable */
import { StoryDto } from './story-dto';
export interface GetStoryByIdResponse {
  errors?: Array<string>;
  story?: StoryDto;
}
