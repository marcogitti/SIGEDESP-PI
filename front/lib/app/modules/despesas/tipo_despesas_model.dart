import 'dart:convert';

class TipoDespesasModel {
  final int? id;
  final String? descricao;
  final String? solicitaUC;
  final int? idUnidadeMedida;

  TipoDespesasModel({
    this.id,
    this.descricao,
    this.solicitaUC,
    this.idUnidadeMedida,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'descricao': descricao,
      'solicitaUC': solicitaUC,
      'idUnidadeMedida': idUnidadeMedida,
    };
  }

  static String toJson(TipoDespesasModel value) => json.encode(value.toMap());

  factory TipoDespesasModel.fromMap(Map<String, dynamic> map) {
    return TipoDespesasModel(
      id: map['id'] != null ? map['id'] as int : null,
      descricao: map['descricao'] as String,
      solicitaUC:
          map['solicitaUC'] != null ? map['solicitaUC'] as String : null,
      idUnidadeMedida:
          map['idUnidadeMedida'] != null ? map['idUnidadeMedida'] as int : null,
    );
  }

  factory TipoDespesasModel.fromJson(String source) =>
      TipoDespesasModel.fromMap(json.decode(source) as Map<String, dynamic>);

  TipoDespesasModel copyWith({
    int? id,
    String? descricao,
    String? solicitaUC,
    int? idUnidadeMedida,
  }) {
    return TipoDespesasModel(
      id: id ?? this.id,
      descricao: descricao ?? this.descricao,
      solicitaUC: solicitaUC ?? this.solicitaUC,
      idUnidadeMedida: idUnidadeMedida ?? this.idUnidadeMedida,
    );
  }
}
