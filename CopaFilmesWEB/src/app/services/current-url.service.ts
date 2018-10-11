import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable()
export class CurrentUrlService {
  private currentUrl = this.route.snapshot.queryParams['returnUrl'];

  constructor(
    private route: ActivatedRoute,
    private router: Router
  ) {

  }

  public redirectUrl(url: string) {
    this.router.navigate([this.currentUrl || url]);
  }
}
