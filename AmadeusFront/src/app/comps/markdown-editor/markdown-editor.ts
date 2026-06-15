import { CommonModule } from '@angular/common';
import { Component, OnDestroy } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Editor } from '@tiptap/core';
import StarterKit from '@tiptap/starter-kit';
import { TiptapEditorDirective } from 'ngx-tiptap';
// github.com/sibiraj-s/ngx-tiptap
@Component({
  selector: 'app-markdown-editor',
  imports: [CommonModule, FormsModule, TiptapEditorDirective],
  templateUrl: './markdown-editor.html',
  styleUrl: './markdown-editor.scss',
})
export class MarkdownEditor implements OnDestroy{
  editor = new Editor({extensions: [StarterKit]});
  value = '';

  ngOnDestroy(): void {
    this.editor.destroy();
  }
}
