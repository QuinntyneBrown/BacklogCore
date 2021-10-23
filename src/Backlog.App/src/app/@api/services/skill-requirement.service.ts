import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SkillRequirement } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { baseUrl, EntityPage, IPagableService } from '@core';

@Injectable({
  providedIn: 'root'
})
export class SkillRequirementService implements IPagableService<SkillRequirement> {

  uniqueIdentifierName: string = "skillRequirementId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<SkillRequirement>> {
    return this._client.get<EntityPage<SkillRequirement>>(`${this._baseUrl}api/skillRequirement/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<SkillRequirement[]> {
    return this._client.get<{ skillRequirements: SkillRequirement[] }>(`${this._baseUrl}api/skillRequirement`)
      .pipe(
        map(x => x.skillRequirements)
      );
  }

  public getById(options: { skillRequirementId: string }): Observable<SkillRequirement> {
    return this._client.get<{ skillRequirement: SkillRequirement }>(`${this._baseUrl}api/skillRequirement/${options.skillRequirementId}`)
      .pipe(
        map(x => x.skillRequirement)
      );
  }

  public remove(options: { skillRequirement: SkillRequirement }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/skillRequirement/${options.skillRequirement.skillRequirementId}`);
  }

  public create(options: { skillRequirement: SkillRequirement }): Observable<{ skillRequirement: SkillRequirement }> {
    return this._client.post<{ skillRequirement: SkillRequirement }>(`${this._baseUrl}api/skillRequirement`, { skillRequirement: options.skillRequirement });
  }
  
  public update(options: { skillRequirement: SkillRequirement }): Observable<{ skillRequirement: SkillRequirement }> {
    return this._client.put<{ skillRequirement: SkillRequirement }>(`${this._baseUrl}api/skillRequirement`, { skillRequirement: options.skillRequirement });
  }
}
