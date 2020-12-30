import { Component, Input, Output, EventEmitter, forwardRef, ViewChild, ElementRef } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';

import { SelectListItem } from '../models/select-list-item';

@Component({
  selector: 'app-select-list',
  templateUrl: './select-list.component.html',
  styleUrls: ['./select-list.component.css'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: forwardRef(() => SelectListComponent)
    }]
})
export class SelectListComponent implements ControlValueAccessor {

  @ViewChild("selectInput") selectInputRef: ElementRef;

  @Input()
  public listItems: Array<SelectListItem>;

  @Input()
  public selectedItem: SelectListItem;

  @Input()
  public IsDisabled: boolean;

  @Input() public isDefaultFocus: boolean;

  @Output()
  public onSelectItem: EventEmitter<SelectListItem> = new EventEmitter<SelectListItem>();

  constructor() {
    this.IsDisabled = false;
    this.isDefaultFocus = false;
  }

  compareFn(a1: SelectListItem, a2: SelectListItem): boolean {
    return a1 && a2 ? a1.id === a2.id : a1 === a2;
  }

  onChange() {
    this.onSelectItem.emit(this.selectedItem);
    this.propagateChange(this.selectedItem);
  }

  // Required functions to implement ControlValueAccessor - which allows this custom component to be used with both Reactive and Template forms
  // the method set in registerOnChange, it is just 
  // a placeholder for a method that takes one parameter, 
  // we use it to emit changes back to the form
  private propagateChange = (_: any) => { };

  // this is the initial value set to the component
  public writeValue(value: any) {
    if (value !== undefined && value !== null) {
      this.selectedItem = value;
    }
    if (this.isDefaultFocus) {
      this.selectInputRef.nativeElement.focus();
    }
  }

  // registers 'fn' that will be fired when changes are made
  // this is how we emit the changes back to the form
  public registerOnChange(fn: any) {
    this.propagateChange = fn;
  }
  // not used, used for touch input
  public registerOnTouched() {
  }
}
