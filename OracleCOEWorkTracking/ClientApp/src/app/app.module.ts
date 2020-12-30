/// <reference path="route-guards/manage.guard.ts" />
import { ManageGuard } from './route-guards/manage.guard';
import { ViewGuard } from './route-guards/view.guard';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, isDevMode } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { Ng2CompleterModule } from 'ng2-completer';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateResxHttpLoader } from '@kneefer/ngx-translate-resx-http-loader';
import { TranslationConfigModule } from './shared/modules/translation.config.module';
import { ToasterModule, ToasterService } from 'angular2-toaster';
import { TitleBarComponent } from './title-bar/title-bar.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { HomeComponent } from './home/home.component';
import { AddRequestComponent } from './requests/add/add-request.component';
import { ManageRequestsComponent } from './requests/manage/manage-requests.component';
import { ViewRequestsComponent } from './requests/view/view-requests.component';
import { FieldErrorDisplayComponent } from './field-error-display/field-error-display.component';
import { SelectListComponent } from './select-list/select-list.component';
import { FindUserModalComponent } from './modals/find-user-modal/find-user-modal.component';
import { RequestEditModalComponent } from './modals/request-edit-modal/request-edit-modal.component';
import { RequestNotesModalComponent } from './modals/request-notes-modal/request-notes-modal.component';
import { NgProgressModule, NgProgressInterceptor } from 'ngx-progressbar';
import { Routing } from './app-routing.module';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { RequestConfirmationModalComponent } from './modals/request-confirmation-modal/request-confirmation-modal.component';
import { GridModule, ExcelModule } from '@progress/kendo-angular-grid';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { DatePickerModule } from '@progress/kendo-angular-dateinputs';
import { DatePipe } from '@angular/common';

import { AppComponent } from './app.component';
import { StatePersistingService } from './services/state-persisting.service';
import { UserService } from './services/user.service';
import { RequestService } from './services/request.service';
import { AdminService } from './services/admin.service';
import { UtilService } from './shared/util.service';

export function createTranslateLoader(http: HttpClient) {
  // Only first constructor parameter is required
  if (isDevMode()) {
    return new TranslateResxHttpLoader(http, 'trans.', 'assets/i18n', '.resx');
  } else {
    return new TranslateResxHttpLoader(http, 'trans.', 'assets/i18n', '.xml');
  }
}

@NgModule({
  declarations: [
    AppComponent,
    TitleBarComponent,
    FooterComponent,
    HeaderComponent,
    UnauthorizedComponent,
    HomeComponent,
    AddRequestComponent,
    ManageRequestsComponent,
    ViewRequestsComponent,
    FieldErrorDisplayComponent,
    SelectListComponent,
    FindUserModalComponent,
    RequestConfirmationModalComponent,
    RequestEditModalComponent,
    RequestNotesModalComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ToasterModule.forRoot(),
    NgProgressModule,
    Ng2CompleterModule,
    TranslationConfigModule,
    BrowserAnimationsModule,
    GridModule,
    ExcelModule,
    DropDownsModule,
    DatePickerModule,
    //DateValueAccessorModule,
    Routing,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: createTranslateLoader,
        deps: [HttpClient]
      }
    }),
    NgMultiSelectDropDownModule.forRoot(),
    NgbModule.forRoot(),
    //MatIconModule
  ],
  providers: [
    UserService,
    AdminService,
    UtilService,
    RequestService,
    DatePipe,
    StatePersistingService,
    ManageGuard,
    ViewGuard,
    { provide: HTTP_INTERCEPTORS, useClass: NgProgressInterceptor, multi: true }
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    FindUserModalComponent,
    RequestConfirmationModalComponent,
    RequestEditModalComponent,
    RequestNotesModalComponent]
})
  export class AppModule { }
