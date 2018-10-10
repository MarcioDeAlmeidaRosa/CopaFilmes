import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmeDisputaComponent } from './filme-disputa.component';

describe('FilmeDisputaComponent', () => {
  let component: FilmeDisputaComponent;
  let fixture: ComponentFixture<FilmeDisputaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FilmeDisputaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FilmeDisputaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
