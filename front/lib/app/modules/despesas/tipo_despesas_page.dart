import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/despesas/tipo_despesas_model.dart';
import 'package:front/app/modules/despesas/tipo_despesas_service.dart';
import 'package:result_dart/result_dart.dart';

class TipoDeDespesas extends StatefulWidget {
  const TipoDeDespesas({Key? key}) : super(key: key);

  @override
  State<TipoDeDespesas> createState() => _TipoDeDespesasState();
}

class _TipoDeDespesasState extends State<TipoDeDespesas> {
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

                  return DataTable(
                    border: TableBorder.all(),
                    columns: const [
                      DataColumn(label: Text('Descrição')),
                      DataColumn(label: Text('Ações')),
                    ],
                    rows: tp.map((e) {
                      return DataRow(cells: [
                        DataCell(
                          Text(e?.descricao ?? ''),
                        ),
                        DataCell(
                          Row(
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
                                  final confirmDelete = await showDialog<bool>(
                                    context: context,
                                    builder: (BuildContext context) {
                                      return AlertDialog(
                                        title: const Text('Confirmar exclusão'),
                                        content: const Text(
                                            'Tem certeza que deseja excluir este item?'),
                                        actions: <Widget>[
                                          TextButton(
                                            onPressed: () {
                                              Modular.to.pop(false);
                                            },
                                            child: const Text('Cancelar'),
                                          ),
                                          TextButton(
                                            onPressed: () async {
                                              Modular.to.pop(true);
                                              await service.deleteData(e!.id);
                                              setState(() {});
                                            },
                                            child: const Text('Confirmar'),
                                          ),
                                        ],
                                      );
                                    },
                                  );
                                },
                              ),
                            ],
                          ),
                        ),
                      ]);
                    }).toList(),
                  );
                },
              ),
            ),
          ],
        ),
      ),
    );
  }

  Future<void> modalCadastrar([TipoDespesasModel? tipoDespesa]) async {
    bool isEdit = tipoDespesa?.id != null;
    final tipoDespesaEditCtrl =
        TextEditingController(text: tipoDespesa?.descricao ?? '');

    await showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('${isEdit ? 'Editar' : 'Cadastro de'} Tipo Despesa'),
          content: Wrap(
            children: [
              TextField(
                controller: tipoDespesaEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'Nome da Despesa',
                ),
              ),
            ],
          ),
          actions: <Widget>[
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: const Text('Cancelar'),
            ),
            TextButton(
              onPressed: () async {
                if (isEdit) {
                  final resp = await service.editData(
                    tipoDespesa!.copyWith(descricao: tipoDespesaEditCtrl.text),
                  );
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) {
                    print('erro');
                  });
                } else {
                  final resp = await service.postData(
                    TipoDespesasModel(
                      descricao: tipoDespesaEditCtrl.text,
                      solicitaUC: 'SP',
                    ),
                  );
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) {
                    print('erro');
                  });
                }
              },
              child: const Text('Salvar'),
            ),
          ],
        );
      },
    );
    tipoDespesaEditCtrl.dispose();
  }
}
