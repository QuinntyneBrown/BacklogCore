import { Component, Input } from '@angular/core';
import { Story } from '@api';

@Component({
  selector: 'bl-search-stories-results',
  templateUrl: './search-stories-results.component.html',
  styleUrls: ['./search-stories-results.component.scss']
})
export class SearchStoriesResultsComponent {
  @Input() public query: string;
  @Input() public stories: Story[] = [];
}
