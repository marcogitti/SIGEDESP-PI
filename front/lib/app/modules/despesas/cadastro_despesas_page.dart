import 'dart:math';

import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_drop_down_comp.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/Instituicao/instituicao_model.dart';
import 'package:front/app/modules/Instituicao/instituicao_service.dart';
import 'package:front/app/modules/despesas/despesas_model.dart';
import 'package:front/app/modules/despesas/despesas_service.dart';
import 'package:front/app/modules/despesas/tipo_despesas_model.dart';
import 'package:front/app/modules/despesas/tipo_despesas_service.dart';
import 'package:front/app/modules/fornecedor/fornecedor_model.dart';
import 'package:front/app/modules/fornecedor/fornecedor_service.dart';
import 'package:front/app/modules/login/usuario_model.dart';
import 'package:front/app/modules/login/usuario_service.dart';
import 'package:front/app/modules/orcamento/orcamento_model.dart';
import 'package:front/app/modules/orcamento/orcamento_service.dart';
import 'package:front/app/modules/unidade/unidade_consumidora_model.dart';
import 'package:front/app/modules/unidade/unidade_consumidora_sevice.dart';
import 'package:front/app/util/situacao_enum.dart';
import 'package:front/app/util/status_de_despesa_enum.dart';

class CadastroDeDespesas extends StatefulWidget {
  const CadastroDeDespesas({Key? key}) : super(key: key);

  @override
  // ignore: library_private_types_in_public_api
  _CadastroDeDespesasState createState() => _CadastroDeDespesasState();
}

class _CadastroDeDespesasState extends State<CadastroDeDespesas> {
  final service = Modular.get<DespesasServiceImpl>();

  final TextEditingController _numeroDocumentoController =
      TextEditingController();
  final TextEditingController _situacaoController = TextEditingController();
  final TextEditingController _numeroControleController =
      TextEditingController();
  final TextEditingController _anoMesConsumoController =
      TextEditingController();
  final TextEditingController _quantidadeConsumidaController =
      TextEditingController();
  final TextEditingController _valorPrevistoController =
      TextEditingController();
  final TextEditingController _valorPagoController = TextEditingController();
  final TextEditingController _dataVencimentoController =
      TextEditingController();
  final TextEditingController _dataPagamentoController =
      TextEditingController();
  final TextEditingController _anoEmissaoController = TextEditingController();
  final TextEditingController _semestreEmissaoController =
      TextEditingController();
  final TextEditingController _trimestreEmissaoController =
      TextEditingController();
  final TextEditingController _mesEmissaoController = TextEditingController();
  final TextEditingController _idUsuarioController = TextEditingController();
  final TextEditingController _idFornecedorController = TextEditingController();
  final TextEditingController _idUnidadeConsumidoraController =
      TextEditingController();
  final TextEditingController _idInstituicaoController =
      TextEditingController();
  final TextEditingController _idOrcamentoController = TextEditingController();
  final TextEditingController _statusDespesaController =
      TextEditingController();
  final TextEditingController _idTipoDespesaController =
      TextEditingController();

  List<DespesaModel> despesasList = [];

