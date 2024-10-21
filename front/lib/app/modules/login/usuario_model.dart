// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';
import 'package:front/app/util/situacao_enum.dart';
import 'package:front/app/util/tipo_usuario_enum.dart';

class UsuarioModel {
  final int? id;
  final String? nome;
  final String? email;
  final String? rg;
  final String? cpf;
  final String? cep;
  final String? logradouro;
  final int? numero;
  final String? bairro;
  final String? senha;
  final String? cidade;
  final String? estado;
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
    required this.numero,
    this.bairro,
    this.cidade,
    this.estado,
    this.matricula,
    required this.situacao,
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
    int? numero,
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

  factory UsuarioModel.fromMap(Map<String, dynamic> map) {
    return UsuarioModel(
      id: map['id'] as int?,
      nome: map['nome'] as String?,
      email: map['email'] as String?,
      rg: map['rg'] as String?,
      cpf: map['cpf'] as String?,
      cep: map['cep'] as String?,
      logradouro: map['logradouro'] as String?,
      numero: map['numero'] as int,
      bairro: map['bairro'] as String?,
      senha: map['senha'] as String?,
      cidade: map['cidade'] as String?,
      estado: map['estado'] as String?,
      matricula: map['matricula'] as String?,
      situacao: SituacaoEnum.fromInt(map['situacao'] as int),
      tipoUsuarioEnum: TipoUsuarioEnum.fromInt(map['tipoUsuarioEnum'] as int),
    );
  }

  static String toJson(UsuarioModel value) => json.encode(value.toMap());

  factory UsuarioModel.fromJson(String source) =>
      UsuarioModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
