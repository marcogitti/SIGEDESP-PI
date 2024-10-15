enum StatusEnum {
  apagar(numero: 0,nome: 'A Pagar'),
  pago(numero:1, nome: 'Pago'),
  pendente(numero:0, nome: 'Pendente');

  final int numero;
  final String nome;

  const StatusEnum({required this.numero, required this.nome});

  factory StatusEnum.fromInt(int value) {
    return StatusEnum.values.firstWhere(
      (element) => element.numero == value,
    );
  }
}