  void _showCadastroDialog(BuildContext context) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text('Cadastro de Despesas'),
          content: SingleChildScrollView(
            child: Column(
              children: [
                TextField(
                  controller: _numeroDocumentoController,
                  decoration:
                      const InputDecoration(hintText: 'Número do Documento'),
                ),
                TextField(
                  controller: _situacaoController,
                  decoration: const InputDecoration(
                      hintText: 'Situação (0 - Inativo, 1 - Ativo)'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _numeroControleController,
                  decoration:
                      const InputDecoration(hintText: 'Número de Controle'),
                ),
                TextField(
                  controller: _anoMesConsumoController,
                  decoration:
                      const InputDecoration(hintText: 'Ano/Mês Consumo'),
                ),
                TextField(
                  controller: _quantidadeConsumidaController,
                  decoration:
                      const InputDecoration(hintText: 'Quantidade Consumida'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _valorPrevistoController,
                  decoration: const InputDecoration(hintText: 'Valor Previsto'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _valorPagoController,
                  decoration: const InputDecoration(hintText: 'Valor Pago'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _dataVencimentoController,
                  decoration: const InputDecoration(
                      hintText: 'Data de Vencimento (yyyy-mm-dd)'),
                ),
                TextField(
                  controller: _dataPagamentoController,
                  decoration: const InputDecoration(
                      hintText: 'Data de Pagamento (yyyy-mm-dd)'),
                ),
                TextField(
                  controller: _anoEmissaoController,
                  decoration: const InputDecoration(hintText: 'Ano de Emissão'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _semestreEmissaoController,
                  decoration:
                      const InputDecoration(hintText: 'Semestre de Emissão'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _trimestreEmissaoController,
                  decoration:
                      const InputDecoration(hintText: 'Trimestre de Emissão'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _mesEmissaoController,
                  decoration: const InputDecoration(hintText: 'Mês de Emissão'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _idUsuarioController,
                  decoration: const InputDecoration(hintText: 'ID Usuário'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _idFornecedorController,
                  decoration: const InputDecoration(hintText: 'ID Fornecedor'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _idUnidadeConsumidoraController,
                  decoration:
                      const InputDecoration(hintText: 'ID Unidade Consumidora'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _idInstituicaoController,
                  decoration: const InputDecoration(hintText: 'ID Instituição'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _idOrcamentoController,
                  decoration: const InputDecoration(hintText: 'ID Orçamento'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _statusDespesaController,
                  decoration:
                      const InputDecoration(hintText: 'Status da Despesa'),
                  keyboardType: TextInputType.number,
                ),
                TextField(
                  controller: _idTipoDespesaController,
                  decoration:
                      const InputDecoration(hintText: 'ID Tipo de Despesa'),
                  keyboardType: TextInputType.number,
                ),
              ],
            ),
          ),
          actions: <Widget>[
            TextButton(
              child: const Text('Cancelar'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            TextButton(
              child: const Text('Salvar'),
              onPressed: () {
                final despesa = DespesaModel(
                  numeroDocumento: _numeroDocumentoController.text,
                  situacao: SituacaoEnum.fromInt(
                      int.tryParse(_situacaoController.text) ?? 0),
                  numeroControle: _numeroControleController.text,
                  anoMesConsumo: _anoMesConsumoController.text,
                  quantidadeConsumida:
                      double.tryParse(_quantidadeConsumidaController.text) ??
                          0.0,
                  valorPrevisto:
                      double.tryParse(_valorPrevistoController.text) ?? 0.0,
                  valorPago: double.tryParse(_valorPagoController.text) ?? 0.0,
                  dataVencimento:
                      DateTime.tryParse(_dataVencimentoController.text) ??
                          DateTime.now(),
                  dataPagamento:
                      DateTime.tryParse(_dataPagamentoController.text) ??
                          DateTime.now(),
                  anoEmissao: int.tryParse(_anoEmissaoController.text) ?? 0,
                  semestreEmissao:
                      int.tryParse(_semestreEmissaoController.text) ?? 0,
                  trimestreEmissao:
                      int.tryParse(_trimestreEmissaoController.text) ?? 0,
                  mesEmissao: int.tryParse(_mesEmissaoController.text) ?? 0,
                  idUsuario: int.tryParse(_idUsuarioController.text) ?? 0,
                  idFornecedor: int.tryParse(_idFornecedorController.text) ?? 0,
                  idUnidadeConsumidora:
                      int.tryParse(_idUnidadeConsumidoraController.text) ?? 0,
                  idInstituicao:
                      int.tryParse(_idInstituicaoController.text) ?? 0,
                  idOrcamento: int.tryParse(_idOrcamentoController.text) ?? 0,
                  statusDespesa: StatusEnum.fromInt(
                      int.tryParse(_statusDespesaController.text) ?? 0),
                  idTipoDespesa:
                      int.tryParse(_idTipoDespesaController.text) ?? 0,
                );

                // Aqui você pode adicionar a lógica de salvamento conforme sua necessidade
                setState(() {
                  despesasList.add(despesa);
                });

                Navigator.of(context).pop();
              },
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return ScaffoldComp(
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            const Padding(
              padding: EdgeInsets.only(bottom: 50),
              child: Text(
                "Cadastro de Despesas",
                style: TextStyle(
                  fontSize: 30,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            ElevatedButton(
              onPressed: () {
                _showCadastroDialog(context);
              },
              child: const Text('Cadastrar Nova Despesa'),
            ),
            const SizedBox(height: 20),
            _buildDataTable(),
          ],
        ),
      ),
    );
  }

  Widget _buildDataTable() {
    if (despesasList.isEmpty) {
      return const Center(
        child: Text("Nenhuma despesa cadastrada."),
      );
    }

    return DataTable(
      columns: const [
        DataColumn(label: Text('Id')),
        DataColumn(label: Text('Tipo Despesa')),
        DataColumn(label: Text('Número Documento')),
        DataColumn(label: Text('Número Controle')),
        DataColumn(label: Text('Instituição')),
        DataColumn(label: Text('Fornecedor')),
        DataColumn(label: Text('Status')),
        DataColumn(label: Text('Situação')),
        DataColumn(label: Text('Ações')),
      ],
      rows: despesasList
          .map((e) {
            return DataRow(cells: [
              DataCell(Text(e.id?.toString() ?? '')),
              DataCell(Text(e.idTipoDespesa?.toString() ?? '')),
              DataCell(Text(e.numeroDocumento?.toString() ?? '')),
              DataCell(Text(e.numeroControle?.toString() ?? '')),
              DataCell(Text(e.idInstituicao?.toString() ?? '')),
              DataCell(Text(e.idFornecedor?.toString() ?? '')),
              DataCell(Text(e.statusDespesa?.toString() ?? '')),
              DataCell(Text(e.situacao?.toString() ?? '')),
              DataCell(Row(
                children: [
                  IconButton(
                    icon: const Icon(
                      Icons.edit,
                      color: Color(0xFF0044FF),
                    ),
                    onPressed: () async {
                      await modalCadastrar(e);
                    },
                  ),
                  IconButton(
                    icon: const Icon(
                      Icons.delete,
                      color: Color(0xFFF44336),
                    ),
                    onPressed: () async {
                      await showDialog<bool>(
                        context: context,
                        builder: (BuildContext context) {
                          return AlertDialog(
                            title: const Text('Confirmar exclusão'),
                            content: const Text(
                                'Tem certeza que deseja excluir este item?'),
                            actions: <Widget>[
                              TextButton(
                                child: const Text('Cancelar'),
                                onPressed: () {
                                  Modular.to.pop(false);
                                },
                              ),
                              TextButton(
                                child: const Text('Confirmar'),
                                onPressed: () async {
                                  Modular.to.pop();
                                  if (e.id != null) {
                                    await service.deleteData(e.id!);
                                    setState(() {});
                                  }
                                },
                              ),
                            ],
                          );
                        },
                      );
                    },
                  ),
                ],
              )),
            ]);
          })
          .toList()
          .cast<DataRow>(),
    );
  }

  Future<void> modalCadastrar([DespesaModel? despesas]) async {
    final isEdit = despesas?.id != null;
    despesas ??= DespesaModel();

    int? selectedUsuarioId;
    int? selectedFornecedorId;
    int? selectedUnidadeConsumidoraId;
    int? selectedInstituicaoId;
    int? selectedOrcamentoId;
    int? selectedTipoDespesaId;
    StatusEnum? selectedStatusDespesa = despesas.statusDespesa; // Inicialização
    SituacaoEnum situacao =
        despesas.situacao ?? SituacaoEnum.values.first; // Inicialização

    // Criar controladores para cada campo
    final numeroDocumentoController =
        TextEditingController(text: despesas.numeroDocumento ?? '');
    final numeroControleController =
        TextEditingController(text: despesas.numeroControle ?? '');
    final anoMesConsumoController =
        TextEditingController(text: despesas.anoMesConsumo ?? '');
    final quantidadeConsumidaController = TextEditingController(
        text: despesas.quantidadeConsumida?.toString() ?? '');
    final valorPrevistoController =
        TextEditingController(text: despesas.valorPrevisto?.toString() ?? '');
    final valorPagoController =
        TextEditingController(text: despesas.valorPago?.toString() ?? '');
    final dataVencimentoController = TextEditingController(
        text: despesas.dataVencimento?.toIso8601String() ?? '');
    final dataPagamentoController = TextEditingController(
        text: despesas.dataPagamento?.toIso8601String() ?? '');
    final anoEmissaoController =
        TextEditingController(text: despesas.anoEmissao?.toString() ?? '');
    final semestreEmissaoController =
        TextEditingController(text: despesas.semestreEmissao?.toString() ?? '');
    final trimestreEmissaoController = TextEditingController(
        text: despesas.trimestreEmissao?.toString() ?? '');
    final mesEmissaoController =
        TextEditingController(text: despesas.mesEmissao?.toString() ?? '');

    await showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          scrollable: true,
          title: Text('${isEdit ? 'Editar' : 'Cadastro de'} Despesa'),
          content: StatefulBuilder(
            builder: (context, mSetState) {
              return SizedBox(
                width: 500,
                child: Column(
                  children: [
                    TextFormField(
                      controller: numeroDocumentoController,
                      decoration: const InputDecoration(
                          labelText: 'Número do Documento'),
                    ),
                    TextFormField(
                      controller: numeroControleController,
                      decoration: const InputDecoration(
                          labelText: 'Número de Controle'),
                    ),
                    TextFormField(
                      controller: anoMesConsumoController,
                      decoration:
                          const InputDecoration(labelText: 'Ano/Mês Consumo'),
                    ),
                    TextFormField(
                      controller: quantidadeConsumidaController,
                      decoration: const InputDecoration(
                          labelText: 'Quantidade Consumida'),
                      keyboardType: TextInputType.number,
                    ),
                    TextFormField(
                      controller: valorPrevistoController,
                      decoration:
                          const InputDecoration(labelText: 'Valor Previsto'),
                      keyboardType: TextInputType.number,
                    ),
                    TextFormField(
                      controller: valorPagoController,
                      decoration:
                          const InputDecoration(labelText: 'Valor Pago'),
                      keyboardType: TextInputType.number,
                    ),
                    TextFormField(
                      controller: dataVencimentoController,
                      decoration: const InputDecoration(
                          labelText: 'Data de Vencimento'),
                    ),
                    TextFormField(
                      controller: dataPagamentoController,
                      decoration:
                          const InputDecoration(labelText: 'Data de Pagamento'),
                    ),
                    TextFormField(
                      controller: anoEmissaoController,
                      decoration:
                          const InputDecoration(labelText: 'Ano de Emissão'),
                      keyboardType: TextInputType.number,
                    ),
                    TextFormField(
                      controller: semestreEmissaoController,
                      decoration: const InputDecoration(
                          labelText: 'Semestre de Emissão'),
                      keyboardType: TextInputType.number,
                    ),
                    TextFormField(
                      controller: trimestreEmissaoController,
                      decoration: const InputDecoration(
                          labelText: 'Trimestre de Emissão'),
                      keyboardType: TextInputType.number,
                    ),
                    TextFormField(
                      controller: mesEmissaoController,
                      decoration:
                          const InputDecoration(labelText: 'Mês de Emissão'),
                      keyboardType: TextInputType.number,
                    ),
                    // Dropdown para ID do Usuário
                    // MyDropDownGetComp<UsuarioModel, UsuarioServiceImpl>(
                    //   labelText: 'ID do Usuário',
                    //   initValue: despesas.Usuario,
                    //   onChanged: (value) {
                    //     selectedUsuarioId = value?.id;
                    //   },
                    // ),
                    // // Dropdown para ID do Fornecedor
                    // MyDropDownGetComp<FornecedorModel, FornecedorServiceImpl>(
                    //   labelText: 'ID do Fornecedor',
                    //   initValue: selectedFornecedorId,
                    //   onChanged: (value) {
                    //     selectedFornecedorId = value?.id;
                    //   },
                    // ),
                    // // Dropdown para ID da Unidade Consumidora
                    // MyDropDownGetComp<UnidadeConsumidoraModel,
                    //     UnidadeConsumidoraServiceImpl>(
                    //   labelText: 'ID da Unidade Consumidora',
                    //   initValue: selectedUnidadeConsumidoraId,
                    //   onChanged: (value) {
                    //     selectedUnidadeConsumidoraId = value?.id;
                    //   },
                    // ),
                    // // Dropdown para ID da Instituição
                    // MyDropDownGetComp<InstituicaoModel, InstituicaoServiceImpl>(
                    //   labelText: 'ID da Instituição',
                    //   initValue: selectedInstituicaoId,
                    //   onChanged: (value) {
                    //     selectedInstituicaoId = value?.id;
                    //   },
                    // ),
                    // // Dropdown para ID do Orçamento
                    // MyDropDownGetComp<OrcamentoModel, OrcamentoServiceImpl>(
                    //   labelText: 'ID do Orçamento',
                    //   initValue: selectedOrcamentoId,
                    //   onChanged: (value) {
                    //     selectedOrcamentoId = value?.id;
                    //   },
                    // ),
                    // // Dropdown para ID do Tipo de Despesa
                    // MyDropDownGetComp<TipoDespesasModel,
                    //     TipoDespesasServiceImpl>(
                    //   labelText: 'ID do Tipo de Despesa',
                    //   initValue: selectedTipoDespesaId,
                    //   onChanged: (value) {
                    //     selectedTipoDespesaId = value?.id;
                    //   },
                    // ),
                    // Dropdown para Status da Despesa
                    MyDropDownComp(
                      initValue: selectedStatusDespesa,
                      itens: StatusEnum.values,
                      onChanged: (value) {
                        selectedStatusDespesa = value!;
                      },
                      labelText: 'Status da Despesa',
                    ),
                    // Dropdown para Situação
                    MyDropDownComp(
                      initValue: situacao,
                      itens: SituacaoEnum.values,
                      onChanged: (value) {
                        situacao = value!;
                      },
                      labelText: 'Situação',
                    ),
                  ],
                ),
              );
            },
          ),
          actions: <Widget>[
            TextButton(
              child: const Text('Cancelar'),
              onPressed: () {
                Navigator.of(context).pop();
              },
            ),
            TextButton(
              child: const Text('Salvar'),
              onPressed: () async {
                final updatedDespesa = despesas!.copyWith(
                  numeroDocumento: numeroDocumentoController.text,
                  numeroControle: numeroControleController.text,
                  anoMesConsumo: anoMesConsumoController.text,
                  quantidadeConsumida:
                      double.tryParse(quantidadeConsumidaController.text),
                  valorPrevisto: double.tryParse(valorPrevistoController.text),
                  valorPago: double.tryParse(valorPagoController.text),
                  dataVencimento:
                      DateTime.tryParse(dataVencimentoController.text),
                  dataPagamento:
                      DateTime.tryParse(dataPagamentoController.text),
                  anoEmissao: int.tryParse(anoEmissaoController.text),
                  semestreEmissao: int.tryParse(semestreEmissaoController.text),
                  trimestreEmissao:
                      int.tryParse(trimestreEmissaoController.text),
                  mesEmissao: int.tryParse(mesEmissaoController.text),
                  idUsuario: selectedUsuarioId,
                  idFornecedor: selectedFornecedorId,
                  idUnidadeConsumidora: selectedUnidadeConsumidoraId,
                  idInstituicao: selectedInstituicaoId,
                  idOrcamento: selectedOrcamentoId,
                  idTipoDespesa: selectedTipoDespesaId,
                  statusDespesa: selectedStatusDespesa,
                  situacao: situacao, // Atualizado
                );

                final resp = isEdit
                    ? await service.editData(updatedDespesa)
                    : await service.postData(updatedDespesa);

                resp.fold(
                  (success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  },
                  (failure) {
                    print('Erro: $failure');
                  },
                );
              },
            ),
          ],
        );
      },
    );

    // Dispose de todos os controladores criados
    numeroDocumentoController.dispose();
    numeroControleController.dispose();
    anoMesConsumoController.dispose();
    quantidadeConsumidaController.dispose();
    valorPrevistoController.dispose();
    valorPagoController.dispose();
    dataVencimentoController.dispose();
    dataPagamentoController.dispose();
    anoEmissaoController.dispose();
    semestreEmissaoController.dispose();
    trimestreEmissaoController.dispose();
    mesEmissaoController.dispose();
  }
}
