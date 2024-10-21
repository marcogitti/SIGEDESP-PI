// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

class UnidadeConsumidoraModel {
  final int? id;
  final int? codigoUC;
  final int? idFornecedor;
  final int? idInstituicao;

  UnidadeConsumidoraModel({
    this.id,
    this.codigoUC,
    this.idFornecedor,
    this.idInstituicao,
  });

  UnidadeConsumidoraModel copyWith({
    int? id,
    int? codigoUC,
    int? idFornecedor,
    int? idInstituicao,
  }) {
    return UnidadeConsumidoraModel(
      codigoUC: codigoUC ?? this.codigoUC,
      idFornecedor: idFornecedor ?? this.idFornecedor,
      idInstituicao: idInstituicao ?? this.idInstituicao,
    );
  }

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'codigoUC': codigoUC,
      'idFornecedor': idFornecedor,
      'idInstituicao': idInstituicao,
    };
  }

  factory UnidadeConsumidoraModel.fromMap(Map<String, dynamic> map) {
    return UnidadeConsumidoraModel(
      id: map['id'] != null ? map['id'] as int : null,
      codigoUC: map['codigoUC'] != null ? map['codigoUC'] as int : null,
      idFornecedor:
          map['idFornecedor'] != null ? map['idFornecedor'] as int : null,
      idInstituicao:
          map['idInstituicao'] != null ? map['idInstituicao'] as int : null,
    );
  }

  static String toJson(UnidadeConsumidoraModel value) =>
      json.encode(value.toMap());

  factory UnidadeConsumidoraModel.fromJson(String source) =>
      UnidadeConsumidoraModel.fromMap(
        json.decode(source) as Map<String, dynamic>,
      );
}
