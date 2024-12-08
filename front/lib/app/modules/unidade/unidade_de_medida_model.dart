// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

class UnidadeDeMedidaModel {
  int? id;
  String? descricao;
  String? abreviatura;

  UnidadeDeMedidaModel({
    this.id,
    this.descricao,
    this.abreviatura,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'descricao': descricao,
      'abreviatura': abreviatura,
    };
  }

  static String toJson(UnidadeDeMedidaModel value) =>
      json.encode(value.toMap());

  factory UnidadeDeMedidaModel.fromMap(Map<String, dynamic> map) {
    return UnidadeDeMedidaModel(
      id: map['id'] != null ? map['id'] as int : null,
      abreviatura: map['abreviatura'] as String?,
      descricao: map['descricao'] as String?,
    );
  }

  factory UnidadeDeMedidaModel.fromJson(String source) =>
      UnidadeDeMedidaModel.fromMap(json.decode(source) as Map<String, dynamic>);
  UnidadeDeMedidaModel copyWith({
    int? id,
    String? descricao,
    String? abreviatura,
  }) {
    return UnidadeDeMedidaModel(
      id: id ?? this.id,
      descricao: descricao ?? descricao,
      abreviatura: abreviatura ?? abreviatura,
    );
  }

  @override
  bool operator ==(covariant UnidadeDeMedidaModel other) {
    if (identical(this, other)) return true;

    return other.id == id;
  }

  @override
  int get hashCode => id.hashCode;
}
