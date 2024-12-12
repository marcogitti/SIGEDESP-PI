class StatusDespesaModel {
  final String status;
  final int quantidade;

  StatusDespesaModel({required this.status, required this.quantidade});

  // Dados fictícios para consumo
  static List<StatusDespesaModel> dadosFicticios() {
    return [
      StatusDespesaModel(status: 'A Pagar', quantidade: 5),
      StatusDespesaModel(status: 'Pago', quantidade: 3),
      StatusDespesaModel(status: 'Pendente', quantidade: 7),
    ];
  }
}
