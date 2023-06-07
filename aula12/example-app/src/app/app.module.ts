import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { NewAccountPageComponent } from './new-account-page/new-account-page.component';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';
import { RecoverPageComponent } from './recover-page/recover-page.component';
import { UserPageComponent } from './user-page/user-page.component';
import { FeedPageComponent } from './feed-page/feed-page.component';
import { ComunityPageComponent } from './comunity-page/comunity-page.component';
import { PasswordComponent } from './password/password.component';
import { FormsModule } from '@angular/forms';
import { CreatePasswordComponent } from './create-password/create-password.component';
import { CpfValidatorComponent } from './cpf-validator/cpf-validator.component';
import { CardComponent } from './card/card.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button'; // Added for use Angular Material Button
import {MatInputModule} from '@angular/material/input';
import { PasswordBunitoComponent } from "./password-bunito/password-bunito.component";
import {MatCardModule} from '@angular/material/card';

@NgModule({
    declarations: [
        AppComponent,
        NavComponent,
        LoginPageComponent,
        HomePageComponent,
        NewAccountPageComponent,
        NotFoundPageComponent,
        RecoverPageComponent,
        UserPageComponent,
        FeedPageComponent,
        ComunityPageComponent,
        PasswordComponent,
        CreatePasswordComponent,
        CpfValidatorComponent,
        CardComponent
    ],
    providers: [],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        FormsModule,
        HttpClientModule,
        ReactiveFormsModule,
        MatSlideToggleModule,
        MatButtonModule,
        MatInputModule,
        BrowserAnimationsModule,
        PasswordBunitoComponent,
        MatCardModule
    ]
})


export class AppModule { }
