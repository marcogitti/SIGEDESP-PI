import 'dart:convert';

class TipoInstituicaoModel {
  final int? id;
  final String tipoInstituicao;

  TipoInstituicaoModel({
    this.id,
    required this.tipoInstituicao,
  });
    Map<String, dynamic> toMap() {
    return <String, dynamic>{
      // 'id': id,
      'tipoInstituicao': tipoInstituicao,
    };
  }

  String toJson() => json.encode(toMap());

  factory TipoInstituicaoModel.fromMap(Map<String, dynamic> map) {
    return TipoInstituicaoModel(
      id: map['id'] != null ? map['id'] as int : null,
      tipoInstituicao: map['situacao'] as String,
    );
  }

  factory TipoInstituicaoModel.fromJson(String source) =>
      TipoInstituicaoModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
