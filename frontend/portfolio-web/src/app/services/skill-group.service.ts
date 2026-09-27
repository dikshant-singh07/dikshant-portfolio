import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

export interface SkillItem {
  skillId: number;
  name: string;
  type: string;
  displayOrder: number;
}

export interface TechnologyItem {
  technologyId: number;
  name: string;
  type: string;
  displayOrder: number;
}

export interface SkillGroup {
  skillGroupId: number;
  name: string;
  groupType: string;
  displayOrder: number;
  skills: SkillItem[];
  technologies: TechnologyItem[];
}

@Injectable({
  providedIn: 'root'
})
export class SkillGroupService {
  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/skill-groups`;

  getSkillGroups(): Observable<SkillGroup[]> {
    return this.http.get<SkillGroup[]>(this.apiUrl);
  }
}