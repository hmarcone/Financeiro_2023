import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environment';
import { Despesa } from '../models/Despesa';

@Injectable({
  providedIn: 'root',
})
export class DespesaService {
  constructor(private httpClient: HttpClient) {}

  private readonly baseURL = environment['endPoint'];

  AdicionarDespesa(despesa: Despesa) {
    let result = this.httpClient.post<Despesa>(
      `${this.baseURL}/AdicionarDespesa`,
      despesa
    );

    console.log(result);

    return result;
  }

  ListarDespesasUsuario(emailUsuario: string) {
    let result = this.httpClient.get(
      `${this.baseURL}/ListarDespesasUsuario?emailUsuario=${emailUsuario}`
    );

    return result;
  }

  ObterDespesa(id: number) {
    return this.httpClient.get(`${this.baseURL}/ObterDespesa?id=${id}`);
  }

  AtualizarDespesa(despesa: Despesa) {
    return this.httpClient.put<Despesa>(
      `${this.baseURL}/AtualizarDespesa`,
      despesa
    );
  }

  CarregaGraficos(emailUsuario: string) {
    return this.httpClient.get(
      `${this.baseURL}/CarregaGraficos?emailUsuario=${emailUsuario}`
    );
  }
}
