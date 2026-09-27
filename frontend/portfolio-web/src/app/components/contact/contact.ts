import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

import {
  ContactService,
  CreateContactMessageRequest
} from '../../services/contact.service';

@Component({
  selector: 'app-contact',
  imports: [FormsModule],
  templateUrl: './contact.html',
  styleUrl: './contact.css',
})
export class Contact {
  private readonly contactService = inject(ContactService);

  isSubmitting = signal(false);
  submitSuccess = signal(false);
  submitError = signal(false);

  nameError = signal('');
  emailError = signal('');
  messageError = signal('');

  form = {
    name: '',
    email: '',
    message: ''
  };

  preventInvalidSpace(event: KeyboardEvent): void {
  if (event.key !== ' ') {
    return;
  }

  const input = event.target as HTMLInputElement | HTMLTextAreaElement;

  // Email fields should never contain spaces.
  if (input.type === 'email') {
    event.preventDefault();
    return;
  }

  // Prevent consecutive spaces.
  if (input.value.endsWith(' ')) {
    event.preventDefault();
  }
}

  onSubmit(): void {
    this.clearValidationErrors();

    const name = this.normalizeName(this.form.name);
    const email = this.form.email.trim();
    const message = this.form.message.trim();

    let isValid = true;

    if (!name) {
      this.nameError.set('Please enter your name.');
      isValid = false;
    } else if (!this.isValidName(name)) {
      this.nameError.set('Please enter a valid name.');
      isValid = false;
    }

    if (!email) {
      this.emailError.set('Please enter your email address.');
      isValid = false;
    } else if (!this.isValidEmail(email)) {
      this.emailError.set('Please enter a valid email address.');
      isValid = false;
    }

    if (!message) {
      this.messageError.set('Please enter a message.');
      isValid = false;
    }

    if (!isValid) {
      this.form.name = name;
      this.form.email = email;
      this.form.message = message;
      return;
    }

    const request: CreateContactMessageRequest = {
      name,
      email,
      message
    };

    this.form.name = name;
    this.form.email = email;
    this.form.message = message;

    this.isSubmitting.set(true);
    this.submitSuccess.set(false);
    this.submitError.set(false);

    this.contactService.sendMessage(request).subscribe({
      next: () => {
        this.isSubmitting.set(false);
        this.submitSuccess.set(true);

        this.form = {
          name: '',
          email: '',
          message: ''
        };
      },
      error: (error) => {
        console.error('Failed to send contact message:', error);

        this.isSubmitting.set(false);
        this.submitError.set(true);
      }
    });
  }

  private normalizeName(value: string): string {
    return value
      .trim()
      .replace(/\s+/g, ' ')
      .split(' ')
      .map(word => {
        if (!word) {
          return word;
        }

        return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
      })
      .join(' ');
  }

  private isValidName(value: string): boolean {
    return /^[A-Za-z]+(?:[ '-][A-Za-z]+)*$/.test(value);
  }

  private isValidEmail(value: string): boolean {
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value);
  }

  private clearValidationErrors(): void {
    this.nameError.set('');
    this.emailError.set('');
    this.messageError.set('');
  }
}