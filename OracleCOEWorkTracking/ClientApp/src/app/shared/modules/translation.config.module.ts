import { NgModule } from '@angular/core';
import { TranslateModule, TranslateLoader, TranslateService } from '@ngx-translate/core';
import { isNull, isUndefined } from 'lodash';

@NgModule({
  imports: [TranslateModule],
  exports: [TranslateModule],
  providers: [TranslateService]
})

// Reference: https://stackoverflow.com/questions/46256662/angular-4-i18n-example-how-to-implement-i18n-in-angular-4?utm_medium=organic&utm_source=google_rich_qa&utm_campaign=google_rich_qa
// https://github.com/ngx-translate/core
// Resx to json converter: https://github.com/kneefer/ngx-translate-resx-http-loader

export class TranslationConfigModule {

  private browserLang;

  /**
   * @param translate {TranslateService}
   */
  constructor(private translate: TranslateService) {
    // Setting up Translations
    translate.addLangs(['en', 'it']);
    translate.setDefaultLang('en');
    this.browserLang = translate.getBrowserLang();
    translate.use(this.browserLang.match(/en|it/) ? this.browserLang : 'en');
  }

  public getBrowserLang() {
    if (isUndefined(this.browserLang) || isNull(this.browserLang)) {
      this.browserLang = 'en';
    }
    return this.browserLang;
  }
}
