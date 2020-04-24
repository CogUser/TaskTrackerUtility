import {
  Component,
  OnInit,
  ViewChildren,
  QueryList,
  ChangeDetectorRef,
  ComponentFactoryResolver,
  AfterViewInit,
} from '@angular/core';
import { DashboardTrack } from '../models/dashboardTrack';
import { DashboardOutletDirective } from '../dashboard-outlet.directive';
import { DashboardItem } from '../models/dashboardItem';
import { dashboardCards } from '../pages/dasboard-cards';
import { DashboardCardContainer } from '../pages/dashboard-card/dashboard-card.container';
import { DashboardCards } from '../pages/dashboard-cards.enum';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit, AfterViewInit {
  @ViewChildren(DashboardOutletDirective) dashboardOutlet: QueryList<DashboardOutletDirective>;

  tracks: Array<DashboardTrack> = [
    {
      items: [
        {
          component: DashboardCards.BAR_CHART,
          id: 'linechart'
        }
      ],
    },
    {
      items: [
        {
          component: DashboardCards.LINE_CHART,
          id: 'barchart'
        }
      ]
    }
  ];
  constructor(private cd: ChangeDetectorRef, private cfr: ComponentFactoryResolver) { }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.loadContents();
  }

  loadContents = () => {
    if (!this.dashboardOutlet || !this.dashboardOutlet.length) {
      return;
    }

    this.dashboardOutlet.forEach(template => {
      this.cd.detectChanges();
      this.loadContent(template, template.item);
    });
    this.cd.detectChanges();
  }

  loadContent = (template: DashboardOutletDirective, item: DashboardItem) => {
    if (!item.component) {
      return;
    }

    const viewContainerRef = template.viewContainerRef;
    viewContainerRef.clear();
    const componentFactory = this.cfr.resolveComponentFactory(dashboardCards[item.component]);
    const componentRef = viewContainerRef.createComponent(componentFactory);
    const instance = componentRef.instance as DashboardCardContainer;
    instance.item = item;
  }

}
