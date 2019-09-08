import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonAccessComponent } from './person-access.component';

describe('PersonAccessComponent', () => {
  let component: PersonAccessComponent;
  let fixture: ComponentFixture<PersonAccessComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonAccessComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonAccessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
