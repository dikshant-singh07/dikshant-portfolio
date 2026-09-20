import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { About } from './components/about/about';
import { Skills } from './components/skills/skills';
import { Work } from './components/work/work';
import { Experience } from './components/experience/experience';
import { Contact } from './components/contact/contact';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, About, Skills, Work, Experience, Contact],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('portfolio-web');
}
