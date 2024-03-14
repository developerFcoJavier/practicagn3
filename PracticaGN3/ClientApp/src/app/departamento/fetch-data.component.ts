import { Component, Inject,OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { style } from '@angular/animations';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['../../assets/modal.css'],
})
export class FetchDataComponent implements OnInit {

  public forecasts: WeatherForecast[] = [];
  submitted = false;
  campo: string = '';
  form: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.http.get<WeatherForecast[]>(this.baseUrl + 'api/departamento').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));

    this.form = this.formBuilder.group(
      {
        claveDepartamento : ['', Validators.required],
        descripcion: ['', Validators.required],
      }
    );
  }
  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  onSubmit(): void {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }
    this.http.post<any>(this.baseUrl + 'api/departamento', this.form.value).subscribe(result => {

      this.submitted = false;
      this.form.reset();
      if (confirm(result.mensaje)) {
        window.location.reload();
      }
      
    }, error => alert(error.message));

  }

  onReset(): void {
    this.submitted = false;
    this.form.reset();
  }
  modalOpen = false;

  openModal(): void {
    this.modalOpen = true;
  }

  closeModal(): void {
    this.modalOpen = false;
  }
}



interface WeatherForecast {
  claveDepartamento: number;
  descripcion: string;
}
