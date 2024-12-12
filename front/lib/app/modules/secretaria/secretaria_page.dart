import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_drop_down_comp.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/secretaria/secretaria_model.dart';
import 'package:front/app/modules/secretaria/secretaria_service.dart';
import 'package:front/app/util/situacao_enum.dart';
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
      body: ListView(
        padding: const EdgeInsets.all(16.0),
        children: [
          const Padding(
            padding: EdgeInsets.only(bottom: 50),
            child: Text(
              "Secretaria",
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

                List<SecretariaModel?> tp =
                    (snapshot.data ?? []).cast<SecretariaModel?>();

                return SizedBox(
                  height: 500,
                  width: double.infinity,
                  child: DataTable(
                    border: TableBorder.all(),
                    columns: const [
                      DataColumn(label: Text('Id')),
                      DataColumn(label: Text('Nome')),
                      DataColumn(label: Text('CNPJ')),
                      DataColumn(label: Text('Situação')),
                      DataColumn(label: Text('Ação')),
                    ],
                    rows: tp
                        .map((e) {
                          return DataRow(cells: [
                            DataCell(
                              Text(e?.id.toString() ?? ''),
                            ),
                            DataCell(
                              Text(e?.nome.toString() ?? ''),
                            ),
                            DataCell(
                              Text(e?.cnpj.toString() ?? ''),
                            ),
                            DataCell(
                              Text(e?.situacao?.nome ?? ''),
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
                                                await service
                                                    .deleteData(e!.id!);

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
    );
  }

  Future<void> modalCadastrar([SecretariaModel? secretaria]) async {
    bool isEdit = secretaria?.id != null;
    if (!isEdit) {
      secretaria = SecretariaModel();
    }
    SituacaoEnum situacaoEnum = secretaria?.situacao ?? SituacaoEnum.ativo;

    TextEditingController secretariaBairroEditCtrl =
        TextEditingController(text: secretaria?.bairro ?? '');
    TextEditingController secretariaCepEditCtrl = TextEditingController(
        text: secretaria?.cep != null ? secretaria?.cep.toString() : '');
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
    TextEditingController secretariaNumeroEditCtrl = TextEditingController(
        text: secretaria?.numero != null ? secretaria?.numero.toString() : '');
    TextEditingController secretariaTelefoneEditCtrl =
        TextEditingController(text: secretaria?.telefone ?? '');
    TextEditingController secretariaNRSocialEditCtrl =
        TextEditingController(text: secretaria?.nomeRazaoSocial ?? '');
    TextEditingController secretariaNomeEditCtrl =
        TextEditingController(text: secretaria?.nomeRazaoSocial ?? '');
    TextEditingController secretariaDecricaoEditCtrl =
        TextEditingController(text: secretaria?.descricao ?? '');

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
                    controller: secretariaNomeEditCtrl,
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
                    controller: secretariaNRSocialEditCtrl,
                    decoration: const InputDecoration(
                      labelText: 'Nome Razão Social',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: secretariaCnpjEditCtrl,
                    decoration: const InputDecoration(
                      labelText: 'CNPJ',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: secretariaEmailEditCtrl,
                    decoration: const InputDecoration(
                      labelText: 'Email',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: secretariaDecricaoEditCtrl,
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
                  TextFormField(
                    controller: secretariaTelefoneEditCtrl,
                    inputFormatters: [FilteringTextInputFormatter.digitsOnly],
                    decoration: const InputDecoration(
                      labelText: 'Telefone',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: secretariaCepEditCtrl,
                    decoration: const InputDecoration(
                      labelText: 'CEP',
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
                    controller: secretariaLogradouroEditCtrl,
                    decoration: const InputDecoration(
                      labelText: 'Logradouro',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: secretariaNumeroEditCtrl,
                    inputFormatters: [FilteringTextInputFormatter.digitsOnly],
                    decoration: const InputDecoration(
                      labelText: 'Número',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: secretariaBairroEditCtrl,
                    decoration: const InputDecoration(
                      labelText: 'Bairro',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: secretariaCidadeEditCtrl,
                    decoration: const InputDecoration(
                      labelText: 'Cidade',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: secretariaEstadoEditCtrl,
                    decoration: const InputDecoration(
                      labelText: 'Estado',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  MyDropDownComp(
                    initValue: situacaoEnum,
                    itens: SituacaoEnum.values,
                    onChanged: (value) {
                      situacaoEnum = value!;
                    },
                    labelText: 'Secretaria',
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
                secretaria = secretaria?.copyWith(
                  bairro: secretariaBairroEditCtrl.text,
                  cep: secretariaCepEditCtrl.text,
                  cidade: secretariaCidadeEditCtrl.text,
                  cnpj: secretariaCnpjEditCtrl.text,
                  email: secretariaEmailEditCtrl.text,
                  estado: secretariaEstadoEditCtrl.text,
                  logradouro: secretariaLogradouroEditCtrl.text,
                  nome: secretariaNomeEditCtrl.text,
                  telefone: secretariaTelefoneEditCtrl.text,
                  nomeRazaoSocial: secretariaNRSocialEditCtrl.text,
                  numero: secretariaNumeroEditCtrl.text,
                  descricao: secretariaDecricaoEditCtrl.text,
                  situacao: situacaoEnum,
                );
                if (isEdit) {
                  final resp = await service.editData(
                    secretaria!,
                  );
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) => null);
                } else {
                  final resp = await service.postData(secretaria!);
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
    secretariaDecricaoEditCtrl.dispose();
    secretariaTelefoneEditCtrl.dispose();
  }
}
