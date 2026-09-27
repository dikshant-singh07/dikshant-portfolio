import { Component, OnInit, inject, signal } from '@angular/core';
import { DatePipe } from '@angular/common';

import {
  Experience as ExperienceItem,
  ExperienceService
} from '../../services/experience.service';

@Component({
  selector: 'app-experience',
  imports: [DatePipe],
  templateUrl: './experience.html',
  styleUrl: './experience.css',
})
export class Experience implements OnInit {
  private readonly experienceService = inject(ExperienceService);

  experiences = signal<ExperienceItem[]>([]);

  ngOnInit(): void {
    this.experienceService.getExperience().subscribe({
      next: (experiences) => {
        this.experiences.set(experiences);
      },
      error: (error) => {
        console.error('Failed to load experience:', error);
      }
    });
  }
}