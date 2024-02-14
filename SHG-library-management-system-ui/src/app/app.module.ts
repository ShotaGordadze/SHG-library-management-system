import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UserLoginPageComponent } from './pages/user-login-page/user-login-page.component';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { RegisterPageComponent } from './pages/register-page/register-page.component';
import { BookCardComponent } from './book-card/book-card.component';
import { DashboardPageComponent } from './pages/dashboard-page/dashboard-page.component';
import { EndpointService } from './endpoint.service';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LoginFormComponent,
    UserLoginPageComponent,
    RegisterComponent,
    RegisterPageComponent,
    BookCardComponent,
    DashboardPageComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    EndpointService, // Service provided here
    provideClientHydration()
  ],
  bootstrap: [AppComponent],
  
})
export class AppModule { }




