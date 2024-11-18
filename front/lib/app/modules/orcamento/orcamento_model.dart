// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/modules/despesas/tipo_despesas_model.dart';

class OrcamentoModel {
  int? id;
  int? anoOrcamento;
  double? valorOrcamento;
  TipoDespesasModel? tipoDespesa;
  InstituicaoModel? instituicao;

  OrcamentoModel({
    this.id,
    this.anoOrcamento,
    this.valorOrcamento,
    this.tipoDespesa,
    this.instituicao,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'anoOrcamento': anoOrcamento,
      'valorOrcamento': valorOrcamento,
      'tipoDespesa': tipoDespesa?.toMap(),
      'instituicao': instituicao?.toMap(),
    };
  }

  factory OrcamentoModel.fromMap(Map<String, dynamic> map) {
    return OrcamentoModel(
      id: map['id'] != null ? map['id'] as int : null,
      anoOrcamento:
          map['anoOrcamento'] != null ? map['anoOrcamento'] as int : null,
      valorOrcamento: map['valorOrcamento']?.toDouble(),
      tipoDespesa: map['tipoDespesa'] != null
          ? TipoDespesasModel.fromMap(
              map['tipoDespesa'] as Map<String, dynamic>)
          : null,
      instituicao: map['instituicao'] != null
          ? InstituicaoModel.fromMap(map['instituicao'] as Map<String, dynamic>)
          : null,
    );
  }

  static String toJson(OrcamentoModel value) => json.encode(value.toMap());

  factory OrcamentoModel.fromJson(String source) => OrcamentoModel.fromMap(
        json.decode(source) as Map<String, dynamic>,
      );

  OrcamentoModel copyWith({
    int? id,
    int? anoOrcamento,
    double? valorOrcamento,
    TipoDespesasModel? tipoDespesa,
    InstituicaoModel? instituicao,
  }) {
    return OrcamentoModel(
      id: id ?? this.id,
      anoOrcamento: anoOrcamento ?? this.anoOrcamento,
      valorOrcamento: valorOrcamento ?? this.valorOrcamento,
      tipoDespesa: tipoDespesa ?? this.tipoDespesa,
      instituicao: instituicao ?? this.instituicao,
    );
  }
}
