// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:convert';

import 'package:front/app/modules/despesas/tipo_despesas_model.dart';
import 'package:front/app/modules/fornecedor/fornecedor_model.dart';
import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/modules/login/usuario_model.dart';
import 'package:front/app/modules/orcamento/orcamento_model.dart';
import 'package:front/app/modules/unidade/unidade_consumidora_model.dart';
import 'package:front/app/util/format_util.dart';
import 'package:front/app/util/situacao_enum.dart';
import 'package:front/app/util/status_de_despesa_enum.dart';

class DespesaModel {
  int? id;
  String? numeroDocumento;
  String? numeroControle;
  String? anoMesConsumo;
  double? quantidadeConsumida;
  DateTime? dataVencimento;
  double? valorPrevisto;
  double? valorPago;
  DateTime? dataPagamento;
  int? anoEmissao;
  int? semestreEmissao;
  int? trimestreEmissao;
  int? mesEmissao;
  UsuarioModel? usuario;
  FornecedorModel? fornecedor;
  UnidadeConsumidoraModel? unidadeConsumidora;
  InstituicaoModel? instituicao;
  OrcamentoModel? orcamento;
  StatusEnum? statusDespesa;
  TipoDespesasModel? tipoDespesa;
  SituacaoEnum? situacao;

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
    TipoDespesasModel? tipoDespesa,
    InstituicaoModel? instituicao,
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
    return <String, dynamic>{
      'id': id,
      'numeroDocumento': numeroDocumento,
      'numeroControle': numeroControle,
      'anoMesConsumo': anoMesConsumo,
      'quantidadeConsumida': quantidadeConsumida,
      'dataVencimento': dataVencimento?.toYMD,
      'valorPrevisto': valorPrevisto,
      'valorPago': valorPago,
      'dataPagamento': dataPagamento?.toYMD,
      'anoEmissao': anoEmissao,
      'semestreEmissao': semestreEmissao,
      'trimestreEmissao': trimestreEmissao,
      'mesEmissao': mesEmissao,
      'usuario': usuario?.toMap(),
      'fornecedor': fornecedor?.toMap(),
      'unidadeConsumidora': unidadeConsumidora?.toMap(),
      'instituicao': instituicao?.toMap(),
      'orcamento': orcamento?.toMap(),
      'statusDespesa': statusDespesa?.index,
      'tipoDespesa': tipoDespesa?.toMap(),
      'situacao': situacao?.index,
    };
  }

  factory DespesaModel.fromMap(Map<String, dynamic> map) {
    return DespesaModel(
      id: map['id'] != null ? map['id'] as int : null,
      numeroDocumento:
          map['numeroDocumento'] != null ? map['numeroDocumento'] : null,
      numeroControle:
          map['numeroControle'] != null ? map['numeroControle'] : null,
      anoMesConsumo: map['anoMesConsumo'] != null ? map['anoMesConsumo'] : null,
      quantidadeConsumida: map['quantidadeConsumida'] != null
          ? map['quantidadeConsumida'].toDouble()
          : null,
      dataVencimento: map['dataVencimento'] != null
          ? DateTime.parse(map['dataVencimento'])
          : null,
      valorPrevisto:
          map['valorPrevisto'] != null ? map['valorPrevisto'].toDouble() : null,
      valorPago: map['valorPago'] != null ? map['valorPago'].toDouble() : null,
      dataPagamento: map['dataPagamento'] != null
          ? DateTime.parse(map['dataPagamento'])
          : null,
      anoEmissao: map['anoEmissao'] != null ? map['anoEmissao'] as int : null,
      semestreEmissao:
          map['semestreEmissao'] != null ? map['semestreEmissao'] as int : null,
      trimestreEmissao: map['trimestreEmissao'] != null
          ? map['trimestreEmissao'] as int
          : null,
      mesEmissao: map['mesEmissao'] != null ? map['mesEmissao'] as int : null,
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
      instituicao: map['instituicao'] != null
          ? InstituicaoModel.fromMap(map['instituicao'] as Map<String, dynamic>)
          : null,
      orcamento: map['orcamento'] != null
          ? OrcamentoModel.fromMap(map['orcamento'] as Map<String, dynamic>)
          : null,
      statusDespesa: map['statusDespesa'] != null
          ? StatusEnum.fromInt(map['statusDespesa'])
          : null,
      tipoDespesa: map['tipoDespesa'] != null
          ? TipoDespesasModel.fromMap(
              map['tipoDespesa'] as Map<String, dynamic>)
          : null,
      situacao: map['situacao'] != null
          ? SituacaoEnum.fromInt(map['situacao'])
          : null,
    );
  }

  static String toJson(DespesaModel value) => json.encode(value.toMap());

  factory DespesaModel.fromJson(String source) =>
      DespesaModel.fromMap(json.decode(source) as Map<String, dynamic>);
}
