import { Component, Input } from '@angular/core';
import { Project } from '../../models/Project';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-project-detail-view',
  imports: [DatePipe],
  templateUrl: './project-detail-view.html',
  styleUrl: './project-detail-view.scss',
})
export class ProjectDetailView {
  @Input() project!: Project;
}
