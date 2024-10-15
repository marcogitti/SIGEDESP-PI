import 'dart:convert';

import 'package:front/app/util/situacao_enum.dart';
import 'package:front/app/util/status_de_despesa_enum.dart';

class DespesaModel {
  final int? id;
  final String? numeroDocumento;
  final SituacaoEnum? situacao;
  final String? numeroControle;
  final String? anoMesConsumo;
  final double? quantidadeConsumida;
  final double? valorPrevisto;
  final double? valorPago;
  final DateTime? dataVencimento;
  final DateTime? dataPagamento;
  final int? anoEmissao;
  final int? semestreEmissao;
  final int? trimestreEmissao;
  final int? mesEmissao;
  final int? idUsuario;
  final int? idFornecedor;
  final int? idUnidadeConsumidora;
  final int? idInstituicao;
  final int? idOrcamento;
  final StatusEnum? statusDespesa;
  final int? idTipoDespesa;

  DespesaModel({
    this.id,
    this.numeroDocumento,
    this.situacao,
    this.numeroControle,
    this.anoMesConsumo,
    this.quantidadeConsumida,
    this.valorPrevisto,
    this.valorPago,
    this.dataVencimento,
    this.dataPagamento,
    this.anoEmissao,
    this.semestreEmissao,
    this.trimestreEmissao,
    this.mesEmissao,
    this.idUsuario,
    this.idFornecedor,
    this.idUnidadeConsumidora,
    this.idInstituicao,
    this.idOrcamento,
    this.statusDespesa,
    this.idTipoDespesa,
  });

  DespesaModel copyWith({
    int? id,
    String? numeroDocumento,
    SituacaoEnum? situacao,
    String? numeroControle,
    String? anoMesConsumo,
    double? quantidadeConsumida,
    double? valorPrevisto,
    double? valorPago,
    DateTime? dataVencimento,
    DateTime? dataPagamento,
    int? anoEmissao,
    int? semestreEmissao,
    int? trimestreEmissao,
    int? mesEmissao,
    int? idUsuario,
    int? idFornecedor,
    int? idUnidadeConsumidora,
    int? idInstituicao,
    int? idOrcamento,
    StatusEnum? statusDespesa,
    int? idTipoDespesa,
  }) {
    return DespesaModel(
      id: id ?? this.id,
      numeroDocumento: numeroDocumento ?? this.numeroDocumento,
      situacao: situacao ?? this.situacao,
      numeroControle: numeroControle ?? this.numeroControle,
      anoMesConsumo: anoMesConsumo ?? this.anoMesConsumo,
      quantidadeConsumida: quantidadeConsumida ?? this.quantidadeConsumida,
      valorPrevisto: valorPrevisto ?? this.valorPrevisto,
      valorPago: valorPago ?? this.valorPago,
      dataVencimento: dataVencimento ?? this.dataVencimento,
      dataPagamento: dataPagamento ?? this.dataPagamento,
      anoEmissao: anoEmissao ?? this.anoEmissao,
      semestreEmissao: semestreEmissao ?? this.semestreEmissao,
      trimestreEmissao: trimestreEmissao ?? this.trimestreEmissao,
      mesEmissao: mesEmissao ?? this.mesEmissao,
      idUsuario: idUsuario ?? this.idUsuario,
      idFornecedor: idFornecedor ?? this.idFornecedor,
      idUnidadeConsumidora: idUnidadeConsumidora ?? this.idUnidadeConsumidora,
      idInstituicao: idInstituicao ?? this.idInstituicao,
      idOrcamento: idOrcamento ?? this.idOrcamento,
      statusDespesa: statusDespesa ?? this.statusDespesa,
      idTipoDespesa: idTipoDespesa ?? this.idTipoDespesa,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'numeroDocumento': numeroDocumento,
      'situacao': situacao,
      'numeroControle': numeroControle,
      'anoMesConsumo': anoMesConsumo,
      'quantidadeConsumida': quantidadeConsumida,
      'valorPrevisto': valorPrevisto,
      'valorPago': valorPago,
      'dataVencimento': dataVencimento?.toIso8601String(),
      'dataPagamento': dataPagamento?.toIso8601String(),
      'anoEmissao': anoEmissao,
      'semestreEmissao': semestreEmissao,
      'trimestreEmissao': trimestreEmissao,
      'mesEmissao': mesEmissao,
      'idUsuario': idUsuario,
      'idFornecedor': idFornecedor,
      'idUnidadeConsumidora': idUnidadeConsumidora,
      'idInstituicao': idInstituicao,
      'idOrcamento': idOrcamento,
      'statusDespesa': statusDespesa,
      'idTipoDespesa': idTipoDespesa,
    };
  }

  factory DespesaModel.fromMap(Map<String, dynamic> map) {
    return DespesaModel(
      id: map['id'] as int?,
      numeroDocumento: map['numeroDocumento'] as String?,
      situacao: SituacaoEnum.fromInt(
          map['situacao'] as int), // Converte de índice para enum
      numeroControle: map['numeroControle'] as String?,
      anoMesConsumo: map['anoMesConsumo'] as String?,
      quantidadeConsumida: (map['quantidadeConsumida'] as num?)?.toDouble(),
      valorPrevisto: (map['valorPrevisto'] as num?)?.toDouble(),
      valorPago: (map['valorPago'] as num?)?.toDouble(),
      dataVencimento: map['dataVencimento'] != null
          ? DateTime.parse(map['dataVencimento'])
          : null,
      dataPagamento: map['dataPagamento'] != null
          ? DateTime.parse(map['dataPagamento'])
          : null,
      anoEmissao: map['anoEmissao'] as int?,
      semestreEmissao: map['semestreEmissao'] as int?,
      trimestreEmissao: map['trimestreEmissao'] as int?,
      mesEmissao: map['mesEmissao'] as int?,
      idUsuario: map['idUsuario'] as int?,
      idFornecedor: map['idFornecedor'] as int?,
      idUnidadeConsumidora: map['idUnidadeConsumidora'] as int?,
      idInstituicao: map['idInstituicao'] as int?,
      idOrcamento: map['idOrcamento'] as int?,
      statusDespesa: StatusEnum.fromInt(map['statusDespesa'] as int),
      idTipoDespesa: map['idTipoDespesa'] as int?,
    );
  }

  static String toJson(DespesaModel value) => json.encode(value.toMap());

  factory DespesaModel.fromJson(String source) =>
      DespesaModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
