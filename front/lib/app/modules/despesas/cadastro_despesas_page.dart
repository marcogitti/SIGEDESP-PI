import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_drop_down_comp.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/fornecedor/fornecedor_model.dart';
import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/modules/instituicao/instituicao_service.dart';
import 'package:front/app/modules/despesas/despesas_model.dart';
import 'package:front/app/modules/despesas/despesas_service.dart';
import 'package:front/app/modules/login/usuario_model.dart';
import 'package:front/app/modules/login/usuario_service.dart';
import 'package:front/app/modules/orcamento/orcamento_model.dart';
import 'package:front/app/modules/unidade/unidade_consumidora_model.dart';
import 'package:front/app/util/situacao_enum.dart';
import 'package:front/app/util/status_de_despesa_enum.dart';
import 'package:result_dart/result_dart.dart';

class DesespesasPage extends StatefulWidget {
  const DesespesasPage({super.key});

  @override
  State<DesespesasPage> createState() => _DespesasState();
}

class _DespesasState extends State<DesespesasPage> {
  late TextEditingController _controller;
  final service = Modular.get<DespesasServiceImpl>();

  @override
  void initState() {
    _controller = TextEditingController();
    super.initState();
  }

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return ScaffoldComp(
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: ListView(
          children: [
            const Padding(
              padding: EdgeInsets.only(bottom: 30),
              child: Text(
                "Despesas",
                style: TextStyle(
                  fontSize: 30,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                TextField(
                  decoration: const InputDecoration(
                    hintText: 'Buscar',
                    prefixIcon: Icon(Icons.search),
                    border: OutlineInputBorder(),
                  ),
                  controller: _controller,
                ),
                const SizedBox(height: 20),
                Row(
                  children: [
                    ElevatedButton(
                      onPressed: () async {
                        await modalCadastrar();
                      },
                      child: const Text('Cadastrar'),
                    ),
                    const SizedBox(width: 10),
                    const Text("Mostrar: "),
                    DropdownButton<String>(
                      borderRadius: BorderRadius.circular(10),
                      elevation: 10,
                      items: <String>['Opção 1', 'Opção 2', 'Opção 3']
                          .map((String value) {
                        return DropdownMenuItem<String>(
                          value: value,
                          child: Text(value),
                        );
                      }).toList(),
                      onChanged: (String? newValue) {},
                    ),
                    const SizedBox(width: 15),
                  ],
                )
              ],
            ),
            Padding(
              padding: const EdgeInsets.only(top: 40), // Ajuste aqui
              child: FutureBuilder(
                future: service.getAll().getOrNull(),
                builder: (context, AsyncSnapshot snapshot) {
                  if (snapshot.connectionState == ConnectionState.none) {
                    return const Text("sem internet");
                  }

                  if (snapshot.connectionState == ConnectionState.waiting) {
                    return const Center(
                      child: SizedBox(
                        width: 26,
                        height: 26,
                        child: CircularProgressIndicator(),
                      ),
                    );
                  }

                  if (snapshot.hasError) {
                    return const Text("Erro");
                  }

                  List<DespesaModel> tp =
                      (snapshot.data ?? []).cast<DespesaModel>();
                  return SizedBox(
                    height: 500,
                    width: double.infinity,
                    child: DataTable(
                      border: TableBorder.all(),
                      columns: const [
                        DataColumn(label: Text('Id')),
                        DataColumn(label: Text('Usuario')),
                        DataColumn(label: Text('Numero\nDoc')),
                        DataColumn(label: Text('Numero\nCon')),
                        DataColumn(label: Text('Unidade\nConsumidora')),
                        DataColumn(label: Text('Status\ndespesa')),
                        DataColumn(label: Text('Data\nPagamento')),
                        DataColumn(label: Text('Data\nVencimento')),
                        DataColumn(label: Text('Fornecedor')),
                        DataColumn(label: Text('Situacao')),
                        DataColumn(label: Text('Ação')),
                      ],
                      rows: tp
                          .map((e) {
                            return DataRow(cells: [
                              DataCell(
                                Text(e.id.toString()),
                              ),
                              DataCell(
                                Text(e.usuario?.nome.toString() ?? ''),
                              ),
                              DataCell(
                                Text(e.numeroDocumento.toString()),
                              ),
                              DataCell(
                                Text(e.numeroControle.toString()),
                              ),
                              DataCell(
                                Text(
                                    e.unidadeConsumidora?.codigoUC.toString() ??
                                        ''),
                              ),
                              DataCell(
                                Text(e.statusDespesa!.nome.toString()),
                              ),
                              DataCell(
                                Text(e.dataPagamento.toString()),
                              ),
                              DataCell(
                                Text(e.dataVencimento.toString()),
                              ),
                              DataCell(
                                Text(e.fornecedor?.nomeFantasia.toString() ??
                                    ''),
                              ),
                              DataCell(
                                Text(e.situacao!.nome.toString()),
                              ),
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
                                            title: const Text(
                                                'Confirmar exclusão'),
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
                                                    await service
                                                        .deleteData(e.id!);
                                                  }
                                                  setState(() {});
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
                    ),
                  );
                },
              ),
            )
          ],
        ),
      ),
    );
  }

  Future<void> modalCadastrar([DespesaModel? despesa]) async {
    bool isEdit = despesa?.id != null;
    if (!isEdit) {
      despesa = DespesaModel();
    }
    SituacaoEnum situacaoEnum = despesa?.situacao ?? SituacaoEnum.ativo;
    StatusEnum? statusEnum = despesa?.statusDespesa ?? StatusEnum.apagar;
    // SecretariaModel? selectedSecretaria = despesa?.secretaria;
    // TipoInstituicaoModel? selectedTipoInstituicao =
    //     despesa?.tipoInstituicao;

    TextEditingController numeroDocumentoController =
        TextEditingController(text: despesa?.numeroDocumento ?? '');
    TextEditingController numeroControleController =
        TextEditingController(text: despesa?.numeroControle ?? '');
    TextEditingController anoMesConsumoController =
        TextEditingController(text: despesa?.anoMesConsumo ?? '');
    TextEditingController quantidadeConsumidaController = TextEditingController(
        text: despesa?.quantidadeConsumida?.toString() ?? '');
    TextEditingController valorPrevistoController =
        TextEditingController(text: despesa?.valorPrevisto?.toString() ?? '');
    TextEditingController valorPagoController =
        TextEditingController(text: despesa?.valorPago?.toString() ?? '');
    TextEditingController dataVencimentoController = TextEditingController(
        text: despesa?.dataVencimento?.toIso8601String() ?? '');
    TextEditingController dataPagamentoController = TextEditingController(
        text: despesa?.dataPagamento?.toIso8601String() ?? '');
    TextEditingController anoEmissaoController =
        TextEditingController(text: despesa?.anoEmissao?.toString() ?? '');
    TextEditingController semestreEmissaoController =
        TextEditingController(text: despesa?.semestreEmissao?.toString() ?? '');
    TextEditingController trimestreEmissaoController = TextEditingController(
        text: despesa?.trimestreEmissao?.toString() ?? '');
    TextEditingController mesEmissaoController =
        TextEditingController(text: despesa?.mesEmissao?.toString() ?? '');

    await showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          scrollable: true,
          title: Text('${isEdit ? 'Editar' : 'Cadastro de'} Instituição'),
          content: StatefulBuilder(builder: (context, mSetState) {
            return SizedBox(
              width: 500,
              child: Column(
                children: [
                  TextFormField(
                    controller: numeroDocumentoController,
                    decoration: const InputDecoration(
                      labelText: 'Nome',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: mesEmissaoController,
                    decoration: const InputDecoration(
                      labelText: 'Mes Emissão',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: trimestreEmissaoController,
                    decoration: const InputDecoration(
                      labelText: 'Trimestre de Emissao',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: semestreEmissaoController,
                    decoration: const InputDecoration(
                      labelText: 'Semestre de Emissao',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: anoEmissaoController,
                    decoration: const InputDecoration(
                      labelText: 'Ano de Emissao',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: dataPagamentoController,
                    decoration: const InputDecoration(
                      labelText: 'Data de Pagamento',
                    ),
                  ),
                  TextFormField(
                    controller: dataVencimentoController,
                    decoration: const InputDecoration(
                      labelText: 'Data de Vencimento',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: valorPagoController,
                    decoration: const InputDecoration(
                      labelText: 'Valor Pago',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: valorPrevistoController,
                    decoration: const InputDecoration(
                      labelText: 'Valor Previsto',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: quantidadeConsumidaController,
                    decoration: const InputDecoration(
                      labelText: 'Quantidade Consumida',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: anoMesConsumoController,
                    decoration: const InputDecoration(
                      labelText: 'Ano Mes Consumo',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: numeroControleController,
                    decoration: const InputDecoration(
                      labelText: 'Numero de Controle',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: numeroDocumentoController,
                    decoration: const InputDecoration(
                      labelText: 'Numero do Documento',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  MyDropDownGetComp<UsuarioModel, UsuarioServiceImpl>(
                    labelText: 'Usuario',
                    initValue: despesa?.usuario,
                    onChanged: (value) {
                      despesa?.usuario = value;
                    },
                  ),
                  MyDropDownGetComp<FornecedorModel, UsuarioServiceImpl>(
                    labelText: 'Fornecerdor',
                    initValue: despesa?.fornecedor,
                    onChanged: (value) {
                      despesa?.fornecedor = value;
                    },
                  ),
                  MyDropDownGetComp<UnidadeConsumidoraModel,
                      InstituicaoServiceImpl>(
                    labelText: 'Unidade Consumidora',
                    initValue: despesa!.unidadeConsumidora,
                    onChanged: (value) {
                      despesa?.unidadeConsumidora = value;
                    },
                  ),
                  MyDropDownGetComp<InstituicaoModel, InstituicaoServiceImpl>(
                    labelText: 'Instituição',
                    initValue: despesa!.instituicao,
                    onChanged: (value) {
                      despesa?.instituicao = value;
                    },
                  ),
                  MyDropDownGetComp<OrcamentoModel, InstituicaoServiceImpl>(
                    labelText: 'Orçamento',
                    initValue: despesa!.orcamento,
                    onChanged: (value) {
                      despesa?.orcamento = value;
                    },
                  ),
                  MyDropDownGetComp<InstituicaoModel, InstituicaoServiceImpl>(
                    labelText: 'Tipo despesa',
                    initValue: despesa!.instituicao,
                    onChanged: (value) {
                      despesa?.instituicao = value;
                    },
                  ),
                  MyDropDownComp(
                    initValue: StatusEnum.values,
                    itens: StatusEnum.values,
                    onChanged: (value) {
                      statusEnum = value! as StatusEnum?;
                    },
                    labelText: 'Status',
                  ),
                  MyDropDownComp(
                    initValue: situacaoEnum,
                    itens: SituacaoEnum.values,
                    onChanged: (value) {
                      situacaoEnum = value!;
                    },
                    labelText: 'Situação',
                  ),
                ],
              ),
            );
          }),
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
                despesa = despesa?.copyWith(
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
                );
                if (isEdit) {
                  final resp = await service.editData(
                    despesa!,
                  );
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) => null);
                } else {
                  final resp = await service.postData(despesa!);
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) {
                    print('erro$failure');
                  });
                }
              },
            ),
          ],
        );
      },
    );
    numeroControleController.dispose();
    numeroDocumentoController.dispose();
    anoMesConsumoController.dispose();
    quantidadeConsumidaController.dispose();
    dataVencimentoController.dispose();
    valorPrevistoController.dispose();
    valorPagoController.dispose();
    dataPagamentoController.dispose();
    anoEmissaoController.dispose();
    semestreEmissaoController.dispose();
    trimestreEmissaoController.dispose();
    mesEmissaoController.dispose();
  }
}
