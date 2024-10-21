import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_drop_down_comp.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/instituicao/instituicao_service.dart';
import 'package:front/app/modules/fornecedor/fornecedor_model.dart';
import 'package:front/app/modules/fornecedor/fornecedor_service.dart';
import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/modules/unidade/unidade_consumidora_model.dart';
import 'package:front/app/modules/unidade/unidade_consumidora_sevice.dart';
import 'package:result_dart/result_dart.dart';

class UnidadeConsumidoraPage extends StatefulWidget {
  const UnidadeConsumidoraPage({Key? key}) : super(key: key);

  @override
  State<UnidadeConsumidoraPage> createState() => _UnidadeConsumidoraPageState();
}

class _UnidadeConsumidoraPageState extends State<UnidadeConsumidoraPage> {
  late TextEditingController _controller;
  final service = Modular.get<UnidadeConsumidoraServiceImpl>();

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
                "Cadastro de Unidade consumidora",
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
                    hintText: 'Buscar Unidade consumidora',
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
                      child: const Text('Cadastrar Nova Unidade consumidora'),
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

                  final tp =
                      (snapshot.data ?? []).cast<UnidadeConsumidoraModel?>();

                  return SizedBox(
                    height: 500,
                    width: double.infinity,
                    child: DataTable(
                      border: TableBorder.all(),
                      columns: const [
                        DataColumn(label: Text('Codigo UC')),
                        DataColumn(label: Text('Fornecedor')),
                        DataColumn(label: Text('Instituição')),
                        DataColumn(label: Text('Ação')),
                      ],
                      rows: tp
                          .map((e) {
                            return DataRow(cells: [
                              DataCell(
                                Text(e?.codigoUC.toString() ?? ''),
                              ),
                              DataCell(
                                Text(e?.idFornecedor.toString() ?? ''),
                              ),
                              DataCell(
                                Text(e?.instituicao?.id.toString() ?? ''),
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
                                                  await service
                                                      .deleteData(e!.id);

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

  Future<void> modalCadastrar(
      [UnidadeConsumidoraModel? unidadeConsumidora]) async {
    bool isEdit = unidadeConsumidora?.id != null;
    if (!isEdit) {
      unidadeConsumidora = UnidadeConsumidoraModel();
    }

    TextEditingController unidadeConsumidoraCodigoUCEditCtrl =
        TextEditingController(
      text: unidadeConsumidora?.codigoUC != null
          ? unidadeConsumidora?.codigoUC.toString()
          : '',
    );

    await showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          scrollable: true,
          title:
              Text('${isEdit ? 'Editar' : 'Cadastro de'} Unidade Consumidora'),
          content: StatefulBuilder(builder: (context, mSetState) {
            return Column(
              children: [
                TextFormField(
                  controller: unidadeConsumidoraCodigoUCEditCtrl,
                  decoration: const InputDecoration(
                    labelText: 'Codigo UC',
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
                  initValue: unidadeConsumidora?.instituicao,
                  onChanged: (value) {
                    unidadeConsumidora?.instituicao = value;
                  },
                ),
                MyDropDownGetComp<FornecedorModel, FornecedorServiceImpl>(
                  labelText: 'Fornecedor',
                  initValue: unidadeConsumidora?.fornecedor,
                  onChanged: (value) {
                    unidadeConsumidora?.fornecedor = value;
                  },
                ),
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
                unidadeConsumidora = unidadeConsumidora?.copyWith(
                  codigoUC:
                      int.tryParse(unidadeConsumidoraCodigoUCEditCtrl.text),
                );
                if (isEdit) {
                  final resp = await service.editData(unidadeConsumidora!);
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) => null);
                } else {
                  final resp = await service.postData(unidadeConsumidora!);
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) {
                    //snack bar
                    print('erro$failure');
                  });
                }
              },
            ),
          ],
        );
      },
    );
    unidadeConsumidoraCodigoUCEditCtrl.dispose();
  }
}
