import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/scaffold_comp.dart';
import 'package:front/app/components/card_comp.dart';
import 'package:charts_flutter/flutter.dart' as charts;

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final lineData = [
    charts.Series<int, int>(
      id: 'Vendas',
      colorFn: (_, __) => charts.MaterialPalette.blue.shadeDefault,
      domainFn: (int vendas, _) => vendas,
      measureFn: (int vendas, _) => vendas,
      data: [1, 2, 3, 4],
    )
  ];

  final pieData = [
    charts.Series<int, String>(
      id: 'Vendas',
      domainFn: (int vendas, _) => vendas.toString(),
      measureFn: (int vendas, _) => vendas,
      data: [1, 2, 3, 4],
    )
  ];

  @override
  Widget build(BuildContext context) {
    return ScaffoldComp(
      body: Wrap(
        runSpacing: 16,
        spacing: 16,
        children: [
          Padding(
            padding: const EdgeInsets.only(
              left: 350,
            ),
            child: Wrap(
              runSpacing: 16,
              spacing: 16,
              children: [
                MyCardComp(
                  height: 150,
                  width: 200,
                  color: const Color.fromARGB(255, 224, 224, 224),
                  child: TextButton(
                    onPressed: () {
                      Modular.to.navigate('/institutionScreen');
                    },
                    child: const Padding(
                      padding: EdgeInsets.only(top: 40),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: [
                          Text("Cadastro de Tipo"),
                          Text("Instituição"),
                        ],
                      ),
                    ),
                  ),
                ),
                MyCardComp(
                  height: 150,
                  width: 200,
                  color: const Color.fromARGB(255, 224, 224, 224),
                  child: TextButton(
                    onPressed: () {
                      Modular.to.navigate('/cadastroDeDespesas');
                    },
                    child: const Padding(
                      padding: EdgeInsets.only(top: 40),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: [
                          Text("Cadastro de "),
                          Text("Despesas"),
                        ],
                      ),
                    ),
                  ),
                ),
                const MyCardComp(
                  height: 150,
                  width: 200,
                  color: Color.fromARGB(255, 224, 224, 224),
                  child: Text("data"),
                ),
                const MyCardComp(
                  height: 150,
                  width: 200,
                  color: Color.fromARGB(255, 224, 224, 224),
                  child: Text("data"),
                ),
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.only(left: 150, right: 180),
            child: Wrap(
              runSpacing: 16,
              spacing: 16,
              children: [
                Padding(
                  padding: const EdgeInsets.only(top: 50),
                  child: Row(
                    children: [
                      Expanded(
                        child: MyCardComp(
                          height: 250,
                          width: 300,
                          color: const Color.fromARGB(255, 244, 244, 244),
                          child: SizedBox(
                            height: 200,
                            child: charts.LineChart(lineData),
                          ),
                        ),
                      ),
                      const SizedBox(
                        width: 20,
                      ),
                      Expanded(
                        child: MyCardComp(
                          height: 250,
                          width: 50,
                          color: const Color.fromARGB(255, 244, 244, 244),
                          child: SizedBox(
                            height: 200,
                            child: charts.PieChart(pieData),
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
