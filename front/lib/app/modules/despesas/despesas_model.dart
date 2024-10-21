import 'dart:convert';

import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/modules/despesas/tipo_despesas_model.dart';
import 'package:front/app/modules/fornecedor/fornecedor_model.dart';
import 'package:front/app/modules/login/usuario_model.dart';
import 'package:front/app/modules/orcamento/orcamento_model.dart';
import 'package:front/app/modules/unidade/unidade_consumidora_model.dart';
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
  final UsuarioModel? usuario;
  final FornecedorModel? fornecedor;
  final UnidadeConsumidoraModel? unidadeConsumidora;
  final InstituicaoModel? instituicao;
  final OrcamentoModel? orcamento;
  final StatusEnum? statusDespesa;
  final TipoDespesasModel? tipoDespesa;

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
    this.usuario,
    this.fornecedor,
    this.unidadeConsumidora,
    this.instituicao,
    this.orcamento,
    this.statusDespesa,
    this.tipoDespesa,
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
    UsuarioModel? usuario,
    FornecedorModel? fornecedor,
    UnidadeConsumidoraModel? unidadeConsumidora,
    InstituicaoModel? idInstituicao,
    OrcamentoModel? orcamento,
    StatusEnum? statusDespesa,
    TipoDespesasModel? tipoDespesa, InstituicaoModel? instituicao,
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
      usuario: usuario ?? this.usuario,
      fornecedor: fornecedor ?? this.fornecedor,
      unidadeConsumidora: unidadeConsumidora ?? this.unidadeConsumidora,
      instituicao: idInstituicao ?? this.instituicao,
      orcamento: orcamento ?? this.orcamento,
      statusDespesa: statusDespesa ?? this.statusDespesa,
      tipoDespesa: tipoDespesa ?? this.tipoDespesa,
    );
  }

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'numeroDocumento': numeroDocumento,
      'situacao': situacao?.index,
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
      'usuario': usuario?.toMap(),
      'fornecedor': fornecedor?.toMap(),
      'unidadeConsumidora': unidadeConsumidora?.toMap(),
      'idInstituicao': instituicao?.toMap(),
      'orcamento': orcamento?.toMap(),
      'statusDespesa': statusDespesa?.index,
      'tipoDespesa': tipoDespesa?.toMap(),
    };
  }

  factory DespesaModel.fromMap(Map<String, dynamic> map) {
    return DespesaModel(
      id: map['id'] as int?,
      numeroDocumento: map['numeroDocumento'] as String?,
      situacao: SituacaoEnum.fromInt(map['situacao'] as int),
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
      usuario: map['usuario'] != null
          ? UsuarioModel.fromMap(map['usuario'] as Map<String, dynamic>)
          : null,
      fornecedor: map['fornecedor'] != null
          ? FornecedorModel.fromMap(map['fornecedor'] as Map<String, dynamic>)
          : null,
      unidadeConsumidora: map['unidadeConsumidora'] != null
          ? UnidadeConsumidoraModel.fromMap(
              map['unidadeConsumidora'] as Map<String, dynamic>)
          : null,
      instituicao: map['idInstituicao'] != null
          ? InstituicaoModel.fromMap(
              map['idInstituicao'] as Map<String, dynamic>)
          : null,
      orcamento: map['orcamento'] != null
          ? OrcamentoModel.fromMap(map['orcamento'] as Map<String, dynamic>)
          : null,
      statusDespesa: StatusEnum.fromInt(map['statusDespesa'] as int),
      tipoDespesa: map['tipoDespesa'] != null
          ? TipoDespesasModel.fromMap(
              map['tipoDespesa'] as Map<String, dynamic>)
          : null,
    );
  }

  static String toJson(DespesaModel value) => json.encode(value.toMap());

  factory DespesaModel.fromJson(String source) =>
      DespesaModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
