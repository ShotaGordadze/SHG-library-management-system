import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { authService } from '../auth.service';
import jwt_decode, { jwtDecode } from "jwt-decode";


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrl: './login-form.component.css'
})

export class LoginFormComponent {
  
  constructor(private router: Router, private authService : authService) {}

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)])
  });

  login() {
    if (this.loginForm.invalid) {
      console.log("invalid")
    } else {
      const { email, password } = this.loginForm.value;
      const login = {email, password}
      const jsonString = JSON.stringify(login);
      this.authService.signIn(jsonString).subscribe(
        response => {
          const token = response.token;
          const decodedToken = jwtDecode(token);
          const tokenJson = JSON.stringify(decodedToken);
          const newToken = JSON.parse(tokenJson);
          console.log(newToken.role);
        },
        error => {
          console.log(error);
        }
      );
    }
  }

  get email() {
    return this.loginForm.get('email');
  }

  get password() {
    return this.loginForm.get('password');
  }

  navigateToRoute(){
    this.router.navigate(['/register']);
  }

}
