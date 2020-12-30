import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Eropa',
      urls: [{ title: 'Giriş', url: '/login' },
      { title: 'Giriş' }]
    },
    component: LoginComponent
  }
]
@NgModule({
  declarations: [],
  imports: [
    CommonModule,    
    FormsModule,    
    RouterModule.forChild(routes),
  ]
})
export class LoginModule { }
