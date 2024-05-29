// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

class SecretariaModel {
  final int? id;
  final String? descricao;
  final String? situacao;

  SecretariaModel({
    this.id,
    this.descricao,
    this.situacao,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'descricao': descricao,
      'situacao': situacao,
    };
  }

  factory SecretariaModel.fromMap(Map<String, dynamic> map) {
    return SecretariaModel(
      id: map['id'] != null ? map['id'] as int : null,
      descricao: map['descricao'] != null ? map['descricao'] as String : null,
      situacao: map['situacao'] != null ? map['situacao'] as String : null,
    );
  }

  String toJson() => json.encode(toMap());

  factory SecretariaModel.fromJson(String source) =>
      SecretariaModel.fromMap(json.decode(source) as Map<String, dynamic>);

  SecretariaModel copyWith({
    int? id,
    String? descricao,
    String? situacao,
  }) {
    return SecretariaModel(
      id: id ?? this.id,
      descricao: descricao ?? this.descricao,
      situacao: situacao ?? this.situacao,
    );
  }
}
