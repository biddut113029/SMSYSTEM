import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.module.shared';
import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
@NgModule({
    bootstrap: [AppComponent, HomeComponent],
    imports: [
        ServerModule,
        AppModuleShared
    ]
})
export class AppModule {
}
