import { TestBed } from '@angular/core/testing';
import { ElementRef } from '@angular/core';
import { Highlight } from './highlight';

describe('Highlight', () => {
  it('should create', () => {
    const el = new ElementRef(document.createElement('div'));
    const directive = new Highlight(el);
    expect(directive).toBeTruthy();
  });
});