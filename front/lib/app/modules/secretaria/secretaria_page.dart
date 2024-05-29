import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/Scaffold_comp.dart';
import 'package:front/app/modules/secretaria/secretaria_model.dart';
import 'package:front/app/modules/secretaria/secretaria_service.dart';
import 'package:result_dart/result_dart.dart';

class SecretariaPage extends StatefulWidget {
  const SecretariaPage({Key? key}) : super(key: key);

  @override
  State<SecretariaPage> createState() => _InstitutionScreenState();
}

class _InstitutionScreenState extends State<SecretariaPage> {
  late TextEditingController _controller;
  final service = Modular.get<SecretariaServiceImpl>();

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
                "Cadastro de Secretaria",
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
                    hintText: 'Buscar Secretaria',
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
                      child: const Text('Cadastrar Secretaria'),
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

                  final tp = (snapshot.data ?? []).cast<SecretariaModel?>();

                  return DataTable(
                    border: TableBorder.all(),
                    columns: const [
                      DataColumn(label: Text('Situação')),
                      DataColumn(label: Text('Descrição')),
                      DataColumn(label: Text('Ações')),
                    ],
                    rows: tp
                        .map((e) {
                          return DataRow(
                            cells: [
                              DataCell(
                                Text(e?.situacao.toString() ?? ''),
                              ),
                              DataCell(
                                Text(e?.descricao.toString() ?? ''),
                              ),
                              DataCell(Row(
                                children: [
                                  IconButton(
                                    icon: const Icon(Icons.edit,
                                      color: Color(0xFF0044FF),
                                    ),
                                    onPressed: () async {
                                      await modalCadastrar(e);
                                    },
                                  ),
                                  IconButton(
                                    icon: const Icon(Icons.delete,
                                      color: Color(0xFFF44336),
                                    ),
                                    onPressed: () async {
                                      await showDialog<bool>(
                                        context: context,
                                        builder: (BuildContext context) {
                                          return AlertDialog(
                                            title: const Text(
                                              'Confirmar exclusão',
                                            ),
                                            content: const Text(
                                              'Tem certeza que deseja excluir este item?',
                                            ),
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
                                                      .deleteData(e.id);

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
                            ],
                          );
                        })
                        .toList()
                        .cast<DataRow>(),
                  );
                },
              ),
            )
          ],
        ),
      ),
    );
  }

  Future<void> modalCadastrar([SecretariaModel? secretaria]) async {
    bool isEdit = secretaria?.id != null;
    TextEditingController secretariaEditCtrl =
        TextEditingController(text: secretaria?.situacao ?? '');
    TextEditingController secretariaDescEditCtrl =
        TextEditingController(text: secretaria?.descricao ?? '');

    await showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('${isEdit ? 'Editar' : 'Cadastro de'} Secretaria'),
          content: Wrap(
            children: [
              TextField(
                controller: secretariaEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'Situação',
                ),
              ),
              TextField(
                controller: secretariaDescEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'Descrição',
                ),
              ),
            ],
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
                //tela load
                if (isEdit) {
                  final resp = await service.editData(
                    secretaria!
                        .copyWith(
                            situacao: secretariaEditCtrl.text,
                            descricao: secretariaDescEditCtrl.text)
                        .toJson(),
                  );
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) => null);
                } else {
                  final resp = await service.postData(
                    SecretariaModel(
                      descricao: secretariaDescEditCtrl.text,
                      situacao: secretariaEditCtrl.text,
                    ).toJson(),
                  );
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
    secretariaEditCtrl.dispose();
    secretariaDescEditCtrl.dispose();
  }
}
