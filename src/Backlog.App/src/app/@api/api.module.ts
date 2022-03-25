/* tslint:disable */
import { NgModule, ModuleWithProviders } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ApiConfiguration, ApiConfigurationInterface } from './api-configuration';

import { BugService } from './services/bug.service';
import { CompetencyLevelService } from './services/competency-level.service';
import { ConnectorService } from './services/connector.service';
import { DigitalAssetService } from './services/digital-asset.service';
import { EventsService } from './services/events.service';
import { ProfileService } from './services/profile.service';
import { SprintService } from './services/sprint.service';
import { StatusService } from './services/status.service';
import { StoryService } from './services/story.service';
import { TaskItemService } from './services/task-item.service';
import { TechnologyService } from './services/technology.service';
import { UserService } from './services/user.service';

/**
 * Provider for all Api services, plus ApiConfiguration
 */
@NgModule({
  imports: [
    HttpClientModule
  ],
  exports: [
    HttpClientModule
  ],
  declarations: [],
  providers: [
    ApiConfiguration,
    BugService,
    CompetencyLevelService,
    ConnectorService,
    DigitalAssetService,
    EventsService,
    ProfileService,
    SprintService,
    StatusService,
    StoryService,
    TaskItemService,
    TechnologyService,
    UserService
  ],
})
export class ApiModule {
  static forRoot(customParams: ApiConfigurationInterface): ModuleWithProviders<ApiModule> {
    return {
      ngModule: ApiModule,
      providers: [
        {
          provide: ApiConfiguration,
          useValue: {rootUrl: customParams.rootUrl}
        }
      ]
    }
  }
}
