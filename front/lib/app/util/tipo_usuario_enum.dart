enum TipoUsuarioEnum {
  administrador(numero: 0, nome: 'Administrador'),
  funcionario(numero: 1, nome: 'Funcionario'),
  visitante(numero: 2, nome: 'Visitante');

  final int numero;
  final String nome;

  const TipoUsuarioEnum({required this.numero, required this.nome});

  factory TipoUsuarioEnum.fromInt(int value) {
    return TipoUsuarioEnum.values
        .firstWhere((element) => element.numero == value);
  }
}

