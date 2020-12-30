//import { GridSettings } from '../models/grid-settings.interface';
import { Injectable } from '@angular/core';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
//import { State } from '@progress/kendo-data-query';

@Injectable()
export class StatePersistingService {
    public get<T>(token: string): T {
        const settings = localStorage.getItem(token);
        return settings ? JSON.parse(settings) : settings;
    }

    public set<T>(token: string, gridConfig: any): void {
        localStorage.setItem(token, JSON.stringify(gridConfig));
    }

    public setStateRequest(selectedViewId: number, state: DataStateChangeEvent) {
        return new Promise((resolve, reject) => {
            localStorage.setItem(selectedViewId.toString() + "State", JSON.stringify(state));
            resolve();
        });     
    }

    public getStateRequest(selectedViewId: number) {
        return new Promise((resolve, reject) => {
            const settings = localStorage.getItem(selectedViewId.toString() + "State");
            let s = settings ? JSON.parse(settings) : settings;
            if (s !== null) {
                resolve(s);
            }
            else {
                resolve({ skip: 0, take: 25, filter: undefined, sort: [] });
            }
        }); 
    }
}
