// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

class OrcamentoModel {
  final int? id;
  final int? anoOrcamento;
  final double? valorOrcamento;
  final int? idTipoDespesa;
  final int? idInstituicao;

  OrcamentoModel({
    this.id,
    this.anoOrcamento,
    this.valorOrcamento,
    this.idTipoDespesa,
    this.idInstituicao,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'anoOrcamento': anoOrcamento,
      'valorOrcamento': valorOrcamento,
      'idTipoDespesa': idTipoDespesa,
      'idInstituicao': idInstituicao,
    };
  }

  factory OrcamentoModel.fromMap(Map<String, dynamic> map) {
    return OrcamentoModel(
      id: map['id'] != null ? map['id'] as int : null,
      anoOrcamento: map['descricao'] as int,
      valorOrcamento: map['descricao'] as double,
      idTipoDespesa: map['descricao'] as int,
      idInstituicao: map['descricao'] as int,
    );
  }

  static String toJson(OrcamentoModel value) => json.encode(value.toMap());

  factory OrcamentoModel.fromJson(String source) => OrcamentoModel.fromMap(
        json.decode(source) as Map<String, dynamic>,
      );

  OrcamentoModel copyWith({
    int? id,
    int? anoOrcamento,
    int? valorOrcamento,
    int? idTipoDespesa,
    int? idInstituicao,
  }) {
    return OrcamentoModel(
      id: id ?? this.id,
      anoOrcamento: anoOrcamento ?? this.anoOrcamento,
      valorOrcamento: double.maxFinite,
      idTipoDespesa: idTipoDespesa ?? this.idTipoDespesa,
      idInstituicao: idInstituicao ?? this.idInstituicao,
    );
  }
}
