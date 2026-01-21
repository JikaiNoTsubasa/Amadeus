import { Component, inject } from '@angular/core';
import { AmaService } from '../../services/AmaService';
import { Todo } from '../todo/todo';
import { TodoTask } from '../../models/TodoTask';
import { LoadingBar } from "../loading-bar/loading-bar";

@Component({
  selector: 'app-todo-container',
  imports: [LoadingBar, Todo],
  templateUrl: './todo-container.html',
  styleUrl: './todo-container.scss',
})
export class TodoContainer {

  amaService = inject(AmaService);

  loadingTodos: boolean = false;
  todos: TodoTask[] | null = null;
  error: string | null = null;

  ngOnInit(){
    this.refreashTodos();
  }

  refreashTodos(){
    this.loadingTodos = true;
    this.amaService.fetchMyTodoTasks().subscribe({
      next: (tasks) => {
        this.todos = tasks;
        this.loadingTodos = false;
      },
      error: (err) => {
        console.error('Error fetching todo tasks', err);
        this.loadingTodos = false;
        this.error = err.error ?? 'Unknown error';
      }
    })
  }

  onNextState(event: number | null) {
    if (event != null) {
      this.amaService.nextStateMyTodoTask(event).subscribe({
        next: () => {
          this.refreashTodos();
        },
        error: (err) => {
          console.error('Error updating todo task', err);
          this.error = err.error ?? 'Unknown error';
        }
      });
    }else{
      this.error = 'Invalid task id';
    }
  }

  onDelete(event: number | null) {
    if (event != null) {
      this.amaService.deleteMyTodoTask(event).subscribe({
        next: () => {
          this.refreashTodos();
        },
        error: (err) => {
          console.error('Error deleting todo task', err);
          this.error = err.error ?? 'Unknown error';
        }
      });
    }else{
      this.error = 'Invalid task id';
    }
  }
}
