import { Component, Input, inject, OnInit } from '@angular/core';
import { Project } from '../../models/Project';
import { TodoTask } from '../../models/TodoTask';
import { AmaService } from '../../services/AmaService';
import { Todo } from '../todo/todo';

@Component({
  selector: 'app-project-tasks-list',
  imports: [Todo],
  templateUrl: './project-tasks-list.html',
  styleUrl: './project-tasks-list.scss',
})
export class ProjectTasksList implements OnInit {
  @Input() project!: Project;

  private amaService = inject(AmaService);

  tasks: TodoTask[] = [];
  loading: boolean = false;

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.loading = true;
    this.amaService.fetchProjectTasks(this.project.id).subscribe({
      next: (tasks) => {
        this.tasks = tasks;
        this.loading = false;
      },
      error: (error) => {
        console.error('Error loading project tasks:', error);
        this.loading = false;
      }
    });
  }

  onNextState(task: TodoTask): void {
    this.amaService.nextStateMyTodoTask(task.id).subscribe({
      next: () => {
        this.loadTasks();
      },
      error: (error) => {
        console.error('Error updating task:', error);
      }
    });
  }

  onDelete(task: TodoTask): void {
    this.amaService.deleteMyTodoTask(task.id).subscribe({
      next: () => {
        this.loadTasks();
      },
      error: (error) => {
        console.error('Error deleting task:', error);
      }
    });
  }
}
