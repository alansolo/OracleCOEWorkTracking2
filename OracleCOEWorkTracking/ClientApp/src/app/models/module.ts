import { Trackable } from '../interfaces/trackable';
import { SelectListItem } from './select-list-item';

export class Module extends SelectListItem implements Trackable {
  id: number;
  name: string;
  appIds?: Array<number>;
  createdBy?: string;
  createById?: number;
  createdOn?: Date;
  modifiedBy?: string;
  modifiedById?: number;
  modifiedOn?: Date;
}
