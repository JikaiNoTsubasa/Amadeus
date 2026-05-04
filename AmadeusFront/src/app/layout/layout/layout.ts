import { Component } from '@angular/core';
import { RouterOutlet } from "@angular/router";
import { LeftMenu } from "../left-menu/left-menu";
import { PopupContainer } from "../../comps/popup-container/popup-container";

@Component({
  selector: 'app-layout',
  imports: [RouterOutlet, LeftMenu, PopupContainer],
  templateUrl: './layout.html',
  styleUrl: './layout.scss',
})
export class Layout {

}
