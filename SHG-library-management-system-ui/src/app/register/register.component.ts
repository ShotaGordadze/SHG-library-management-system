import { Component } from '@angular/core';
import { ReactiveFormsModule, Validators } from '@angular/forms';
import { FormsModule, FormControl, FormGroup } from '@angular/forms';
import { authService } from '../auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  constructor(private authService: authService){

  }

  registerForm = new FormGroup({
    name : new FormControl('', [Validators.required]),
    lastname : new FormControl('', [Validators.required]),
    email : new FormControl('', Validators.email),
    password : new FormControl('', Validators.minLength(8)),
    repeatPassword : new FormControl('', Validators.required)
  })

  get name() {
    return this.registerForm.get('name')
  }

  get lastname() {
    return this.registerForm.get('lastname')
  }

  get email() {
    return this.registerForm.get('email')
  }

  get password() {
    return this.registerForm.get('password')
  }

  get repeatPassword(){
    return this.registerForm.get('repeatPassword')
  }

  passwordsMatch(){
    return this.password?.value === this.repeatPassword?.value;
  }

  register() {
    if(this.registerForm.invalid || !this.passwordsMatch){
      console.log("invalid")
    }else{
      const {email, password} = this.registerForm.value;
      const jsonObject = { email, password };
      const jsonString = JSON.stringify(jsonObject);
      this.authService.signUp(jsonString).subscribe(
        response => {
          console.log('Response from signUp:', response);
        },
        error => {
          console.error('Error from signUp:', error);
          // Handle error if needed
        }
      );
    }
  }
}
