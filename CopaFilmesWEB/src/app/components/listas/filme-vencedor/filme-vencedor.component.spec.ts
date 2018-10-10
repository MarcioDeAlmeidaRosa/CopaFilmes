import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmeVencedorComponent } from './filme-vencedor.component';

describe('FilmeVencedorComponent', () => {
  let component: FilmeVencedorComponent;
  let fixture: ComponentFixture<FilmeVencedorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FilmeVencedorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FilmeVencedorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
