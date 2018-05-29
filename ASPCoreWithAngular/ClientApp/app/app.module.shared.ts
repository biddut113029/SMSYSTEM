import { NgModule } from '@angular/core';
import { CourseService } from './services/crsservice.service'
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
import { createcourse } from './components/addcourse/AddCourse.component'
import { BrowserModule } from '@angular/platform-browser';
import { DataTablesModule } from 'angular-datatables';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchStudentComponent,
        createstudent,
        createcourse,
    
    ],
    imports: [
        BrowserModule,

        DataTablesModule,
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
            { path: 'createcourse', component: createcourse },
            { path: 'app', component: AppComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [StudentService, CourseService],
    bootstrap: [AppComponent, HomeComponent],
})
export class AppModuleShared {
}
