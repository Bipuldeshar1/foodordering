import { Component } from '@angular/core';
import { BannerComponent } from '../../builder/banner/banner.component';
import { Banner2Component } from '../../builder/banner2/banner2.component';
import { Card1Component } from '../../builder/card1/card1.component';
import { Card2Component } from '../../builder/card2/card2.component';
import { Card3Component } from '../../builder/card3/card3.component';
import { TopheaderComponent } from '../../builder/topheader/topheader.component';
import { NavComponent } from '../../builder/nav/nav.component';
import { FooterComponent } from '../../builder/footer/footer.component';
import { CustomerReviewComponent } from '../../builder/customer-review/customer-review.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [BannerComponent,Banner2Component,Card1Component,Card2Component,Card3Component,TopheaderComponent,NavComponent,FooterComponent,CustomerReviewComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
