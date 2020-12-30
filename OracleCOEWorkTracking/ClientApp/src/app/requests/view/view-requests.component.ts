import { Component, OnInit, ViewChild, AfterViewInit, AfterContentInit } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { RequestService } from '../../services/request.service';
import { FormBuilder } from '@angular/forms';
import { GridComponent, GridDataResult, DataStateChangeEvent, ColumnComponent, ColumnReorderEvent } from '@progress/kendo-angular-grid';
import { process, State } from '@progress/kendo-data-query';
import { Request } from '../../models/request';
import { ExcelExportData } from '@progress/kendo-angular-excel-export';
import { StatePersistingService } from '../../services/state-persisting.service';
import { RequestView } from '../../models/request-view';

@Component({
  selector: 'app-view-requests',
  templateUrl: './view-requests.component.html',
  styleUrls: ['./view-requests.component.css']
})
export class ViewRequestsComponent implements OnInit, AfterViewInit {

    isLoading: boolean = true;
    gridView: GridDataResult;
    requestArray: Array<Request>;
    formSubmitAttempt: boolean;
    openRequestsOnly: boolean = true;
    @ViewChild('requestsGrid') grid: GridComponent;
    columnOrder: string[];
    views: Array<RequestView>;
    selectedView: RequestView;
    selectedViewId: number;

    constructor(
      private adminService: AdminService,
      private requestService: RequestService,
      private persistService: StatePersistingService) {
        this.allData = this.allData.bind(this);
    }

    ngOnInit() {
      this.selectedViewId = 1;

      this.adminService.getRequestViews().subscribe(data => {
        this.views = data.result;
        this.selectedView = this.views.find(x => x.id == this.selectedViewId);

        this.persistService.getStateRequest(-1).then((res: DataStateChangeEvent) => this.state = res);
        this.refreshGrid();
        this.columnOrder = this.persistService.get("OracleWorkMgmtViewOrder");
      });

    }

    ngAfterViewInit(): void {
      if (this.columnOrder == null) { 
          let colord = this.grid.columns.map((m, i) => (m.title));
          this.columnOrder = colord;
        }
        if (this.columnOrder !== null) {
            this.reorderColumns();
        }
    }

    state: DataStateChangeEvent = {
      skip: 0,
      take: 25
    };

    dataStateChange(state: DataStateChangeEvent): void {
      this.persistService.setStateRequest(-1, state).then((res) => res);
      this.state = state;
      this.refreshGrid();
    }

    refreshGrid() {
      this.isLoading = true;
      this.requestService.getAllRequests(this.openRequestsOnly).subscribe(result => {
      
        this.requestArray = result.result;
        this.resetMultiValueStrings();
        this.gridView = process(this.requestArray, this.state);
        this.isLoading = false;
      });
    }

    viewChange($event: any) {

      if (this.state != null) {
        this.state.skip = 0;
        this.state.take = 25;
      }

      this.selectedView = $event;

      this.isLoading = true;
  
      this.requestService.getAllRequestViewData(this.selectedView.id, this.openRequestsOnly).subscribe(result => {
        this.requestArray = result.result;
        this.resetMultiValueStrings();
        this.gridView = process(this.requestArray, this.state);
        this.isLoading = false;
      });
    }

    filterClick($event: any) {
      //console.log($event);
      this.openRequestsOnly = ($event.target.value === '1');
      this.refreshGrid();
    }

    downloadAttachment(id: any) {
      //onsole.log(id);
      this.requestService.getRequestAttachment(id);
    }

    resetFilters() {
        this.dataStateChange({ skip: 0, take: 25, filter: undefined, sort: [] });
    }

    resetMultiValueStrings() {
        this.requestArray.forEach(r => {
            r.modulesString = '';
            r.modules.forEach(m => {
                r.modulesString = (r.modulesString ? r.modulesString : '') + m.name + ' ';
            })
        });
        this.requestArray.forEach(r => {
            r.impactedStreamsString = '';
            r.impactedStreams.forEach(m => {
                r.impactedStreamsString = (r.impactedStreamsString ? r.impactedStreamsString : '') + m.name + ' ';
            })
        });
        this.requestArray.forEach(r => {
            r.sbUsString = '';
            r.sbUs.forEach(m => {
                r.sbUsString = (r.sbUsString ? r.sbUsString : '') + m.name + ' ';
            })
        });
        this.requestArray.forEach(r => {
            r.regionsString = '';
            r.regions.forEach(m => {
                r.regionsString = (r.regionsString ? r.regionsString : '') + m.name + ' ';
            })
        });
        this.requestArray.forEach(r => {
            r.oraclePreProdEnvironmentsString = '';
            r.oraclePreProdEnvironments.forEach(m => {
                r.oraclePreProdEnvironmentsString = (r.oraclePreProdEnvironmentsString ? r.oraclePreProdEnvironmentsString : '') + m.name + ' ';
            })
        });
        this.requestArray.forEach(r => {
            r.developmentTeamsString = '';
            r.developmentTeams.forEach(m => {
                r.developmentTeamsString = (r.developmentTeamsString ? r.developmentTeamsString : '') + m.name + ' ';
            })
        });
    }

    public allData(): ExcelExportData {
        let stateCopy = { ...this.state };
        stateCopy.skip = 0;
        stateCopy.take = this.requestArray.length;
        const result: ExcelExportData = {
            data: process(this.requestArray, stateCopy).data
        };

        return result;
    }

    onColumnReorder($event: ColumnReorderEvent) {
        let col = this.columnOrder.filter(f => f === $event.column.title)
        if (col.length === 1) {
            let i = this.columnOrder.indexOf(col[0]);
            this.columnOrder.splice(i, 1);            
        }
        this.columnOrder.splice($event.newIndex, 0, $event.column.title);
        this.persistService.set("OracleWorkMgmtViewOrder", this.columnOrder);        
    }

    reorderColumns() {
        this.columnOrder.forEach((val, indx) => {
            let cols = this.grid.columns.filter(f => f.title === val);
            if (cols.length > 0) {
                this.grid.reorderColumn(cols[0], indx);
            }            
        });        
    }
}
