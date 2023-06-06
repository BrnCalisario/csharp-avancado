import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
	selector: 'app-recover-page',
	templateUrl: './recover-page.component.html',
	styleUrls: ['./recover-page.component.css']
})

export class RecoverPageComponent implements OnInit, OnDestroy {
	email = ""
	subscription: any;

	constructor(private route: ActivatedRoute, private router: Router) { }

	ngOnInit() {
		this.subscription = this.route.params.subscribe(params => {
			this.email = params['email'];
		});		
	}

	ngOnDestroy() {
		this.subscription.unsubscribe();
	}

	send() {
		this.router.navigate(["/login"])
	}
}
