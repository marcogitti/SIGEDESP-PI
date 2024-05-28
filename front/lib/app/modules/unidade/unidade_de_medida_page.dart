import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/Scaffold_comp.dart';
import 'package:front/app/modules/unidade/unidade_de_medida_model.dart';
import 'package:front/app/modules/unidade/unidade_de_medida_service.dart';
import 'package:result_dart/result_dart.dart';

class UnidadeDeMedidaPage extends StatefulWidget {
  const UnidadeDeMedidaPage({Key? key}) : super(key: key);

  @override
  State<UnidadeDeMedidaPage> createState() => _UnidadeDeMedidaPageState();
}

class _UnidadeDeMedidaPageState extends State<UnidadeDeMedidaPage> {
  late TextEditingController _abreviatura;
  late TextEditingController _descricao;
  late TextEditingController _controller;
  String _currentUnidadeDeMedida = '';
  final service = Modular.get<UnidadeMedidaServiceImpl>();

  @override
  void initState() {
    _controller = TextEditingController();
    _abreviatura = TextEditingController();
    super.initState();
  }

  @override
  void dispose() {
    _controller.dispose();
    _abreviatura.dispose();
    _descricao.dispose();
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
                "Cadastro de Unidade De Medida",
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
                    hintText: 'Buscar Unidade De Medida',
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
                      child: const Text('Cadastrar Unidade De Medida'),
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
                      (snapshot.data ?? []).cast<UnidadeDeMedidaModel?>();

                  return DataTable(
                    border: TableBorder.all(),
                    columns: const [
                      DataColumn(label: Text('Abreviatura')),
                      DataColumn(label: Text('Descrição'))
                    ],
                    rows: tp.map((e) {
                      return DataRow(cells: [
                        DataCell(
                          Row(
                            children: [
                              Expanded(child: Text(e?.abreviatura ?? '')),
                              IconButton(
                                icon: const Icon(Icons.edit),
                                onPressed: () async {
                                  final newText = await showDialog<String>(
                                    context: context,
                                    builder: (BuildContext context) {
                                      return AlertDialog(
                                        title: const Text(
                                            'Editar Unidade De Medida'),
                                        content: TextField(
                                          controller: TextEditingController(
                                              text: _currentUnidadeDeMedida),
                                          onChanged: (value) {
                                            _currentUnidadeDeMedida = value;
                                          },
                                        ),
                                        actions: <Widget>[
                                          TextButton(
                                            onPressed: () {
                                              Navigator.of(context)
                                                  .pop(_currentUnidadeDeMedida);
                                            },
                                            child: const Text('Salvar'),
                                          ),
                                        ],
                                      );
                                    },
                                  );
                                },
                              ),
                              IconButton(
                                icon: const Icon(Icons.delete),
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
                                            onPressed: () {
                                              Modular.to.pop(true);
                                            },
                                            child: const Text('Confirmar'),
                                          ),
                                        ],
                                      );
                                    },
                                  );
                                  if (confirmDelete == true) {}
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
            )
          ],
        ),
      ),
    );
  }

  Future<void> modalCadastrar() async {
    await showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text('Cadastro de Unidade De Medida'),
          content: Wrap(
            children: [
              TextField(
                controller: _abreviatura,
                decoration: const InputDecoration(
                  hintText: 'Abreviatura da Unidade De Medida',
                ),
              ),
              TextField(
                controller: _descricao,
                decoration: const InputDecoration(
                  hintText: 'Descricao da Unidade De Medida',
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
                final resp = await service.postData(UnidadeDeMedidaModel(
                  abreviatura: _abreviatura.text,
                  descricao: _descricao.text,
                ).toJson());
                resp.fold((success) {
                  Navigator.of(context).pop();
                  setState(() {});
                }, (failure) {
                  //snack bar
                  print('erro');
                });
              },
            ),
          ],
        );
      },
    );
    _abreviatura.dispose();
    _descricao.dispose();
  }
}
