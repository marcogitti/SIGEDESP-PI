import 'dart:convert';

import 'package:front/app/modules/unidade/unidade_de_medida_model.dart';
import 'package:front/app/util/solicita_uc_enum.dart';

class TipoDespesasModel {
  final int? id;
  final String? descricao;
  final SolicitaUcEnum? solicitaUC;
  final UnidadeDeMedidaModel? unidadeMedida;

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
      'solicitaUC': solicitaUC?.numero,
      'idUnidadeMedida': unidadeMedida?.id,
    };
  }

  factory TipoDespesasModel.fromMap(Map<String, dynamic> map) {
    return TipoDespesasModel(
      id: map['id'] != null ? map['id'] as int : null,
      descricao: map['descricao'] != null ? map['descricao'] as String : null,
      solicitaUC: map['solicitaUC'] != null
          ? SolicitaUcEnum.fromInt(map['solicitaUC'] as int)
          : null,
      unidadeMedida: map['idUnidadeMedida'] != null
          ? UnidadeDeMedidaModel(id: map['idUnidadeMedida'] as int)
          : null,
    );
  }

  static String toJson(TipoDespesasModel value) => json.encode(value.toMap());

  factory TipoDespesasModel.fromJson(String source) =>
      TipoDespesasModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
