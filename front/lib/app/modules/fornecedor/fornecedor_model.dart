// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

import 'package:front/app/util/situacao_enum.dart';

class FornecedorModel {
  final int? id;
  final String? nome;
  final String? email;
  final String? cnpj;
  final String? cep;
  final String? logradouro;
  final String? nomeFantasia;
  final String? numero;
  final String? bairro;
  final String? cidade;
  final String? estado;
  final String? telefone;
  final SituacaoEnum? situacao;

  FornecedorModel({
    this.id,
    this.nome,
    this.email,
    this.cnpj,
    this.telefone,
    this.cep,
    this.nomeFantasia,
    this.logradouro,
    this.numero,
    this.bairro,
    this.cidade,
    this.estado,
    this.situacao,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'nome': nome,
      'email': email,
      'cnpj': cnpj,
      'cep': cep,
      'nomeFantasia': nomeFantasia,
      'logradouro': logradouro,
      'numero': numero,
      'bairro': bairro,
      'cidade': cidade,
      'estado': estado,
      'situacao': situacao?.index,
    };
  }

  factory FornecedorModel.fromMap(Map<String, dynamic> map) {
    return FornecedorModel(
      id: map['id'] != null ? map['id'] as int : null,
      nome: map['nome'] != null ? map['nome'] as String : null,
      email: map['email'] != null ? map['email'] as String : null,
      cnpj: map['cnpj'] != null ? map['cnpj'] as String : null,
      cep: map['cep'] != null ? map['cep'] as String : null,
      nomeFantasia:
          map['nomeFantasia'] != null ? map['nomeFantasia'] as String : null,
      logradouro:
          map['logradouro'] != null ? map['logradouro'] as String : null,
      numero: map['numero'] != null ? map['numero'] as String : null,
      bairro: map['bairro'] != null ? map['bairro'] as String : null,
      cidade: map['cidade'] != null ? map['cidade'] as String : null,
      estado: map['estado'] != null ? map['estado'] as String : null,
      situacao: SituacaoEnum.fromInt(map['situacao'] ?? 0),
    );
  }

  static String toJson(FornecedorModel value) => json.encode(value.toMap());

  factory FornecedorModel.fromJson(String source) => FornecedorModel.fromMap(
        json.decode(source) as Map<String, dynamic>,
      );
  FornecedorModel copyWith({
    int? id,
    String? nome,
    String? email,
    String? cnpj,
    String? cep,
    String? logradouro,
    String? numero,
    String? telefone,
    String? bairro,
    String? cidade,
    String? estado,
    String? nomeFantasia,
    SituacaoEnum? situacao,
  }) {
    return FornecedorModel(
      id: id ?? this.id,
      nome: nome ?? this.nome,
      email: email ?? this.email,
      cnpj: cnpj ?? this.cnpj,
      cep: cep ?? this.cep,
      nomeFantasia: nomeFantasia ?? nomeFantasia,
      telefone: telefone ?? this.telefone,
      logradouro: logradouro ?? this.logradouro,
      numero: numero ?? this.numero,
      bairro: bairro ?? this.bairro,
      cidade: cidade ?? this.cidade,
      estado: estado ?? this.estado,
      situacao: situacao ?? this.situacao,
    );
  }

  @override
  bool operator ==(covariant FornecedorModel other) {
    if (identical(this, other)) return true;

    return other.id == id;
  }

  @override
  int get hashCode {
    return id.hashCode;
  }
}
