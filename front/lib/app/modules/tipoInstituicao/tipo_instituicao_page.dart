import 'package:flutter/material.dart';
import 'package:front/app/components/Scaffold_comp.dart';
import 'package:http/http.dart' as http;

class InstitutionScreen extends StatelessWidget {
  InstitutionScreen({Key? key}) : super(key: key);

  final TextEditingController _controller = TextEditingController();

  Future<void> _saveToApi(String name) async {
    var url = Uri.parse('localhost:7274/api/TipoDespessa');
    var response = await http.post(url, body: {'tipoDespesa': name});

    if (response.statusCode == 200) {
      print('Dados salvos com sucesso.');
    } else {
      print('Erro ao salvar dados.');
    }
  }

  @override
  Widget build(BuildContext context) {
    return ScaffoldComp(
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: SingleChildScrollView(
          child: Column(
            children: [
              const Padding(
                padding: EdgeInsets.only(bottom: 50),
                child: Text(
                  "Tipo Instituição",
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
                            title: const Text('Cadastro de Tipo Instituição'),
                            content: TextField(
                              controller: _controller,
                              decoration: const InputDecoration(
                                hintText: 'Nome da Instituição',
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
                                  _saveToApi(_controller.text);
                                  Navigator.of(context).pop();
                                },
                              ),
                            ],
                          );
                        },
                      );
                    },
                    child: const Text('Cadastrar Tipo Instituição'),
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
                            hintText: 'Buscar Tipo Instituição',
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
                padding: const EdgeInsets.only(top: 30),
                child: Expanded(
                  child: Wrap(
                    children: [
                      Expanded(
                        child: Container(
                          decoration: BoxDecoration(
                              color: const Color.fromARGB(255, 238, 238, 238),
                              border:
                                  Border.all(color: Colors.black, width: 1)),
                          height: 60,
                          width: 1000,
                          child: const Center(
                              child: Text(
                            "Descrição",
                            style: TextStyle(
                                fontSize: 16, fontWeight: FontWeight.bold),
                          )),
                        ),
                      ),
                      Expanded(
                        child: Container(
                          decoration: BoxDecoration(
                              color: const Color.fromARGB(255, 238, 238, 238),
                              border:
                                  Border.all(color: Colors.black, width: 1)),
                          height: 60,
                          width: 500,
                          child: const Center(
                              child: Text(
                            "",
                            style: TextStyle(
                                fontSize: 16, fontWeight: FontWeight.bold),
                          )),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
              Wrap(
                children: [
                  Expanded(
                    child: Container(
                      decoration: BoxDecoration(
                          color: const Color.fromARGB(255, 255, 255, 255),
                          border: Border.all(color: Colors.black, width: 1)),
                      height: 60,
                      width: 1500,
                      child: const Center(
                          child: Text(
                        "Nenhum registro encontrado",
                        style: TextStyle(
                            fontSize: 16, fontWeight: FontWeight.bold),
                      )),
                    ),
                  ),
                ],
              )
            ],
          ),
        ),
      ),
    );
  }
}
