import 'dart:convert';

class InstituicaoModel {
  final int? id;
  final String situacao;

  InstituicaoModel({
    this.id,
    required this.situacao,
  });
   Map<String, dynamic> toMap() {
    return <String, dynamic>{
      // 'id': id,
      'situacao': situacao,
    };
  }

  String toJson() => json.encode(toMap());

  factory InstituicaoModel.fromMap(Map<String, dynamic> map) {
    return InstituicaoModel(
      id: map['id'] != null ? map['id'] as int : null,
      situacao: map['situacao'] as String,
    );
  }

  factory InstituicaoModel.fromJson(String source) =>
      InstituicaoModel.fromMap(json.decode(source) as Map<String, dynamic>);
}


