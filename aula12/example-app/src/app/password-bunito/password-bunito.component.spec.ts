import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PasswordBunitoComponent } from './password-bunito.component';

describe('PasswordBunitoComponent', () => {
  let component: PasswordBunitoComponent;
  let fixture: ComponentFixture<PasswordBunitoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PasswordBunitoComponent]
    });
    fixture = TestBed.createComponent(PasswordBunitoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
