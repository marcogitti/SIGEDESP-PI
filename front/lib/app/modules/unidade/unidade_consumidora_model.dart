// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/modules/fornecedor/fornecedor_model.dart';

class UnidadeConsumidoraModel {
  int? id;
  int? codigoUC;
  FornecedorModel? fornecedor;
  InstituicaoModel? instituicao;

  UnidadeConsumidoraModel({
    this.id,
    this.codigoUC,
    this.fornecedor,
    this.instituicao,
  });

  UnidadeConsumidoraModel copyWith({
    int? id,
    int? codigoUC,
    FornecedorModel? fornecedor,
    InstituicaoModel? instituicao,
  }) {
    return UnidadeConsumidoraModel(
      id: id ?? this.id,
      codigoUC: codigoUC ?? this.codigoUC,
      fornecedor: fornecedor ?? this.fornecedor,
      instituicao: instituicao ?? this.instituicao,
    );
  }

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'codigoUC': codigoUC,
      'fornecedor': fornecedor?.toMap(),
      'instituicao': instituicao?.toMap(),
    };
  }

  factory UnidadeConsumidoraModel.fromMap(Map<String, dynamic> map) {
    return UnidadeConsumidoraModel(
      id: map['id'] != null ? map['id'] as int : null,
      codigoUC: map['codigoUC'] != null ? map['codigoUC'] as int : null,
      fornecedor: map['fornecedor'] != null
          ? FornecedorModel.fromMap(map['fornecedor'] as Map<String, dynamic>)
          : null,
      instituicao: map['instituicao'] != null
          ? InstituicaoModel.fromMap(map['instituicao'] as Map<String, dynamic>)
          : null,
    );
  }

  static String toJson(UnidadeConsumidoraModel value) =>
      json.encode(value.toMap());

  factory UnidadeConsumidoraModel.fromJson(String source) =>
      UnidadeConsumidoraModel.fromMap(
          json.decode(source) as Map<String, dynamic>);
}
