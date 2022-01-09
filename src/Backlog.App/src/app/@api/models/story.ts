import { SkillRequirement } from "@api";

export type Story = {
    storyId: string,
    name: string,
    title: string,
    description: string,
    acceptanceCriteria: string,
    jiraUrl: string,
    dependsOn: string[],
    skillRequirements: SkillRequirement[],
    status: string,
    effort: number
};
