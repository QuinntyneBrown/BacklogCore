import { DependencyRelationship, SkillRequirement } from "@api";

export type Story = {
    storyId: string,
    name: string,
    title: string,
    description: string,
    acceptanceCriteria: string,
    jiraUrl: string,
    dependencyRelationships: DependencyRelationship[],
    skillRequirements: SkillRequirement[]
};
