import { Component, OnInit, inject, signal } from '@angular/core';

import {
  SkillGroup,
  SkillGroupService
} from '../../services/skill-group.service';

@Component({
  selector: 'app-skills',
  imports: [],
  templateUrl: './skills.html',
  styleUrl: './skills.css',
})
export class Skills implements OnInit {
  private readonly skillGroupService = inject(SkillGroupService);

  skillGroups = signal<SkillGroup[]>([]);

  ngOnInit(): void {
    this.skillGroupService.getSkillGroups().subscribe({
      next: (groups) => {
        this.skillGroups.set(groups);
      },
      error: (error) => {
        console.error('Failed to load skill groups:', error);
      }
    });
  }
}