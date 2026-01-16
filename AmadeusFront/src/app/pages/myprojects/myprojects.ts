import { Component, inject } from '@angular/core';
import { Toolbar } from "../../layout/toolbar/toolbar";
import { AmaService } from '../../services/AmaService';
import { Project } from '../../models/Project';
import { ProjectCard } from "../../comps/project-card/project-card";

@Component({
  selector: 'app-myprojects',
  imports: [Toolbar, ProjectCard],
  templateUrl: './myprojects.html',
  styleUrl: './myprojects.scss',
})
export class MyProjects {

  amaService = inject(AmaService);

  loadingMyProjects: boolean = false;

  myProjects: Project[] = [];

  ngOnInit(){
    this.refreshMyProjects();
  }

  refreshMyProjects(){
    this.loadingMyProjects = true;
    this.amaService.fetchMyProjects().subscribe({
      next: (projects) => {
        this.myProjects = projects;
        this.loadingMyProjects = false;
      },
      error: (error) => {
        console.error("Error fetching my projects:", error);
        this.loadingMyProjects = false;
      }
    });
  }
}
