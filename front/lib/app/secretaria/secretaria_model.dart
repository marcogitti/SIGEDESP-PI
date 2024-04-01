class SecretariaModel {
  final int? id;
  final String descricao;
  final String situacao;

  SecretariaModel(
    this.descricao,
    this.situacao, {
    required this.id,
  });
}
