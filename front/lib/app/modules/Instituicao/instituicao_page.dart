// import 'package:flutter/material.dart';
// import 'package:flutter_modular/flutter_modular.dart';
// import 'package:front/app/components/scaffold_comp.dart';
// import 'package:front/app/modules/Instituicao/instituicao_model.dart';
// import 'package:front/app/modules/Instituicao/instituicao_service.dart';
// import 'package:result_dart/result_dart.dart';

// class InstituicaoPage extends StatefulWidget {
//   const InstituicaoPage({Key? key}) : super(key: key);

//   @override
//   State<InstituicaoPage> createState() => _InstituicaoPageState();
// }

// class _InstituicaoPageState extends State<InstituicaoPage> {
//   late TextEditingController _controller;
//   final service = Modular.get<InstituicaoServiceImpl>();

//   @override
//   void initState() {
//     _controller = TextEditingController();
//     super.initState();
//   }

//   @override
//   void dispose() {
//     _controller.dispose();
//     super.dispose();
//   }

//   @override
//   Widget build(BuildContext context) {
//     return ScaffoldComp(
//         body: Padding(
//             padding: const EdgeInsets.all(16.0),
//             child: ListView(
//               children: [
//                 const Padding(
//                   padding: EdgeInsets.only(bottom: 50),
//                   child: Text(
//                     "Cadastro de Instituição",
//                     style: TextStyle(
//                       fontSize: 30,
//                       fontWeight: FontWeight.bold,
//                     ),
//                   ),
//                 ),
//                 Column(
//                   crossAxisAlignment: CrossAxisAlignment.stretch,
//                   children: [
//                     TextField(
//                       decoration: const InputDecoration(
//                         hintText: 'Buscar Instituição',
//                         prefixIcon: Icon(Icons.search),
//                         border: OutlineInputBorder(),
//                       ),
//                       controller: _controller,
//                     ),
//                     const SizedBox(height: 30),
//                     Row(
//                       children: [
//                         ElevatedButton(
//                           onPressed: () async {
//                             await modalCadastrar();
//                           },
//                           child: const Text('Cadastrar Nova Instituição'),
//                         ),
//                         const SizedBox(width: 15),
//                         const Text("Mostrar: "),
//                         DropdownButton<String>(
//                           borderRadius: BorderRadius.circular(10),
//                           elevation: 10,
//                           items: <String>['Opção 1', 'Opção 2', 'Opção 3']
//                               .map((String value) {
//                             return DropdownMenuItem<String>(
//                               value: value,
//                               child: Text(value),
//                             );
//                           }).toList(),
//                           onChanged: (String? newValue) {},
//                         ),
//                         const SizedBox(width: 20),
//                       ],
//                     ),
//                   ],
//                 ),
//                 Padding(
//                   padding: const EdgeInsets.only(top: 60),
//                   child: FutureBuilder(
//                     future: service.getAll().getOrNull(),
//                     builder: (context, AsyncSnapshot snapshot) {
//                       if (snapshot.connectionState == ConnectionState.none) {
//                         return const Text("sem internet");
//                       }

//                       if (snapshot.connectionState == ConnectionState.waiting) {
//                         return const Center(
//                           child: SizedBox(
//                             width: 26,
//                             height: 26,
//                             child: CircularProgressIndicator(),
//                           ),
//                         );
//                       }

//                       if (snapshot.hasError) {
//                         return const Text("Erro");
//                       }

//                       final tp =
//                           (snapshot.data ?? []).cast<InstituicaoModel?>();

//                       return DataTable(
//                         border: TableBorder.all(),
//                         columns: const [DataColumn(label: Text('Descrição'))],
//                         rows: tp
//                             .map((e) {
//                               return DataRow(cells: [
//                                 DataCell(
//                                   Row(
//                                     children: [
//                                       Expanded(
//                                           child: Text(
//                                               e?.situacao.toString() ?? '')),
//                                       IconButton(
//                                         icon: const Icon(Icons.edit),
//                                         onPressed: () async {
//                                           await modalCadastrar(e);
//                                         },
//                                       ),
//                                       IconButton(
//                                         icon: const Icon(Icons.delete),
//                                         onPressed: () async {
//                                           final confirmDelete =
//                                               await showDialog<bool>(
//                                             context: context,
//                                             builder: (BuildContext context) {
//                                               return AlertDialog(
//                                                 title: const Text(
//                                                     'Confirmar exclusão'),
//                                                 content: const Text(
//                                                     'Tem certeza que deseja excluir este item?'),
//                                                 actions: <Widget>[
//                                                   TextButton(
//                                                     onPressed: () {
//                                                       Modular.to.pop(false);
//                                                     },
//                                                     child:
//                                                         const Text('Cancelar'),
//                                                   ),
//                                                   TextButton(
//                                                     onPressed: () {
//                                                       Modular.to.pop(true);
//                                                     },
//                                                     child:
//                                                         const Text('Confirmar'),
//                                                   ),
//                                                 ],
//                                               );
//                                             },
//                                           );
//                                           if (confirmDelete == true) {}
//                                         },
//                                       ),
//                                     ],
//                                   ),
//                                 ),
//                               ]);
//                             })
//                             .toList()
//                             .cast<DataRow>(),
//                       );
//                     },
//                   ),
//                 )
//               ],
//             )));
//   }

