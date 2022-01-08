import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { baseUrl, BASE_URL } from '@core/constants';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ShellModule } from '@shared/shells/shell';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ShellModule
  ],
  providers: [
    { provide: baseUrl, useValue: "https://localhost:5001/"},
    { provide: BASE_URL, useValue: "https://localhost:5001/"}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
