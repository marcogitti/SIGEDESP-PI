import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_drop_down_comp.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/instituicao/instituicao_service.dart';
import 'package:front/app/modules/despesas/tipo_despesas_model.dart';
import 'package:front/app/modules/despesas/tipo_despesas_service.dart';
import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/modules/orcamento/orcamento_model.dart';
import 'package:front/app/modules/orcamento/orcamento_service.dart';
import 'package:result_dart/result_dart.dart';

class OrcamentoPage extends StatefulWidget {
  const OrcamentoPage({Key? key}) : super(key: key);

  @override
  State<OrcamentoPage> createState() => _OrcamentoPageState();
}

class _OrcamentoPageState extends State<OrcamentoPage> {
  late TextEditingController _controller;
  final service = Modular.get<OrcamentoServiceImpl>();

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
                  padding: EdgeInsets.only(bottom: 50),
                  child: Text(
                    "Orçamento",
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
                    const SizedBox(height: 30),
                    Row(
                      children: [
                        ElevatedButton(
                          onPressed: () async {
                            await modalCadastrar();
                          },
                          child: const Text('Cadastrar'),
                        ),
                        const SizedBox(width: 15),
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
                        const SizedBox(width: 20),
                      ],
                    ),
                  ],
                ),
                Padding(
                  padding: const EdgeInsets.only(top: 60),
                  child: FutureBuilder(
                    future: service.getAll().getOrNull(),
                    builder: (context, AsyncSnapshot snapshot) {
                      if (snapshot.connectionState == ConnectionState.none) {
                        return const Text("Sem internet");
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

                      List<OrcamentoModel?> tp =
                          (snapshot.data ?? []).cast<OrcamentoModel?>();

                      return SizedBox(
                        height: 500,
                        width: double.infinity,
                        child: DataTable(
                          border: TableBorder.all(),
                          columns: const [
                            DataColumn(label: Text('Id')),
                            DataColumn(label: Text('Ano Orçamento')),
                            DataColumn(label: Text('Valor Orçamento')),
                            DataColumn(label: Text('Tipo de Despesa')),
                            DataColumn(label: Text('Instituição')),
                            DataColumn(label: Text('Ações')),
                          ],
                          rows: tp
                              .map((e) {
                                return DataRow(
                                  cells: [
                                    DataCell(Text(e?.id?.toString() ?? '')),
                                    DataCell(
                                        Text(e?.anoOrcamento.toString() ?? '')),
                                    DataCell(Text(
                                        e?.valorOrcamento.toString() ?? '')),
                                    DataCell(
                                        Text(e?.tipoDespesa?.descricao ?? '')),
                                    DataCell(Text(e?.instituicao?.nome ?? '')),
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
                                                      child: const Text(
                                                          'Cancelar'),
                                                      onPressed: () {
                                                        Modular.to.pop(false);
                                                      },
                                                    ),
                                                    TextButton(
                                                      child: const Text(
                                                          'Confirmar'),
                                                      onPressed: () async {
                                                        Modular.to.pop();
                                                        if (e?.id != null) {
                                                          await service
                                                              .deleteData(
                                                                  e!.id!);
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
                                  ],
                                );
                              })
                              .toList()
                              .cast<DataRow>(),
                        ),
                      );
                    },
                  ),
                )
              ],
            )));
  }

  Future<void> modalCadastrar([OrcamentoModel? orcamento]) async {
    bool isEdit = orcamento?.id != null;
    if (!isEdit) {
      orcamento = OrcamentoModel();
    }

    TextEditingController orcamentoAnoEditCtrl = TextEditingController(
        text: orcamento?.anoOrcamento != null
            ? orcamento?.anoOrcamento.toString()
            : '');
    TextEditingController orcamentoValorEditCtrl = TextEditingController(
        text: orcamento?.valorOrcamento != null
            ? orcamento?.valorOrcamento.toString()
            : '');

    await showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          scrollable: true,
          title: Text('${isEdit ? 'Editar' : 'Cadastro de'} Orçamento'),
          content: StatefulBuilder(builder: (context, mSetState) {
            return Column(
              children: [
                TextFormField(
                  controller: orcamentoAnoEditCtrl,
                  decoration: const InputDecoration(
                    labelText: 'Ano Orçamento',
                  ),
                  inputFormatters: [
                    FilteringTextInputFormatter.digitsOnly,
                  ],
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Campo obrigatório';
                    }
                    return null;
                  },
                ),
                TextFormField(
                  controller: orcamentoValorEditCtrl,
                  decoration: const InputDecoration(
                    labelText: 'Valor Orçamento',
                  ),
                  inputFormatters: [
                    FilteringTextInputFormatter.digitsOnly,
                  ],
                  validator: (value) {
                    if (value == null || value.isEmpty) {
                      return 'Campo obrigatório';
                    }
                    return null;
                  },
                ),
                MyDropDownGetComp<InstituicaoModel, InstituicaoServiceImpl>(
                  labelText: 'Instituição',
                  initValue: orcamento?.instituicao,
                  onChanged: (value) {
                    orcamento?.instituicao = value;
                  },
                ),
                MyDropDownGetComp<TipoDespesasModel, TipoDespesasServiceImpl>(
                  labelText: 'Tipo De Despesa',
                  initValue: orcamento?.tipoDespesa,
                  onChanged: (value) {
                    orcamento?.tipoDespesa = value;
                  },
                )
              ],
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
                orcamento = orcamento?.copyWith(
                  anoOrcamento: int.tryParse(orcamentoAnoEditCtrl.text),
                  tipoDespesa: orcamento?.tipoDespesa,
                  instituicao: orcamento?.instituicao,
                );
                if (isEdit) {
                  final resp = await service.editData(
                    orcamento!,
                  );
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) => null);
                } else {
                  final resp = await service.postData(orcamento!);
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) {
                    //snack bar
                    // ignore: avoid_print
                    print('erro$failure');
                  });
                }
              },
            ),
          ],
        );
      },
    );
    orcamentoAnoEditCtrl.dispose();
    orcamentoValorEditCtrl.dispose();
  }
}
