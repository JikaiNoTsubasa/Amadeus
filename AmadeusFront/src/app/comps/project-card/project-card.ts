import { Component, Input } from '@angular/core';
import { Project } from '../../models/Project';
import { TruncatePipe } from "../../pipes/truncate-pipe";
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-project-card',
  imports: [TruncatePipe, RouterLink],
  templateUrl: './project-card.html',
  styleUrl: './project-card.scss',
})
export class ProjectCard {

  @Input() project: Project | null = null;
}
