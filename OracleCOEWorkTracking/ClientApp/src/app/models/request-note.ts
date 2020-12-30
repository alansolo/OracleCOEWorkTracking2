import { Trackable } from '../interfaces/trackable';

export class RequestNote  implements Trackable {
  id?: number;
  note: string;
  requestId: number;

  createdBy?: string;
  createById?: number;
  createdOn?: Date;
  modifiedBy?: string;
  modifiedById?: number;
  modifiedOn?: Date;
}
