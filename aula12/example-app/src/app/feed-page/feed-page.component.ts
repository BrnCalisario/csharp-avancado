import { Component, OnInit } from '@angular/core';

@Component({
	selector: 'app-feed-page',
	templateUrl: './feed-page.component.html',
	styleUrls: ['./feed-page.component.css']
})
export class FeedPageComponent implements OnInit {

	user: string | null = null

	ngOnInit(): void {
		this.user = sessionStorage.getItem("user")
	}
}
