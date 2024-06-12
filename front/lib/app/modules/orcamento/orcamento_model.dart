// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

class OrcamentoModel {
  final int? id;
  final String descricao;
  final String solicitaUc;
  final int idUnidadeMedida;

  OrcamentoModel({
    this.id,
    required this.descricao,
    required this.solicitaUc,
    required this.idUnidadeMedida,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'descricao': descricao,
      'solicitaUc': solicitaUc,
      'idUnidadeMedida': idUnidadeMedida,
    };
  }

  factory OrcamentoModel.fromMap(Map<String, dynamic> map) {
    return OrcamentoModel(
      id: map['id'] != null ? map['id'] as int : null,
      descricao: map['descricao'] as String,
      solicitaUc: map['solicitaUc'] as String,
      idUnidadeMedida: map['idUnidadeMedida'] as int,
    );
  }

  String toJson() => json.encode(toMap());

  factory OrcamentoModel.fromJson(String source) => OrcamentoModel.fromMap(json.decode(source) as Map<String, dynamic>);

  OrcamentoModel copyWith({
    int? id,
    String? descricao,
    String? solicitaUc,
    int? idUnidadeMedida,
  }) {
    return OrcamentoModel(
      id: id ?? this.id,
      descricao: descricao ?? this.descricao,
      solicitaUc: solicitaUc ?? this.solicitaUc,
      idUnidadeMedida: idUnidadeMedida ?? this.idUnidadeMedida,
    );
  }
}
