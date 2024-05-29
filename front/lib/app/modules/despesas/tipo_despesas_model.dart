// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

class TipoDespesasModel {
  final int? id;
  final String tipoDespesa;
  final String? solicitaUC;

  TipoDespesasModel({
    this.id,
    required this.tipoDespesa,
    this.solicitaUC,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'tipoDespesa': tipoDespesa,
      'solicitaUC': solicitaUC,
    };
  }

  String toJson() => json.encode(toMap());

  factory TipoDespesasModel.fromMap(Map<String, dynamic> map) {
    return TipoDespesasModel(
      id: map['id'] != null ? map['id'] as int : null,
      tipoDespesa: map['tipoDespesa'] as String,
      solicitaUC:
          map['solicitaUC'] != null ? map['solicitaUC'] as String : null,
    );
  }

  factory TipoDespesasModel.fromJson(String source) =>
      TipoDespesasModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
