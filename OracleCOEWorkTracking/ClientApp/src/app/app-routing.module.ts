import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { AppComponent } from "./app.component";
import { UnauthorizedComponent } from "./unauthorized/unauthorized.component";
import { ViewRequestsComponent } from "./requests/view/view-requests.component";
import { AddRequestComponent } from "./requests/add/add-request.component";
import { ManageRequestsComponent } from "./requests/manage/manage-requests.component";
import { ManageGuard } from "./route-guards/manage.guard";
import { ViewGuard } from "./route-guards/view.guard";


const routes: Routes = [
  // No path
  { path: '', component: ViewRequestsComponent },

  { path: 'requests', component: ViewRequestsComponent, pathMatch: 'full' },

  { path: 'requests/add', component: AddRequestComponent, canActivate: [ViewGuard] },

  { path: 'requests/manage', redirectTo: 'requests/manage/1'},

  { path: 'requests/manage/:viewId', component: ManageRequestsComponent, canActivate: [ManageGuard] },

  // unauthorized 
  { path: 'unauthorized', component: UnauthorizedComponent },

  // catch all
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(routes, { onSameUrlNavigation: 'reload' });
