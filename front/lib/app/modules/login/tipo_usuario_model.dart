class TipoUsuarioModel {
  final int? id;
  final String descricao;
  final bool permiteLogin;

  TipoUsuarioModel(
    this.descricao,
    this.permiteLogin, {
    required this.id,
  });
}
