import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { StartComponent } from './start/start.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
  ], 
   providers: [
    // { provide: "apiUrl", useValue: "http://185.157.41.114:1991" },
    { provide: "apiUrl", useValue: "http://localhost:7000" },

  ],
 
  bootstrap: [AppComponent]
})
export class AppModule { }
