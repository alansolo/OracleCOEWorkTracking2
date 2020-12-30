import { Trackable } from '../interfaces/trackable';
import { SelectListItem } from './select-list-item';

export class Status extends SelectListItem implements Trackable {
  id: number;
  name: string;

  createdBy?: string;
  createById?: number;
  createdOn?: Date;
  modifiedBy?: string;
  modifiedById?: number;
  modifiedOn?: Date;
}
