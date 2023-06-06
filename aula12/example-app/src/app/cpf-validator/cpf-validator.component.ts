import { Component } from '@angular/core';
import { first } from 'rxjs';

@Component({
	selector: 'app-cpf-validator',
	templateUrl: './cpf-validator.component.html',
	styleUrls: ['./cpf-validator.component.css']
})
export class CpfValidatorComponent {

	protected inputCPF: string = "";
	protected isValid: boolean = true;
	protected maxLength : number = 11;

	protected checkInput(event: any) {
		
		if(this.inputCPF.includes(".") || this.inputCPF.includes("-")) {
			this.maxLength = 14;
		} else {
			this.maxLength = 11;
		}

		if(this.inputCPF.length >= this.maxLength)
			return this.validator();
	}

	protected validator() {
		var cpfArray = this.inputCPF
			.replaceAll(".", '')
			.replace("-", '')
			.split('')
			.map(x => parseInt(x))


		if (cpfArray.length != 11) {
			this.isValid == false;
			return;
		}

		var aux = 0;
		for (var i = 10, j = 0; i >= 2; i--, j++) {
			aux += cpfArray[j] * i;
		}

		var firstNumber = 0;
		var rest = aux % 11;

		if (rest >= 2)
			firstNumber = 11 - rest;

		if (cpfArray[cpfArray.length - 2] != firstNumber) {
			console.log(rest)
			this.isValid = false;
			return;
		}

		aux = 0;
		for (var i = 11, j = 0; i >= 2; i--, j++) {
			aux += cpfArray[j] * i
		}
		
		var secondNumber = 0;
		rest = aux % 11;

		if (rest >= 2)
			secondNumber = 11 - rest;

		if (cpfArray[cpfArray.length - 1] != secondNumber) {
			this.isValid = false;
			return;
		}

		this.isValid = true;
	}

}
