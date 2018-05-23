import { NgModule } from '@angular/core';
import { StudentService } from './services/stdservice.service'
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchStudentComponent } from './components/fetchstudent/fetchstudent.component'
import { createstudent } from './components/addstudent/AddStudent.component'

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchStudentComponent,
        createstudent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-student', component: FetchStudentComponent },
            { path: 'register-student', component: createstudent },
            { path: 'student/edit/:id', component: createstudent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [StudentService]
})
export class AppModuleShared {
}
