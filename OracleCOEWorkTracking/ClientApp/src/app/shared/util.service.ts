import { FormGroup } from '@angular/forms';
import { SelectListItem } from '../models/select-list-item';
import { AbstractControl } from '@angular/forms/src/model';

export class UtilService {

  /* These functions are for showing standard toaster messages from API calls */
  showFeedback(toasterService, callResult) {
    if (callResult.success) {
      toasterService.pop('success', callResult.title, callResult.message);
    } else {
      toasterService.pop({
        type: 'error',
        title: callResult.title,
        body: callResult.message,
        timeout: 0
      });
    }
  }

  showErrorIfExists(toasterService, callResult) {
    if (!callResult.success) {
      toasterService.pop({
        type: 'error',
        title: callResult.title,
        body: callResult.message,
        timeout: 0
      });
    }
  }

  /* These functions are displaying the red boxes around invalid form fields */
  isFieldInvalid(form: FormGroup, field: string, formSubmitAttempt: boolean) {
    let control = form.get(field);
    if (control != null) {
      return (
        (control.invalid && formSubmitAttempt)
      );
    } else {
      return true;
    }
  }

  // shouldn't actually need this anymore cause dropdown validation is built in to control.valid
  isDropdownFieldInvalid(form: FormGroup, field: string, formSubmitAttempt: boolean) {
    let control = form.get(field);
    if (control != null) {
        return (
          ((control.invalid || control.value == null || control.value.id === 0) && formSubmitAttempt)
        );
    } else {
      return true;
    }
  }

  displayFieldCss(form: FormGroup, field: string, formSubmitAttempt: boolean) {
    return {
      'has-danger': this.isFieldInvalid(form, field, formSubmitAttempt),
      'has-feedback': this.isFieldInvalid(form, field, formSubmitAttempt)
    };
  }

  // shouldn't actually need this anymore cause dropdown validation is built in to control.valid
  displayDropdownFieldCss(form: FormGroup, field: string, formSubmitAttempt: boolean) {
    return {
      'has-danger': this.isDropdownFieldInvalid(form, field, formSubmitAttempt),
      'has-feedback': this.isDropdownFieldInvalid(form, field, formSubmitAttempt)
    };
  }

  /* For showing date range errors */
  isDateRangeValid(startDate, endDate): boolean {
    let range = this.getSelectedDateRange(startDate, endDate);
    let isValid = false;

    if (range != null) {
      isValid = range[0] <= range[1]; //&& (range[1].getTime() - range[0].getTime() <= 365 * 24 * 60 * 60 * 1000)
    }
    else {
      isValid = true;
    }
    return isValid;

    //return !this.isValidDateRange() && this.getSelectedDateRange() != null;
  }

  private getSelectedDateRange(dtStartValue, dtEndValue): Date[] {
    if (dtStartValue != null && dtEndValue != null) {
      let from = new Date(dtStartValue.year, dtStartValue.month - 1, dtStartValue.day);
      let to = new Date(dtEndValue.year, dtEndValue.month - 1, dtEndValue.day);
      return [from, to];
    }
    return null;
  }

  /* This function is for initlizing any dropdown field */
  initializeDropdown(data: Array<SelectListItem>, control: AbstractControl): Array<SelectListItem> {
    var arr = new Array<SelectListItem>();
    arr.push({ id: 0, name: '' });
    arr = arr.concat(data);
    control.setValue(arr[0]);
    return arr;
  }
  initializeDropdownNoEmpty(data: Array<SelectListItem>, control: AbstractControl): Array<SelectListItem> {
    var arr = new Array<SelectListItem>();
    arr = arr.concat(data);
    control.setValue(arr[0]);
    return arr;
  }

  initializeDropdownWithValue(data: Array<SelectListItem>, item: SelectListItem, control: AbstractControl): Array<SelectListItem> {
    var arr = new Array<SelectListItem>();
    arr.push({ id: 0, name: '' });
    arr = arr.concat(data);

    // If there is a value for the dropdown, try to select it in the list
    if (control != undefined) {
      if (item != null) {
        // Check if the item is in the dropdown list
        var filteredArr = arr.filter(f => f.id == item.id);
        if (filteredArr.length == 0) {
          // If it has, add it to the array, but with a -1 id so we know on the API to ignore it
          // This is so the user can still see the admin item for this request even though it was deleted from the admin list
          arr.unshift({ id: -1, name: item.name });
          control.setValue(arr[0]);
        }
        else {
          control.setValue(item);
        }
      }
      // If the item is null, just select the first blank item { id: 0, name: ''}
      else {
        control.setValue(arr[0]);
      }
    }

    return arr;
  }

  dropdownHasData<T>(data: Array<T>): boolean {
    // Length greater than 1 becasuse the default item { id: 0, name: ''} counts as an item
    return data.length > 1;
  }

  toSelectItemList<T>(data: Array<T>): Array<SelectListItem> {
    let ret = new Array<SelectListItem>();
    data.forEach((val) => { ret = ret.concat({ id: val['id'], name: val['name']}) });
    return ret;
  }

  // Autosize columns to the width of the data in them
  autoSizeAll(gridColumnApi) {
    var allColumnIds = [];
    gridColumnApi.getAllColumns().forEach(column => {
      allColumnIds.push(column.colId);
    });
    gridColumnApi.autoSizeColumns(allColumnIds);
  }
}
