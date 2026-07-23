import {
  Component,
  Input,
  OnInit,
  OnChanges,
  OnDestroy,
  SimpleChanges
} from '@angular/core';

@Component({
  selector: 'app-lifecycle-demo',
  imports: [],
  templateUrl: './lifecycle-demo.html',
  styleUrl: './lifecycle-demo.css'
})
export class LifecycleDemo implements OnInit, OnChanges, OnDestroy {

  @Input() courseName = '';

  constructor() {
    console.log('1. Constructor: Component instance created');
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log('2. ngOnChanges: Input value changed', changes);
  }

  ngOnInit(): void {
    console.log('3. ngOnInit: Component initialized');
  }

  ngOnDestroy(): void {
    console.log('4. ngOnDestroy: Component destroyed');
  }
}