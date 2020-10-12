import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ItemizedDeductionsComponent } from './itemized-deductions/itemized-deductions.component';
import { BenefitsWorksheetComponent } from './benefits-worksheet/benefits-worksheet.component';
import { BenefitsFormComponent } from './benefits-form/benefits-form.component';

@NgModule({
  declarations: [
    AppComponent,
    ItemizedDeductionsComponent,
    BenefitsWorksheetComponent,
    BenefitsFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
