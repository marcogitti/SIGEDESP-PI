enum SituacaoEnum {
  inativo,
  ativo;

  factory SituacaoEnum.fromInt(int value) {
    return values[value];
  }
}
