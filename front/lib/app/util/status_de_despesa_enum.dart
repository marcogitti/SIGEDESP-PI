import 'package:flutter/material.dart';

enum StatusEnum {
  apagar(numero: 0, nome: 'A Pagar', cor: Colors.orange),
  pago(numero: 1, nome: 'Pago', cor: Colors.green),
  pendente(numero: 0, nome: 'Pendente', cor: Colors.red);

  final int numero;
  final String nome;
  final Color cor;

  const StatusEnum(
      {required this.numero, required this.nome, required this.cor});

  factory StatusEnum.fromInt(int value) {
    return StatusEnum.values.firstWhere(
      (element) => element.numero == value,
    );
  }
}
