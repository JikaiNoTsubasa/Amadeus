import { Component } from '@angular/core';
import { RouterOutlet } from "@angular/router";
import { LeftMenu } from "../left-menu/left-menu";

@Component({
  selector: 'app-layout',
  imports: [RouterOutlet, LeftMenu],
  templateUrl: './layout.html',
  styleUrl: './layout.scss',
})
export class Layout {

}
