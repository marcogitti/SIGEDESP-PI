import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_drop_down_comp.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/fornecedor/fornecedor_model.dart';
import 'package:front/app/modules/fornecedor/fornecedor_service.dart';
import 'package:front/app/util/situacao_enum.dart';
import 'package:result_dart/result_dart.dart';

class FornecedorPage extends StatefulWidget {
  const FornecedorPage({Key? key}) : super(key: key);

  @override
  State<FornecedorPage> createState() => _FornecedorPageState();
}

class _FornecedorPageState extends State<FornecedorPage> {
  late TextEditingController _controller;
  final service = Modular.get<FornecedorServiceImpl>();

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
              "Fornecedor",
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

                final tp = (snapshot.data ?? []).cast<FornecedorModel?>();

                return SizedBox(
                  height: 500,
                  width: double.infinity,
                  child: DataTable(
                    border: TableBorder.all(),
                    columns: const [
                      DataColumn(
                          label: Text(
                        'Id',
                        style: TextStyle(fontWeight: FontWeight.bold),
                      )),
                      DataColumn(label: Text('Nome Fantasia')),
                      DataColumn(label: Text('CNPJ')),
                      DataColumn(label: Text('CEP')),
                      DataColumn(label: Text('Logradouro')),
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
                              Text(e?.nomeFantasia.toString() ?? ''),
                            ),
                            DataCell(
                              Text(e?.cnpj.toString() ?? ''),
                            ),
                            DataCell(
                              Text(e?.cep.toString() ?? ''),
                            ),
                            DataCell(
                              Text(e?.logradouro.toString() ?? ''),
                            ),
                            DataCell(
                              Text(e?.situacao.toString() ?? ''),
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
    );
  }

  Future<void> modalCadastrar([FornecedorModel? fornecedor]) async {
    bool isEdit = fornecedor?.id != null;
    if (!isEdit) {
      fornecedor = FornecedorModel();
    }
    SituacaoEnum situacaoEnum = fornecedor?.situacao ?? SituacaoEnum.ativo;

    TextEditingController fornecedorBairroEditCtrl =
        TextEditingController(text: fornecedor?.bairro ?? '');
    TextEditingController fornecedorCepEditCtrl =
        TextEditingController(text: fornecedor?.cep ?? '');
    TextEditingController fornecedorCidadeEditCtrl =
        TextEditingController(text: fornecedor?.cidade ?? '');
    TextEditingController fornecedorCnpjEditCtrl =
        TextEditingController(text: fornecedor?.cnpj ?? '');
    TextEditingController fornecedorEmailEditCtrl =
        TextEditingController(text: fornecedor?.email ?? '');
    TextEditingController fornecedorEstadoEditCtrl =
        TextEditingController(text: fornecedor?.estado ?? '');
    TextEditingController fornecedorLogradouroEditCtrl =
        TextEditingController(text: fornecedor?.logradouro ?? '');
    TextEditingController fornecedorNumeroEditCtrl =
        TextEditingController(text: fornecedor?.numero ?? '');
    TextEditingController fornecedorTelefoneEditCtrl =
        TextEditingController(text: fornecedor?.telefone ?? '');
    TextEditingController fornecedorNomeFantasiaEditCtrl =
        TextEditingController(text: fornecedor?.nomeFantasia ?? '');
    TextEditingController fornecedorNomeEditCtrl =
        TextEditingController(text: fornecedor?.nome ?? '');

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
                    controller: fornecedorNomeEditCtrl,
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
                    controller: fornecedorNomeFantasiaEditCtrl,
                    decoration: const InputDecoration(
                      labelText: 'Nome Fantasia',
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Campo obrigatório';
                      }
                      return null;
                    },
                  ),
                  TextFormField(
                    controller: fornecedorCnpjEditCtrl,
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
                    controller: fornecedorEmailEditCtrl,
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
                    controller: fornecedorTelefoneEditCtrl,
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
                    controller: fornecedorCepEditCtrl,
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
                    controller: fornecedorLogradouroEditCtrl,
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
                    controller: fornecedorNumeroEditCtrl,
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
                    controller: fornecedorBairroEditCtrl,
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
                    controller: fornecedorCidadeEditCtrl,
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
                    controller: fornecedorEstadoEditCtrl,
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
                    labelText: 'fornecedor',
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
                fornecedor = fornecedor?.copyWith(
                  bairro: fornecedorBairroEditCtrl.text,
                  cep: fornecedorCepEditCtrl.text,
                  cidade: fornecedorCidadeEditCtrl.text,
                  cnpj: fornecedorCnpjEditCtrl.text,
                  email: fornecedorEmailEditCtrl.text,
                  estado: fornecedorEstadoEditCtrl.text,
                  logradouro: fornecedorLogradouroEditCtrl.text,
                  nome: fornecedorNomeEditCtrl.text,
                  telefone: fornecedorTelefoneEditCtrl.text,
                  numero: fornecedorNumeroEditCtrl.text,
                  nomeFantasia: fornecedorNomeFantasiaEditCtrl.text,
                  situacao: situacaoEnum,
                );
                if (isEdit) {
                  final resp = await service.editData(
                    fornecedor!,
                  );
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) => null);
                } else {
                  final resp = await service.postData(fornecedor!);
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
    fornecedorBairroEditCtrl.dispose();
    fornecedorCepEditCtrl.dispose();
    fornecedorCidadeEditCtrl.dispose();
    fornecedorCnpjEditCtrl.dispose();
    fornecedorEmailEditCtrl.dispose();
    fornecedorEstadoEditCtrl.dispose();
    fornecedorLogradouroEditCtrl.dispose();
    fornecedorNomeEditCtrl.dispose();
    fornecedorNumeroEditCtrl.dispose();
    fornecedorNomeFantasiaEditCtrl.dispose();
    fornecedorTelefoneEditCtrl.dispose();
  }
}
