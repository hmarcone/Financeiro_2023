import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Despesa } from '../models/Despesa';
import { environment } from 'src/enviroment';

@Injectable({
  providedIn: 'root',
})
export class DespesaService {
  constructor(private httpClient: HttpClient) {}

  private readonly baseURL = environment['endPoint'];

  AdicionarDespesa(despesa: Despesa) {
    return this.httpClient.post<Despesa>(
      `${this.baseURL}/AdicionarDespesa`,
      despesa
    );
  }
}
