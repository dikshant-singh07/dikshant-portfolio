import { Component, OnInit, inject, signal } from '@angular/core';

import { Project, ProjectService } from '../../services/project.service';

@Component({
  selector: 'app-work',
  imports: [],
  templateUrl: './work.html',
  styleUrl: './work.css',
})
export class Work implements OnInit {
  private readonly projectService = inject(ProjectService);

  projects = signal<Project[]>([]);

  ngOnInit(): void {
    this.projectService.getProjects().subscribe({
      next: (projects) => {
        this.projects.set(projects);
      },
      error: (error) => {
        console.error('Failed to load projects:', error);
      }
    });
  }
}