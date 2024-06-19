import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/my_card_comp.dart';
import 'package:charts_flutter/flutter.dart' as charts;
import 'package:front/app/components/my_scaffold_comp.dart';

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
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.only(top: 40.0),
          child: Wrap(
            runSpacing: 16,
            spacing: 16,
            children: [
              MyCardComp(
                textButton: TextButton(
                  onPressed: () {
                    Modular.to.navigate('//instituicaoPage');
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
                textButton: TextButton(
                  onPressed: () {
                    Modular.to.navigate('/tipoDeDespesas');
                  },
                  child: const Padding(
                    padding: EdgeInsets.only(top: 40),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                        Text("Cadastro de Tipo"),
                        Text("Despesas"),
                      ],
                    ),
                  ),
                ),
              ),
              MyCardComp(
                textButton: TextButton(
                  onPressed: () {
                    Modular.to.navigate('/unidadeDeMedida');
                  },
                  child: const Padding(
                    padding: EdgeInsets.only(top: 40),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                        Text("Cadastro de Unidade"),
                        Text("De Medida"),
                      ],
                    ),
                  ),
                ),
              ),
              MyCardComp(
                textButton: TextButton(
                  onPressed: () {
                    Modular.to.navigate('/unidadeConsumidora');
                  },
                  child: const Padding(
                    padding: EdgeInsets.only(top: 40),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                        Text("Cadastro de Unidade"),
                        Text("Consumidora"),
                      ],
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
