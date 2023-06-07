import { Component } from '@angular/core';
import { CepService } from '../cep-service/cep.service';
import { FormControl, Validators } from '@angular/forms';

@Component({
	selector: 'app-new-account-page',
	templateUrl: './new-account-page.component.html',
	styleUrls: ['./new-account-page.component.css']
})
export class NewAccountPageComponent {

	cepValue = ""
	ruaValue = ""

	email = new FormControl('', [
		Validators.required,
		Validators.email,
		Validators.minLength(4)
	]);
	
	constructor(private cep: CepService) { }

	cepAdded() {
		this.cep.getStreet(this.cepValue)
			.subscribe(x => {
				this.ruaValue = x.logradouro
			})
	}
}
