import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { Breadcrumb } from './core/services/breadcrumbs/breadcrumb';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './core/nav-menu/nav-menu.component';
import { FooterComponent } from './core/footer/footer.component';
import { ContactPageCoffeeHeroComponent } from './shared/components/contact-page-coffee-hero/contact-page-coffee-hero.component';
import { WordpressTemplatesComponent } from './shared/components/wordpress-templates/wordpress-templates.component';
import { WpTemplCatPipe } from './shared/pipes/wordpress-category/wp-templ-cat.pipe';
import { FilterTemplatesOnTextPipe } from './shared/pipes/wordpress-category/filter-templates-on-text.pipe';
import { RecentWorkFullWidthComponent } from './shared/components/recent-work/recent-work-full-width/recent-work-full-width.component';
import { PostComponent } from './modules/post/post.component';
import { MessageComponent } from './shared/components/message/message.component';
import { CommentComponent } from './modules/comment/comment.component';
import { AgmCoreModule } from '@agm/core';
import { BreadcrumbsComponent } from './core/services/breadcrumbs/breadcrumbs.component';
import { BreadcrumbProvider } from './core/services/breadcrumbs/breadcrumbProvider';
import { LoginFormComponent } from './core/authentication/login-form/login-form.component';
import { RegisterFormComponent } from './core/authentication/register-form/register-form.component';
import { ProfileComponent } from './modules/profile/profile.component';
import { WebdevelopmentComponent } from './modules/webdevelopment/webdevelopment.component';
import { WebdesignComponent } from './modules/webdesign/webdesign.component';
import { WebstructuurComponent } from './modules/webstructuur/webstructuur.component';
import { ZoekmachineOptimalisatieComponent } from './modules/zoekmachine-optimalisatie/zoekmachine-optimalisatie.component';
import { ConversieComponent } from './modules/conversie/conversie.component';
import { BlogComponent } from './modules/blog/blog.component';
import { ContactComponent } from './modules/contact/contact.component';
import { FrequentlyAskedQuestionsComponent } from './modules/frequently-asked-questions/frequently-asked-questions.component';
import { ThemesComponent } from './modules/themes/themes.component';
import { WordpressComponent } from './modules/wordpress/wordpress.component';
import { HomeComponent } from './modules/home/home.component';
import { NewsletterComponent } from './shared/components/newsletter/newsletter.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'webdevelopment', component: WebdevelopmentComponent, data: {breadcrumbs: [new Breadcrumb('Webdevelopment', 'webdevelopment')] } },
  { path: 'webdesign', component: WebdesignComponent, data: {breadcrumbs: [new Breadcrumb('Webdesign', 'webdesign')] } },
  { path: 'webstructuur', component: WebstructuurComponent, data: {breadcrumbs: [new Breadcrumb('Webstructuur', 'webstructuur')] } },
  { path: 'zoekmachine-optimalisatie', component: ZoekmachineOptimalisatieComponent, data: {breadcrumbs: [new Breadcrumb('Zoekmachine-optimalisatie', 'zoekmachine-optimalisatie')] } },
  { path: 'conversie', component: ConversieComponent, data: { breadcrumb: 'conversie' } },
  { path: 'blog', children: [
      { path: '', component: BlogComponent, data: { breadcrumbs: [new Breadcrumb('Blog', 'blog')] } },
      { path: 'post/:id', component: PostComponent, data: { breadcrumbs: [new Breadcrumb('Blog', 'blog/post/:id'), new Breadcrumb('Post', 'blog/post/category/:id')] } },
    ]},
  { path: 'contact', component: ContactComponent, data: {breadcrumbs: [new Breadcrumb('Contact', 'contact')] } },
  { path: 'frequently-asked-questions', component: FrequentlyAskedQuestionsComponent, data: {breadcrumbs: [new Breadcrumb('Frequently-Asked-Questions', 'frequently-asked-questions')] } },
  { path: 'themes', component: ThemesComponent, data: {breadcrumbs: [new Breadcrumb('Themes', 'themes')] } },
  { path: 'login', component: LoginFormComponent },
  { path: 'register', component: RegisterFormComponent },
  { path: 'profile', component: ProfileComponent },
  
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    FooterComponent,
    WebdesignComponent,
    WebdevelopmentComponent,
    WebstructuurComponent,
    WordpressComponent,
    ZoekmachineOptimalisatieComponent,
    ConversieComponent,
    BlogComponent,
    ContactComponent,
    FrequentlyAskedQuestionsComponent,
    ContactPageCoffeeHeroComponent,
    WordpressTemplatesComponent,
    ThemesComponent,
    WpTemplCatPipe,
    FilterTemplatesOnTextPipe,
    RecentWorkFullWidthComponent,
    PostComponent,
    MessageComponent,
    CommentComponent,
    BreadcrumbsComponent,
    LoginFormComponent,
    RegisterFormComponent,
    ProfileComponent,
    NewsletterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: true } // <-- debugging purposes only
    ),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyCi9wdA24KGooUFpDoAMiCN8RKvX1zdDsE'
    }),
  ],
  providers: [BreadcrumbProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
