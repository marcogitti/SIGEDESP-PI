enum SolicitaUcEnum {
  nao(numero: 0, nome: 'Não'),
  sim(numero: 1, nome: 'Sim');

  final int numero;
  final String nome;

  const SolicitaUcEnum({required this.numero, required this.nome});

  static SolicitaUcEnum fromInt(int value) {
    return SolicitaUcEnum.values.firstWhere(
      (element) => element.numero == value,
    );
  }
}
