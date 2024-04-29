import 'package:flutter/material.dart';
import 'package:front/app/components/Scaffold_comp.dart';
import 'package:front/app/modules/despesas/tipo_despesas_model.dart';
import 'package:front/app/modules/despesas/tipo_despesas_service.dart';
import 'package:result_dart/result_dart.dart';

class TipoDeDespesas extends StatefulWidget {
  TipoDeDespesas({Key? key}) : super(key: key);

  @override
  State<TipoDeDespesas> createState() => _TipoDeDespesasState();
}

class _TipoDeDespesasState extends State<TipoDeDespesas> {
  final TextEditingController _controller = TextEditingController();
  late TipoDeDespesasServiceImpl service;

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return ScaffoldComp(
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          children: [
            const Padding(
              padding: EdgeInsets.only(bottom: 50),
              child: Text(
                "Cadastro de Despesas",
                style: TextStyle(
                  fontSize: 30,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            Column(
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                ElevatedButton(
                  onPressed: () {
                    showDialog(
                      context: context,
                      builder: (BuildContext context) {
                        return AlertDialog(
                          title: const Text('Cadastro de Despesas'),
                          content: TextField(
                            controller: _controller,
                            decoration: const InputDecoration(
                              hintText: 'Nome da Despesa',
                            ),
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
                              onPressed: () {
                                Future(() => service
                                        .postData(_controller.text)
                                        .then((success) {})
                                        .catchError((error) {
                                      print(error);
                                    }));
                                Navigator.of(context).pop();
                              },
                            ),
                          ],
                        );
                      },
                    );
                  },
                  child: const Text('Cadastrar Nova Despesa'),
                ),
                const SizedBox(height: 30),
                Row(
                  children: [
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
                    const SizedBox(
                      width: 20,
                    ),
                    const Expanded(
                      child: TextField(
                        decoration: InputDecoration(
                          hintText: 'Buscar Despesa',
                          prefixIcon: Icon(Icons.search),
                          border: OutlineInputBorder(),
                        ),
                      ),
                    ),
                  ],
                ),
              ],
            ),

            Padding(
              padding: const EdgeInsets.only(top: 60),
              child: Expanded(
                child: FutureBuilder(
                  future: service.getAll(_controller).getOrNull(),
                  builder: (context, AsyncSnapshot snapshot) {
                    List<TipoDespesasModel> tp = snapshot.data;
                    return DataTable(
                      border: TableBorder.all(),
                      columns: const [DataColumn(label: Text('Descricao'))],
                      rows: tp
                          .map((e) =>
                              DataRow(cells: [DataCell(Text(e.tipoDespesa))]))
                          .toList(),
                    );
                  },
                ),
              ),
            )
            // Wrap(
            //   children: [
            //     Expanded(
            //       child: Container(
            //         decoration: BoxDecoration(
            //             color: const Color.fromARGB(255, 255, 255, 255),
            //             border: Border.all(color: Colors.black, width: 1)),
            //         height: 60,
            //         width: 1500,
            //         child: const Center(
            //             child: Text(
            //           "Nenhum registro encontrado",
            //           style:
            //               TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
            //         )),
            //       ),
            //     ),
            //   ],
            // )
          ],
        ),
      ),
    );
  }
}
