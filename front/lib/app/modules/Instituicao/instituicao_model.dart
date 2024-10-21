import 'dart:convert';

import 'package:front/app/modules/instituicao/tipo_instituicao_model.dart';
import 'package:front/app/modules/secretaria/secretaria_model.dart';
import 'package:front/app/util/situacao_enum.dart';

class InstituicaoModel {
  int? id;
  String? nome;
  String? nomeRazaoSocial;
  String? email;
  String? cnpj;
  int? cep;
  String? logradouro;
  int? numero;
  String? bairro;
  String? cidade;
  String? estado;
  String? telefone;
  SituacaoEnum? situacao;
  TipoInstituicaoModel? tipoInstituicao;
  SecretariaModel? secretaria;

  InstituicaoModel({
    this.id,
    this.nome,
    this.nomeRazaoSocial,
    this.email,
    this.cnpj,
    this.cep,
    this.logradouro,
    this.numero,
    this.bairro,
    this.cidade,
    this.estado,
    this.telefone,
    this.situacao,
    this.tipoInstituicao,
    this.secretaria,
  });

  InstituicaoModel copyWith({
    int? id,
    String? nome,
    String? nomeRazaoSocial,
    String? email,
    String? cnpj,
    int? cep,
    String? logradouro,
    int? numero,
    String? bairro,
    String? cidade,
    String? estado,
    String? telefone,
    SituacaoEnum? situacao,
    TipoInstituicaoModel? tipoInstituicao,
    SecretariaModel? secretaria,
  }) {
    return InstituicaoModel(
      id: id ?? this.id,
      nome: nome ?? this.nome,
      nomeRazaoSocial: nomeRazaoSocial ?? this.nomeRazaoSocial,
      email: email ?? this.email,
      cnpj: cnpj ?? this.cnpj,
      cep: cep ?? this.cep,
      logradouro: logradouro ?? this.logradouro,
      numero: numero ?? this.numero,
      bairro: bairro ?? this.bairro,
      cidade: cidade ?? this.cidade,
      estado: estado ?? this.estado,
      telefone: telefone ?? this.telefone,
      situacao: situacao ?? this.situacao,
      tipoInstituicao: tipoInstituicao ?? this.tipoInstituicao,
      secretaria: secretaria ?? this.secretaria,
    );
  }

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'nome': nome,
      'nomeRazaoSocial': nomeRazaoSocial,
      'email': email,
      'cnpj': cnpj,
      'cep': cep,
      'logradouro': logradouro,
      'numero': numero,
      'bairro': bairro,
      'cidade': cidade,
      'estado': estado,
      'telefone': telefone,
      'situacao': situacao?.index,
      'tipoInstituicao': tipoInstituicao?.toMap(),
      'secretaria': secretaria?.toMap(),
    };
  }

  factory InstituicaoModel.fromMap(Map<String, dynamic> map) {
    return InstituicaoModel(
      id: map['id'] != null ? map['id'] as int : null,
      nome: map['nome'] != null ? map['nome'] as String : null,
      nomeRazaoSocial: map['nomeRazaoSocial'] != null
          ? map['nomeRazaoSocial'] as String
          : null,
      email: map['email'] != null ? map['email'] as String : null,
      cnpj: map['cnpj'] != null ? map['cnpj'] as String : null,
      cep: map['cep'] != null ? map['cep'] as int : null,
      logradouro:
          map['logradouro'] != null ? map['logradouro'] as String : null,
      numero: map['numero'] as int,
      bairro: map['bairro'] != null ? map['bairro'] as String : null,
      cidade: map['cidade'] != null ? map['cidade'] as String : null,
      estado: map['estado'] != null ? map['estado'] as String : null,
      telefone: map['telefone'] as String?,
      situacao: map['situacao'] != null
          ? SituacaoEnum.fromInt(map['situacao'] as int)
          : null,
      tipoInstituicao: map['tipoInstituicao'] != null
          ? TipoInstituicaoModel.fromMap(
              map['tipoInstituicao'] as Map<String, dynamic>)
          : null,
      secretaria: map['secretaria'] != null
          ? SecretariaModel.fromMap(map['secretaria'] as Map<String, dynamic>)
          : null,
    );
  }

  static String toJson(InstituicaoModel value) => json.encode(value.toMap());

  factory InstituicaoModel.fromJson(String source) => InstituicaoModel.fromMap(
        json.decode(source) as Map<String, dynamic>,
      );
}
