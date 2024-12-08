// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

import 'package:front/app/modules/unidade/unidade_de_medida_model.dart';
import 'package:front/app/util/solicita_uc_enum.dart';

class TipoDespesasModel {
  int? id;
  String? descricao;
  SolicitaUcEnum? solicitaUC;
  UnidadeDeMedidaModel? unidadeMedida;

  TipoDespesasModel({
    this.id,
    this.descricao,
    this.solicitaUC,
    this.unidadeMedida,
  });

  TipoDespesasModel copyWith({
    int? id,
    String? descricao,
    SolicitaUcEnum? solicitaUC,
    UnidadeDeMedidaModel? unidadeMedida,
  }) {
    return TipoDespesasModel(
      id: id ?? this.id,
      descricao: descricao ?? this.descricao,
      solicitaUC: solicitaUC ?? this.solicitaUC,
      unidadeMedida: unidadeMedida ?? this.unidadeMedida,
    );
  }

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'descricao': descricao,
      'solicitaUC': solicitaUC?.index,
      'unidadeMedida': unidadeMedida?.toMap(),
    };
  }

  factory TipoDespesasModel.fromMap(Map<String, dynamic> map) {
    return TipoDespesasModel(
      id: map['id'] != null ? map['id'] as int : null,
      descricao: map['descricao'] != null ? map['descricao'] as String : null,
      solicitaUC: SolicitaUcEnum.fromInt(map['solicitaUC'] ?? 0),
      unidadeMedida: map['unidadeMedida'] != null
          ? UnidadeDeMedidaModel.fromMap(
              map['unidadeMedida'] as Map<String, dynamic>)
          : null,
    );
  }

  static String toJson(TipoDespesasModel value) => json.encode(value.toMap());

  factory TipoDespesasModel.fromJson(String source) =>
      TipoDespesasModel.fromMap(json.decode(source) as Map<String, dynamic>);

  @override
  bool operator ==(covariant TipoDespesasModel other) {
    if (identical(this, other)) return true;

    return other.id == id;
    ;
  }

  @override
  int get hashCode {
    return id.hashCode;
  }
}
