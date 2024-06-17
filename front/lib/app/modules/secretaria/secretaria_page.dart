import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/secretaria/secretaria_model.dart';
import 'package:front/app/modules/secretaria/secretaria_service.dart';
import 'package:result_dart/result_dart.dart';

class SecretariaPage extends StatefulWidget {
  const SecretariaPage({Key? key}) : super(key: key);

  @override
  State<SecretariaPage> createState() => _SecretariaPageState();
}

class _SecretariaPageState extends State<SecretariaPage> {
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
                          child: const Text('Cadastrar Nova Secretaria'),
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
                        columns: const [DataColumn(label: Text('Descrição'))],
                        rows: tp
                            .map((e) {
                              return DataRow(cells: [
                                DataCell(
                                  Row(
                                    children: [
                                      Expanded(
                                          child: Text(
                                              e?.situacao.toString() ?? '')),
                                      IconButton(
                                        icon: const Icon(Icons.edit),
                                        onPressed: () async {
                                          await modalCadastrar(e);
                                        },
                                      ),
                                      IconButton(
                                        icon: const Icon(Icons.delete),
                                        onPressed: () async {
                                          final confirmDelete =
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
                                                    onPressed: () {
                                                      Modular.to.pop(false);
                                                    },
                                                    child:
                                                        const Text('Cancelar'),
                                                  ),
                                                  TextButton(
                                                    onPressed: () {
                                                      Modular.to.pop(true);
                                                    },
                                                    child:
                                                        const Text('Confirmar'),
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
                            })
                            .toList()
                            .cast<DataRow>(),
                      );
                    },
                  ),
                )
              ],
            )));
  }

  Future<void> modalCadastrar([SecretariaModel? secretaria]) async {
    bool isEdit = secretaria?.id != null;
    TextEditingController secretariaBairroEditCtrl =
        TextEditingController(text: secretaria?.bairro ?? '');
    TextEditingController secretariaCepEditCtrl =
        TextEditingController(text: secretaria?.cep ?? '');
    TextEditingController secretariaCidadeEditCtrl =
        TextEditingController(text: secretaria?.cidade ?? '');
    TextEditingController secretariaCnpjEditCtrl =
        TextEditingController(text: secretaria?.cnpj ?? '');
    TextEditingController secretariaEmailEditCtrl =
        TextEditingController(text: secretaria?.email ?? '');
    TextEditingController secretariaEstadoEditCtrl =
        TextEditingController(text: secretaria?.estado ?? '');
    TextEditingController secretariaLogradouroEditCtrl =
        TextEditingController(text: secretaria?.logradouro ?? '');
    TextEditingController secretariaNumeroEditCtrl =
        TextEditingController(text: secretaria?.numero.toString());
    TextEditingController secretariaNRSocialEditCtrl =
        TextEditingController(text: secretaria?.nomeRazaoSocial ?? '');
    TextEditingController secretariaNomeEditCtrl =
        TextEditingController(text: secretaria?.nome ?? '');

    await showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: Text('${isEdit ? 'Editar' : 'Cadastro de'} Secretaria'),
          content: Wrap(
            children: [
              TextField(
                controller: secretariaNomeEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'Nome',
                ),
              ),
              TextField(
                controller: secretariaNRSocialEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'Nome Razão Social',
                ),
              ),
              TextField(
                controller: secretariaCnpjEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'CNPJ',
                ),
              ),
              TextField(
                controller: secretariaEmailEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'Email',
                ),
              ),
              TextField(
                controller: secretariaCepEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'CEP',
                ),
              ),
              TextField(
                controller: secretariaLogradouroEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'Logradouro',
                ),
              ),
              TextField(
                controller: secretariaNumeroEditCtrl,
                inputFormatters: [FilteringTextInputFormatter.digitsOnly],
                decoration: const InputDecoration(
                  labelText: 'Numero',
                ),
              ),
              TextField(
                controller: secretariaBairroEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'Bairro',
                ),
              ),
              TextField(
                controller: secretariaCidadeEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'Cidade',
                ),
              ),
              TextField(
                controller: secretariaEstadoEditCtrl,
                decoration: const InputDecoration(
                  labelText: 'Estado',
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
                // tela load
                secretaria = secretaria?.copyWith(
                  bairro: secretariaBairroEditCtrl.text,
                  cep: secretariaCepEditCtrl.text,
                  cidade: secretariaCidadeEditCtrl.text,
                  cnpj: secretariaCnpjEditCtrl.text,
                  email: secretariaEmailEditCtrl.text,
                  estado: secretariaEstadoEditCtrl.text,
                  logradouro: secretariaLogradouroEditCtrl.text,
                  nome: secretariaNomeEditCtrl.text,
                  nomeRazaoSocial: secretariaNRSocialEditCtrl.text,
                  numero: int.parse(secretariaNumeroEditCtrl.text),
                );
                if (isEdit) {
                  final resp = await service.editData(
                    secretaria!.toJson(),
                  );
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) => null);
                } else {
                  final resp = await service.postData(secretaria!.toJson());
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
    secretariaBairroEditCtrl.dispose();
    secretariaCepEditCtrl.dispose();
    secretariaCidadeEditCtrl.dispose();
    secretariaCnpjEditCtrl.dispose();
    secretariaEmailEditCtrl.dispose();
    secretariaEstadoEditCtrl.dispose();
    secretariaLogradouroEditCtrl.dispose();
    secretariaNomeEditCtrl.dispose();
    secretariaNRSocialEditCtrl.dispose();
    secretariaNumeroEditCtrl.dispose();
  }
}
