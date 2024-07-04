import { CUSTOM_ELEMENTS_SCHEMA, Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';
import { TopheaderComponent } from './component/builder/topheader/topheader.component';
import { NavComponent } from './component/builder/nav/nav.component';
import { BannerComponent } from './component/builder/banner/banner.component';

import { Banner2Component } from './component/builder/banner2/banner2.component';
import { FooterComponent } from './component/builder/footer/footer.component';
import { Card1Component } from './component/builder/card1/card1.component';
import { Card2Component } from './component/builder/card2/card2.component';
import { Card3Component } from './component/builder/card3/card3.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,TopheaderComponent,NavComponent,RouterOutlet,RouterModule,BannerComponent,Card1Component,Card2Component,Card3Component,Banner2Component,FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
 
})
export class AppComponent {
  title = 'foodUI';
}
