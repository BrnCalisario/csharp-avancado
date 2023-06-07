import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
	selector: 'app-login-page',
	templateUrl: './login-page.component.html',
	styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
	link = ""
	password = ""

	email = new FormControl('', [
		Validators.required,
		Validators.email,
		Validators.minLength(4)
	])

	constructor(private router: Router) { }

	passwordChanged(event: any)
	{
		console.log(event)
		this.password = event
	}

	login()
	{
		if(this.email.value == "donplatina@email.com" && this.password == "123")
		{
			sessionStorage.setItem('user', 'donplatinado')
			this.router.navigate(["/feed"])
		}
	}
}
