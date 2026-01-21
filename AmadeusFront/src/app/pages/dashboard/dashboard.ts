import { Component, inject } from '@angular/core';
import { Toolbar } from "../../layout/toolbar/toolbar";
import { AmaService } from '../../services/AmaService';
import { LoadingBar } from "../../comps/loading-bar/loading-bar";
import { Todo } from "../../comps/todo/todo";
import { TodoContainer } from "../../comps/todo-container/todo-container";

@Component({
  selector: 'app-dashboard',
  imports: [Toolbar, TodoContainer],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard {

  amaService = inject(AmaService);

  ngOnInit(){
  }

}