//   Future<void> modalCadastrar([InstituicaoModel? instituicao]) async {
//     bool isEdit = instituicao?.id != null;
//     TextEditingController instituicaoEditCtrl =
//         TextEditingController(text: instituicao?.situacao.toString());
//     TextEditingController instituicaoBairroEditCtrl =
//         TextEditingController(text: instituicao?.bairro ?? '');
//     TextEditingController instituicaoCepEditCtrl =
//         TextEditingController(text: instituicao?.cep ?? '');
//     TextEditingController instituicaoCidadeEditCtrl =
//         TextEditingController(text: instituicao?.cidade ?? '');
//     TextEditingController instituicaoCnpjEditCtrl =
//         TextEditingController(text: instituicao?.cnpj ?? '');
//     TextEditingController instituicaoEmailEditCtrl =
//         TextEditingController(text: instituicao?.email ?? '');
//     TextEditingController instituicaoEstadoEditCtrl =
//         TextEditingController(text: instituicao?.estado ?? '');
//     TextEditingController instituicaoLogradouroEditCtrl =
//         TextEditingController(text: instituicao?.logradouro ?? '');
//     TextEditingController instituicaoNumeroEditCtrl =
//         TextEditingController(text: instituicao?.numero.toString());
//     TextEditingController instituicaoNRSocialEditCtrl =
//         TextEditingController(text: instituicao?.nomeRazaoSocial ?? '');
//     TextEditingController instituicaoIdSecretariaEditCtrl =
//         TextEditingController(text: instituicao?.idSecretaria.toString());
//     TextEditingController instituicaoIdTipoInstituicaoEditCtrl =
//         TextEditingController(text: instituicao?.idTipoInstituicao.toString());

//     await showDialog(
//       context: context,
//       builder: (BuildContext context) {
//         return AlertDialog(
//           title: Text('${isEdit ? 'Editar' : 'Cadastro de'} Instituição'),
//           content: Wrap(
//             children: [
//               TextField(
//                 controller: instituicaoEditCtrl,
//                 decoration: const InputDecoration(
//                   labelText: 'Situação',
//                 ),
//               ),
//               TextField(
//                 controller: instituicaoDescEditCtrl,
//                 decoration: const InputDecoration(
//                   labelText: 'Descrição',
//                 ),
//               ),
//               TextField(
//                 controller: instituicaoDescEditCtrl,
//                 decoration: const InputDecoration(
//                   labelText: 'Descrição',
//                 ),
//               ),
//             ],
//           ),
//           actions: <Widget>[
//             TextButton(
//               child: const Text('Cancelar'),
//               onPressed: () {
//                 Navigator.of(context).pop();
//               },
//             ),
//             TextButton(
//               child: const Text('Salvar'),
//               onPressed: () async {
                //tela load
//                 if (isEdit) {
//                   final resp = await service.editData(
//                     instituicao!
//                         .copyWith(
//                           situacao: instituicaoEditCtrl.text,
//                           bairro: instituicaoBairroEditCtrl.text,
//                           cep: instituicaoCepEditCtrl.text,
//                           cidade: instituicaoCidadeEditCtrl.text,
//                           cnpj: instituicaoCnpjEditCtrl.text,
//                           email: instituicaoEmailEditCtrl.text,
//                           estado: instituicaoEstadoEditCtrl.text,
//                           //  idSecretaria: instituicaoidEditCtrl.text,
//                           //  idTipoInstituicao: instituicao EditCtrl.text,
//                           logradouro: instituicaoLogradouroEditCtrl.text,
//                           nome: instituicaoNomeEditCtrl.text,
//                           nomeRazaoSocial: instituicaoNRSocialEditCtrl.text,
//                           numero: instituicaoNumeroEditCtrl.text,
//                         )
//                         .toJson(),
//                   );
//                   resp.fold((success) {
//                     Navigator.of(context).pop();
//                     setState(() {});
//                   }, (failure) => null);
//                 } else {
//                   final resp = await service.postData(
//                     InstituicaoModel(
//                       numero: instituicaoDescEditCtrl.text,
//                       bairro: instituicaoDescEditCtrl.text,
//                       cep: instituicaoDescEditCtrl.text,
//                       cidade: instituicaoDescEditCtrl.text,
//                       cnpj: instituicaoDescEditCtrl.text,
//                       email: instituicaoDescEditCtrl.text,
//                       estado: instituicaoDescEditCtrl.text,
//                       idSecretaria: instituicaoDescEditCtrl.text,
//                       idTipoInstituicao: instituicaoDescEditCtrl.text,
//                       logradouro: instituicaoDescEditCtrl.text,
//                       nome: instituicaoDescEditCtrl.text,
//                       nomeRazaoSocial: instituicaoDescEditCtrl.text,
//                       situacao: instituicaoEditCtrl.text,
//                     ).toJson(),
//                   );
//                   resp.fold((success) {
//                     Navigator.of(context).pop();
//                     setState(() {});
//                   }, (failure) {
//                     //snack bar
//                     print('erro$failure');
//                   });
//                 }
//               },
//             ),
//           ],
//         );
//       },
//     );
//     instituicaoEditCtrl.dispose();
//     instituicaoDescEditCtrl.dispose();
//   }
// }
