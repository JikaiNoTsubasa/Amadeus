import { Component } from '@angular/core';
import { RouterOutlet } from "@angular/router";
import { LeftMenu } from "../left-menu/left-menu";
import { Topbar } from "../topbar/topbar";

@Component({
  selector: 'app-layout',
  imports: [RouterOutlet, LeftMenu, Topbar],
  templateUrl: './layout.html',
  styleUrl: './layout.scss',
})
export class Layout {

}
