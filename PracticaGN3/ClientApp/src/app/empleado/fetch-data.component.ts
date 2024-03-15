import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { style } from '@angular/animations';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['../../assets/modal.css'],
})
export class EmpleadosComponent implements OnInit {

  public forecasts: WeatherForecast[] = [];
  submitted = false;
  form: FormGroup;
  update: boolean = false;
  titleModal: string = 'Insertar';
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.http.get<WeatherForecast[]>(this.baseUrl + 'api/empleados').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));

    this.form = this.formBuilder.group(
      {
        claveEmpleado: ['', Validators.required],
        nombre: ['', Validators.required],
        fechaNacimiento: ['', Validators.required],
        departamentoID: ['', Validators.required],
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

    if (this.update) {
      this.http.put<any>(this.baseUrl + 'api/empleados/' + this.form.value.claveEmpleado, this.form.value).subscribe(result => {

        this.submitted = false;
        this.form.reset();
        if (confirm(result.mensaje)) {
          window.location.reload();
        }

      }, error => alert(error.message));
      return;
    }

    this.http.post<any>(this.baseUrl + 'api/empleados', this.form.value).subscribe(result => {

      this.submitted = false;
      this.form.reset();
      if (confirm(result.mensaje)) {
        window.location.reload();
      }

    }, error => alert(error.message));

  }

  delete(id: number): void {
    if (confirm("seguro de borrar este elemento")) {
      this.http.delete<any>(this.baseUrl + 'api/empleados/' + id).subscribe(result => {
        if (confirm(result.mensaje)) {
          window.location.reload();
        }
      }, error => alert(error.message));
    }
  }

  onReset(): void {
    this.submitted = false;
    this.form.reset();
  }
  modalOpen = false;

  openModal(data: WeatherForecast | null = null): void {
    if (data != null) {
      this.update = true;
      this.titleModal = 'Actualizar';
      this.form.patchValue({
        claveEmpleado: data.claveEmpleado,
        nombre: data.nombre,
        fechaNacimiento: data.fechaNacimiento,
        departamentoID: data.departamentoID,
      });
    } else {
      this.update = false;
      this.titleModal = 'Insertar';
      this.form.reset();
    }
    this.modalOpen = true;
  }

  closeModal(): void {
    this.modalOpen = false;
  }
}



interface WeatherForecast {
  claveEmpleado: number;
  nombre: string;
  fechaIngreso: string;
  fechaNacimiento: string;
  departamentoID: string;
}
