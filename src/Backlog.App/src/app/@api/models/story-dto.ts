/* tslint:disable */
import { SkillRequirementDto } from './skill-requirement-dto';
export interface StoryDto {
  acceptanceCriteria?: string;
  dependsOn?: Array<string>;
  description?: string;
  effort?: number;
  jiraUrl?: string;
  name?: string;
  skillRequirements?: Array<SkillRequirementDto>;
  status?: string;
  storyId?: string;
  title?: string;
}
