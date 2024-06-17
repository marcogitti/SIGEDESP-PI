import 'dart:convert';

class TipoInstituicaoModel {
  final int? id;
  final String? descricao;

  TipoInstituicaoModel({
    this.id,
    this.descricao,
  });
  Map<String, dynamic> toMap() {
    return <String, dynamic>{
      // 'id': id,
      'descricao': descricao,
    };
  }

  String toJson() => json.encode(toMap());

  factory TipoInstituicaoModel.fromMap(Map<String, dynamic> map) {
    return TipoInstituicaoModel(
      id: map['id'] != null ? map['id'] as int : null,
      descricao: map['descricao'] as String,
    );
  }

  factory TipoInstituicaoModel.fromJson(String source) =>
      TipoInstituicaoModel.fromMap(json.decode(source) as Map<String, dynamic>);
  
  TipoInstituicaoModel copyWith({
    int? id,
    String? descricao,
  }) {
    return TipoInstituicaoModel(
      id: id ?? this.id,
      descricao: descricao ?? descricao,
    );
  }
}
