enum SituacaoEnum {
  inativo(nome: 'Inativo'),
  ativo(nome: 'Ativo');

  final String nome;

  const SituacaoEnum({required this.nome});

  factory SituacaoEnum.fromInt(int value) {
    return values.firstWhere((element) => element.index == value);
  }
}
