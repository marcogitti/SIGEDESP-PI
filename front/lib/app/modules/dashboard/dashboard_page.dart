import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/components/grafico_de_pizza.dart';
import 'package:front/app/components/my_drop_down_comp.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/modules/instituicao/instituicao_service.dart';
import 'package:front/app/modules/despesas/despesas_model.dart';
import 'package:front/app/modules/despesas/despesas_service.dart';
import 'package:result_dart/result_dart.dart';

class DashboardPage extends StatefulWidget {
  const DashboardPage({super.key});

  @override
  State<DashboardPage> createState() => _DashboardPageState();
}

class _DashboardPageState extends State<DashboardPage> {
  final service = Modular.get<DespesasServiceImpl>();

  @override
  Widget build(BuildContext context) {
    return ScaffoldComp(
      body: Column(
        children: [],
      ),
    );
  }
}
