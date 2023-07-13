import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatInputModule} from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatCardModule} from '@angular/material/card';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import {MatSelectModule} from '@angular/material/select';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorIntl, MatPaginatorModule} from '@angular/material/paginator';
import {MatDialogModule} from '@angular/material/dialog';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatDividerModule} from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';
import {MatRadioModule} from '@angular/material/radio';
import {MatTabsModule} from '@angular/material/tabs';


@NgModule({
  declarations: [],
  imports: [
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatSnackBarModule,    
    MatProgressSpinnerModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule, 
    MatExpansionModule,
    MatCardModule,
    MatSelectModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTableModule,    
    MatPaginatorModule,   
    MatDialogModule,
    MatAutocompleteModule, 
    MatDividerModule,
    MatTooltipModule,
    MatRadioModule,    
    MatTabsModule
  ],
  exports:[
    ReactiveFormsModule,
    HttpClientModule,    
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatSnackBarModule,    
    MatProgressSpinnerModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule ,
    MatExpansionModule,
    MatCardModule,
    MatSelectModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTableModule,    
    MatPaginatorModule,
    MatDialogModule,
    MatAutocompleteModule,
    MatDividerModule,
    MatTooltipModule,
    MatRadioModule,
    MatTabsModule
  ],
  providers:[]
})
export class SharedModule { }