import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/AuthService';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {

  authService = inject(AuthService);
  loginProgress: boolean = false;

  protected loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });

  onSubmit(){
    if (this.loginForm.valid) {
      this.loginProgress = true;
      this.authService.login(this.loginForm.value.email!, this.loginForm.value.password!);
    }else{
      console.error('Form is invalid');
      console.log(this.loginForm.value);
    }
  }
}
