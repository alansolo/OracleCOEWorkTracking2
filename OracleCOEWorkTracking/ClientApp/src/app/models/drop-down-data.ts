import { Region } from './Region';
import { SBU } from './sbu';
import { OwningSite } from './owning-site';
import { OraclePreProdEnvironment } from './oracle-pre-prod-environment';
import { BooleanDropDown } from './boolean-drop-down';
import { DevelopmentTeam } from './development-team';
import { GateStatus } from './gate-status';
import { Gate } from './gate';
import { OwningStream } from './owning-stream';
import { ImpactedStream } from './impacted-stream';
import { Module } from './module';
import { Status } from './status';
import { AppName } from './application';
import { ApplicationAttribute } from './application-attribute';


export class DropDownData {
  regions: Array<Region>;
  sbUs: Array<SBU>;
  appNames: Array<AppName>;
  owningSites: Array<OwningSite>;
  booleanDropDowns: Array<BooleanDropDown>;
  developmentTeams: Array<DevelopmentTeam>;
  gateStatuses: Array<GateStatus>;
  gates: Array<Gate>;
  owningStreams: Array<OwningStream>;
  impactedStreams: Array<ImpactedStream>;
  modules: Array<Module>;
  oraclePreProdEnvironments: Array<OraclePreProdEnvironment>;
  statuses: Array<Status>;
  applicationAttributes: Array<ApplicationAttribute>;
  applicationAttributesSelect: ApplicationAttribute;
}
