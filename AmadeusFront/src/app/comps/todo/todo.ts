import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { TodoTask } from '../../models/TodoTask';
import { AmaService } from '../../services/AmaService';

@Component({
  selector: 'app-todo',
  imports: [],
  templateUrl: './todo.html',
  styleUrl: './todo.scss',
})
export class Todo {

  @Input() todo: TodoTask | null = null;
  @Output() evNextState = new EventEmitter<number | null>();
  @Output() evDelete = new EventEmitter<number | null>();

  onNextStateEvent(){
    this.evNextState.emit(this.todo?.id);
  }

  onDeleteEvent(){
    this.evDelete.emit(this.todo?.id);
  }
}
