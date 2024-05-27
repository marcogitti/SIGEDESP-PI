// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

class InstituicaoModel {
  final int? id;
  final String? situacao;
  final int? idTipoInstituicao;
  final int? idSecretaria;

  InstituicaoModel({
    this.id,
    this.situacao,
    this.idTipoInstituicao,
    this.idSecretaria,
  });

  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      'id': id,
      'situacao': situacao,
      'idTipoInstituicao': idTipoInstituicao,
      'idSecretaria': idSecretaria,
    };
  }

  factory InstituicaoModel.fromMap(Map<String, dynamic> map) {
    return InstituicaoModel(
      id: map['id'] != null ? map['id'] as int : null,
      situacao: map['situacao'] as String,
      idTipoInstituicao: map['idTipoInstituicao'] as int,
      idSecretaria: map['idSecretaria'] as int,
    );
  }

  String toJson() => json.encode(toMap());

  factory InstituicaoModel.fromJson(String source) =>
      InstituicaoModel.fromMap(json.decode(source) as Map<String, dynamic>);

  InstituicaoModel copyWith({
    int? id,
    String? situacao,
    int? idTipoInstituicao,
    int? idSecretaria,
  }) {
    return InstituicaoModel(
      id: id ?? this.id,
      situacao: situacao ?? this.situacao,
      idTipoInstituicao: idTipoInstituicao ?? this.idTipoInstituicao,
      idSecretaria: idSecretaria ?? this.idSecretaria,
    );
  }
}
