import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/enviroment';

@Injectable({
  providedIn: 'root',
})
export class MenuService {
  constructor() {}

  menuSelecionado: number;
}
