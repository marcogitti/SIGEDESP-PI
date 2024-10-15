import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
// ignore: unnecessary_import
import 'package:flutter/services.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_drop_down_comp.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/despesas/tipo_despesas_model.dart';
import 'package:front/app/modules/despesas/tipo_despesas_service.dart';
import 'package:front/app/modules/unidade/unidade_de_medida_model.dart';
import 'package:front/app/modules/unidade/unidade_de_medida_service.dart';
import 'package:front/app/util/solicita_uc_enum.dart';
import 'package:result_dart/result_dart.dart';

class TipoDeDespesasPage extends StatefulWidget {
  const TipoDeDespesasPage({Key? key}) : super(key: key);

  @override
  State<TipoDeDespesasPage> createState() => _TipoDeDespesasPageState();
}

class _TipoDeDespesasPageState extends State<TipoDeDespesasPage> {
  late TextEditingController _controller;
  final service = Modular.get<TipoDespesasServiceImpl>();

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
                "Cadastro de Tipo Despesa",
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
                    hintText: 'Buscar Tipo Despesa',
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
                      child: const Text('Cadastrar Tipo Despesa'),
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

                  final tp = (snapshot.data ?? []).cast<TipoDespesasModel?>();

                  return SingleChildScrollView(
                    dragStartBehavior: DragStartBehavior.start,
                    scrollDirection: Axis.horizontal,
                    child: DataTable(
                      border: TableBorder.all(),
                      columns: const [
                        DataColumn(label: Text('id')),
                        DataColumn(label: Text('Descrição')),
                        DataColumn(label: Text('Unidade de Medida')),
                        DataColumn(label: Text('Solicita UC')), 
                        DataColumn(label: Text('Ação')),
                      ],
                      rows: tp
                          .map((e) {
                            return DataRow(cells: [
                              DataCell(
                                Text(e?.descricao.toString() ?? ''),
                              ),
                              DataCell(
                                Text(e?.idUnidadeMedida.toString() ?? ''),
                              ),
                              DataCell(
                                Text(e?.solicitaUC ?? ''), 
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
                                          title:
                                              const Text('Confirmar exclusão'),
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
                                                await service.deleteData(e!.id);

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

  Future<void> modalCadastrar([TipoDespesasModel? tipoDespesa]) async {
    bool isEdit = tipoDespesa?.id != null;
    if (!isEdit) {
      tipoDespesa = TipoDespesasModel();
    }
    UnidadeDeMedidaModel? selectedUnidadeMedida;
    SolicitaUcEnum solicitaUcEnum = SolicitaUcEnum.values.firstWhere(
      (e) => e.toString() == 'SolicitaUcEnum.${tipoDespesa?.solicitaUC}',
      orElse: () => SolicitaUcEnum.sim,
    );

    TextEditingController tipoDespesaDescricaoEditCtrl =
        TextEditingController(text: tipoDespesa?.descricao ?? '');

    await showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          scrollable: true,
          title: Text('${isEdit ? 'Editar' : 'Cadastro de'} Tipo Despesa'),
          content: StatefulBuilder(builder: (context, mSetState) {
            return SizedBox(
              width: 500,
              child: Column(
                children: [
                  TextFormField(
                    controller: tipoDespesaDescricaoEditCtrl,
                    decoration: const InputDecoration(
                      labelText: 'Descrição',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  MyDropDownComp(
                    initValue: solicitaUcEnum,
                    itens: SolicitaUcEnum.values,
                    onChanged: (value) {
                      solicitaUcEnum = value!;
                    },
                    labelText: 'Solicita UC',
                  ),
                  MyDropDownGetComp<UnidadeDeMedidaModel,
                      UnidadeMedidaServiceImpl>(
                    labelText: 'Unidade de Medida',
                    initValue: selectedUnidadeMedida,
                    onChanged: (value) {
                      selectedUnidadeMedida = value;
                    },
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
                tipoDespesa = tipoDespesa?.copyWith(
                  descricao: tipoDespesaDescricaoEditCtrl.text,
                  idUnidadeMedida: selectedUnidadeMedida?.id,
                  solicitaUC: solicitaUcEnum,
                );
                if (isEdit) {
                  final resp = await service.editData(tipoDespesa!);
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) => null);
                } else {
                  final resp = await service.postData(tipoDespesa!);
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
    tipoDespesaDescricaoEditCtrl.dispose();
  }
}
