// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

import 'package:front/app/util/situacao_enum.dart';
import 'package:front/app/util/tipo_usuario_enum.dart';

class UsuarioModel {
  final int? id;
  final String? cpf;
  final String? nome;
  final String? rg;
  final String? logradouro;
  final String? numero;
  final String? cidade;
  final String? estado;
  final String? cep;
  String? email;
  String? senha;
  final String? bairro;
  final String? matricula;
  final SituacaoEnum? situacao;
  final TipoUsuarioEnum? tipoUsuarioEnum;

  UsuarioModel({
    this.id,
    this.nome,
    this.email,
    this.rg,
    this.cpf,
    this.cep,
    this.logradouro,
    this.numero,
    this.bairro,
    this.cidade,
    this.estado,
    this.matricula,
    this.situacao,
    this.tipoUsuarioEnum,
    this.senha,
  });

  UsuarioModel copyWith({
    int? id,
    String? nome,
    String? email,
    String? rg,
    String? cpf,
    String? cep,
    String? logradouro,
    String? numero,
    String? bairro,
    String? senha,
    String? cidade,
    String? estado,
    String? matricula,
    SituacaoEnum? situacao,
    TipoUsuarioEnum? tipoUsuarioEnum,
  }) {
    return UsuarioModel(
      id: id ?? this.id,
      nome: nome ?? this.nome,
      email: email ?? this.email,
      rg: rg ?? this.rg,
      cpf: cpf ?? this.cpf,
      cep: cep ?? this.cep,
      logradouro: logradouro ?? this.logradouro,
      numero: numero ?? this.numero,
      bairro: bairro ?? this.bairro,
      senha: senha ?? this.senha,
      cidade: cidade ?? this.cidade,
      estado: estado ?? this.estado,
      matricula: matricula ?? this.matricula,
      situacao: situacao ?? this.situacao,
      tipoUsuarioEnum: tipoUsuarioEnum ?? this.tipoUsuarioEnum,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'nome': nome,
      'email': email,
      'rg': rg,
      'cpf': cpf,
      'cep': cep,
      'logradouro': logradouro,
      'numero': numero,
      'bairro': bairro,
      'senha': senha,
      'cidade': cidade,
      'estado': estado,
      'matricula': matricula,
      'situacao': situacao?.index,
      'tipoUsuarioEnum': tipoUsuarioEnum!.index,
    };
  }

  Map<String, dynamic> toMapLogin() {
    return {
      'email': email,
      'senha': senha,
    };
  }

  factory UsuarioModel.fromMap(Map<String, dynamic> map) {
    return UsuarioModel(
      id: map['id'] ?? 0,
      nome: map['nome'] != null ? map['nome'] as String : null,
      email: map['email'] != null ? map['email'] as String : null,
      rg: map['rg'] != null ? map['rg'] as String : null,
      cpf: map['cpf'] != null ? map['cpf'] as String : null,
      cep: map['cep'] != null ? map['cep'] as String : null,
      logradouro:
          map['logradouro'] != null ? map['logradouro'] as String : null,
      numero: map['numero'] != null ? map['numero'] as String : null,
      bairro: map['bairro'] != null ? map['bairro'] as String : null,
      senha: map['senha'] != null ? map['senha'] as String : null,
      cidade: map['cidade'] != null ? map['cidade'] as String : null,
      estado: map['estado'] != null ? map['estado'] as String : null,
      matricula: map['matricula'] != null ? map['matricula'] as String : null,
      situacao: SituacaoEnum.fromInt(map['situacao'] ?? 0),
      tipoUsuarioEnum: TipoUsuarioEnum.fromInt(map['tipoUsuarioEnum'] ?? 0),
    );
  }

  static String toJson(UsuarioModel value) => json.encode(value.toMap());

  static String toJsonLogin(UsuarioModel value) =>
      json.encode(value.toMapLogin());

  factory UsuarioModel.fromJson(String source) =>
      UsuarioModel.fromMap(json.decode(source) as Map<String, dynamic>);

  @override
  bool operator ==(covariant UsuarioModel other) {
    if (identical(this, other)) return true;

    return other.id == id;
  }

  @override
  int get hashCode {
    return id.hashCode;
  }
}
