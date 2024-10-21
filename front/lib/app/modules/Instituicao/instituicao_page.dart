import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_drop_down_comp.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/modules/instituicao/instituicao_service.dart';
import 'package:front/app/modules/instituicao/tipo_instituicao_model.dart';
import 'package:front/app/modules/instituicao/tipo_instituicao_service.dart';
import 'package:front/app/modules/secretaria/secretaria_model.dart';
import 'package:front/app/modules/secretaria/secretaria_service.dart';
import 'package:front/app/util/situacao_enum.dart';
import 'package:result_dart/result_dart.dart';

class InstituicaoPage extends StatefulWidget {
  const InstituicaoPage({Key? key}) : super(key: key);

  @override
  State<InstituicaoPage> createState() => _InstituicaoPageState();
}

class _InstituicaoPageState extends State<InstituicaoPage> {
  late TextEditingController _controller;
  final service = Modular.get<InstituicaoServiceImpl>();

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
                "Cadastro de Instituição",
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
                    hintText: 'Buscar Instituição',
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
                      child: const Text('Cadastrar Nova Instituição'),
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
                ),
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

                  final tp = (snapshot.data ?? []).cast<InstituicaoModel?>();
                  return SingleChildScrollView(
                    dragStartBehavior: DragStartBehavior.start,
                    scrollDirection: Axis.horizontal,
                    child: DataTable(
                      border: TableBorder.all(),
                      columns: const [
                        DataColumn(label: Text('Nome')),
                        DataColumn(label: Text('CNPJ')),
                        DataColumn(label: Text('Situação')),
                        DataColumn(label: Text('Secretaria')),
                        DataColumn(label: Text('Tipo Instituição')),
                        DataColumn(label: Text('Ação')),
                      ],
                      rows: tp
                          .map((e) {
                            return DataRow(cells: [
                              DataCell(
                                Text(e?.nome.toString() ?? ''),
                              ),
                              DataCell(
                                Text(e?.cnpj.toString() ?? ''),
                              ),
                              DataCell(
                                Text(e?.situacao.toString() ?? ''),
                              ),
                              DataCell(
                                Text(e?.idSecretaria.toString() ?? ''),
                              ),
                              DataCell(
                                Text(e?.idTipoInstituicao.toString() ?? ''),
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
                                                  if (e != null &&
                                                      e.id != null) {
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
            ),
          ],
        ),
      ),
    );
  }

  Future<void> modalCadastrar([InstituicaoModel? instituicao]) async {
    bool isEdit = instituicao?.id != null;
    if (!isEdit) {
      instituicao = InstituicaoModel();
    }
    SituacaoEnum situacaoEnum = instituicao?.situacao ?? SituacaoEnum.ativo;
    SecretariaModel? selectedSecretaria;
    TipoInstituicaoModel? selectedTipoInstituicao;

    TextEditingController instituicaoBairroEditCtrl =
        TextEditingController(text: instituicao?.bairro ?? '');
    TextEditingController instituicaoCepEditCtrl = TextEditingController(
        text: instituicao?.cep != null ? instituicao?.cep.toString() : '');
    TextEditingController instituicaoCidadeEditCtrl =
        TextEditingController(text: instituicao?.cidade ?? '');
    TextEditingController instituicaoCnpjEditCtrl =
        TextEditingController(text: instituicao?.cnpj ?? '');
    TextEditingController instituicaoEmailEditCtrl =
        TextEditingController(text: instituicao?.email ?? '');
    TextEditingController instituicaoEstadoEditCtrl =
        TextEditingController(text: instituicao?.estado ?? '');
    TextEditingController instituicaoLogradouroEditCtrl =
        TextEditingController(text: instituicao?.logradouro ?? '');
    TextEditingController instituicaoNumeroEditCtrl = TextEditingController(
        text:
            instituicao?.numero != null ? instituicao?.numero.toString() : '');
    TextEditingController instituicaoNRSocialEditCtrl =
        TextEditingController(text: instituicao?.nomeRazaoSocial ?? '');
    TextEditingController instituicaoNomeEditCtrl =
        TextEditingController(text: instituicao?.nome ?? '');
    TextEditingController instituicaoTelefoneEditCtrl =
        TextEditingController(text: instituicao?.telefone ?? '');

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
                    controller: instituicaoNomeEditCtrl,
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
                    controller: instituicaoNRSocialEditCtrl,
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
                    controller: instituicaoCnpjEditCtrl,
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
                    controller: instituicaoEmailEditCtrl,
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
                    controller: instituicaoCepEditCtrl,
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
                    controller: instituicaoLogradouroEditCtrl,
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
                    controller: instituicaoNumeroEditCtrl,
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
                    controller: instituicaoBairroEditCtrl,
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
                    controller: instituicaoCidadeEditCtrl,
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
                    controller: instituicaoEstadoEditCtrl,
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
                  MyDropDownGetComp<SecretariaModel, SecretariaServiceImpl>(
                    labelText: 'Secretaria',
                    initValue: selectedSecretaria,
                    onChanged: (value) {
                      selectedSecretaria = value;
                    },
                  ),
                  MyDropDownGetComp<TipoInstituicaoModel,
                      TipoInstituicaoServiceImpl>(
                    labelText: 'Tipo instituicao',
                    initValue: selectedTipoInstituicao,
                    onChanged: (value) {
                      selectedTipoInstituicao = value;
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
                instituicao = instituicao?.copyWith(
                  bairro: instituicaoBairroEditCtrl.text,
                  cep: int.tryParse(instituicaoCepEditCtrl.text),
                  cidade: instituicaoCidadeEditCtrl.text,
                  cnpj: instituicaoCnpjEditCtrl.text,
                  email: instituicaoEmailEditCtrl.text,
                  estado: instituicaoEstadoEditCtrl.text,
                  logradouro: instituicaoLogradouroEditCtrl.text,
                  nome: instituicaoNomeEditCtrl.text,
                  nomeRazaoSocial: instituicaoNRSocialEditCtrl.text,
                  numero: int.tryParse(instituicaoNumeroEditCtrl.text),
                  situacao: situacaoEnum,
                  telefone: instituicaoTelefoneEditCtrl.text,
                  secretaria: instituicao?.secretaria,
                  tipoInstituicao: instituicao?.tipoInstituicao,
                );
                if (isEdit) {
                  final resp = await service.editData(
                    instituicao!,
                  );
                  resp.fold((success) {
                    Navigator.of(context).pop();
                    setState(() {});
                  }, (failure) => null);
                } else {
                  final resp = await service.postData(instituicao!);
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
    instituicaoBairroEditCtrl.dispose();
    instituicaoCepEditCtrl.dispose();
    instituicaoCidadeEditCtrl.dispose();
    instituicaoCnpjEditCtrl.dispose();
    instituicaoEmailEditCtrl.dispose();
    instituicaoEstadoEditCtrl.dispose();
    instituicaoLogradouroEditCtrl.dispose();
    instituicaoNomeEditCtrl.dispose();
    instituicaoNRSocialEditCtrl.dispose();
    instituicaoNumeroEditCtrl.dispose();
  }
}
