import { Trackable } from '../interfaces/trackable';
import { SelectListItem } from './select-list-item';

export class ImpactedStream extends SelectListItem implements Trackable {
  id: number;

  appId: number;

  name: string;

  createdBy?: string;
  createById?: number;
  createdOn?: Date;
  modifiedBy?: string;
  modifiedById?: number;
  modifiedOn?: Date;
}
