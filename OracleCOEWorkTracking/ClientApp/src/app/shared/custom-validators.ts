import { AbstractControl, Validators } from '@angular/forms';

export function ValidateRequiredDropdown(control: AbstractControl) {
  if (control.value != null && control.value.id === 0) {
    return { validDropdown: false }
  }
  return null;
}

export function ValidateMultiValueDropdown(control: AbstractControl) {
  if (control.value != null && control.value.length === 0) {
    return { validDropdown: false }
  }
  return null;
}
