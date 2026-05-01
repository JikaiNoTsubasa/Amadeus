import { Component, Input } from '@angular/core';
import { Project } from '../../models/Project';
import { TruncatePipe } from "../../pipes/truncate-pipe";

@Component({
  selector: 'app-project-card',
  imports: [TruncatePipe],
  templateUrl: './project-card.html',
  styleUrl: './project-card.scss',
})
export class ProjectCard {

  @Input() project: Project | null = null;
}
