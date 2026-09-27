import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';

export interface Experience {
  experienceId: number;
  company: string;
  jobTitle: string;
  location: string | null;
  startDate: string;
  endDate: string | null;
  isCurrent: boolean;
  description: string;
}

@Injectable({
  providedIn: 'root'
})
export class ExperienceService {
  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/experience`;

  getExperience(): Observable<Experience[]> {
    return this.http.get<Experience[]>(this.apiUrl);
  }
}