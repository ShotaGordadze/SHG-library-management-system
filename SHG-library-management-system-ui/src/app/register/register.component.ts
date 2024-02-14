import { Component } from '@angular/core';
import { ReactiveFormsModule, Validators } from '@angular/forms';
import { FormsModule, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
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
      const {name, lastname, email, password} = this.registerForm.value;
      console.log(name, lastname, email, password);
    }
  }
}