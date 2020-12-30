import { Trackable } from '../interfaces/trackable';
import { SelectListItem } from './select-list-item';

export class ApplicationAttribute extends SelectListItem implements Trackable {
  id: number;

  createdBy?: string;
  createById?: number;
  createdOn?: Date;
  modifiedBy?: string;
  modifiedById?: number;
  modifiedOn?: Date;

  applicationId: number;
  attribute1: string;
  attribute2: string;
  attribute3: string;
  attribute4: string;
  attribute5: string;
  attribute6: string;
  attribute7: string;
  attribute8: string;
  attribute9: string;
  attribute10: string;
}
