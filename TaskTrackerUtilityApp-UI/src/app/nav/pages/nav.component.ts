import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService, private route:Router,private snackBar:MatSnackBar) { }

  ngOnInit() {

    const token = localStorage.getItem('token');
    if (token != null) this.route.navigate(['/dashboard']);
  }

  login(loginForm: NgForm) {
    this.authService.login(this.model).subscribe(next => {
      this.snackBar.open('Logged in successfully!', 'OK', {
        duration: 5000,
      });
      loginForm.resetForm({
        username: '',
        password: ''
      });
      this.route.navigate(['/dashboard']);
    }, error => {
      console.log('Failed to login');
      this.snackBar.open('Login Failed!', 'OK', {
        duration: 5000,
      });
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    //if (token != null) this.route.navigate(['/dashboard']);
    return (token == null ? false : true);
  }

  logout() {
    localStorage.removeItem('token');
    console.log('logged out');
    this.route.navigate(['/']);
    
  }

}
