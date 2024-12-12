import 'package:collection/collection.dart';
import 'package:flutter/material.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:intl/intl.dart';
import 'package:front/app/components/grafico_de_pizza.dart';
import 'package:front/app/components/my_drop_down_comp.dart';
import 'package:front/app/components/my_scaffold_comp.dart';
import 'package:front/app/modules/instituicao/instituicao_service.dart';
import 'package:front/app/modules/despesas/despesas_model.dart';
import 'package:front/app/modules/despesas/despesas_service.dart';
import 'package:front/app/modules/instituicao/instituicao_model.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final service = Modular.get<DespesasServiceImpl>();
  List<List<DespesaModel>> despesasGapStatus = [];
  List<List<DespesaModel>> despesasGapTipo = [];

  InstituicaoModel? instituicao;
  DateTimeRange? periodo = DateTimeRange(
    start: DateTime.now().subtract(const Duration(days: 30)),
    end: DateTime.now(),
  );

  @override
  void initState() {
    recalcDadosGap();

    super.initState();
  }

  Future<void> recalcDadosGap() async {
    final resp = (await service.getAll()).getOrElse((_) => []);
    despesasGapStatus = filtraInstituicao(filtraPeriodo(resp))
        .groupListsBy((e) => e.statusDespesa)
        .values
        .toList();

    despesasGapTipo = filtraInstituicao(filtraPeriodo(resp))
        .groupListsBy((e) => e.tipoDespesa?.descricao)
        .values
        .toList();

    setState(() {});
  }

  List<DespesaModel> filtraPeriodo(List<DespesaModel> value) {
    return value
        .where((e) =>
            (e.dataPagamento?.isAfter(periodo!.start) ?? false) &&
            (e.dataPagamento?.isBefore(periodo!.end) ?? false))
        .toList();
  }

  List<DespesaModel> filtraInstituicao(List<DespesaModel> value) {
    if (instituicao == null) {
      return value;
    }
    return value.where((e) => e.instituicao?.id == instituicao?.id).toList();
  }

  @override
  Widget build(BuildContext context) {
    return ScaffoldComp(
      body: ListView(
        children: [
          Wrap(
            spacing: 16,
            runSpacing: 12,
            children: [
              SizedBox(
                width: 320,
                child: TextField(
                  decoration: const InputDecoration(
                    labelText: 'Selecione o período',
                    contentPadding: EdgeInsets.zero,
                  ),
                  controller: TextEditingController(
                    text: periodo != null
                        ? '${DateFormat('dd/MM/yyyy').format(periodo!.start)} - ${DateFormat('dd/MM/yyyy').format(periodo!.end)}'
                        : '',
                  ),
                  readOnly: true, // Para impedir a edição manual
                  onTap: () async {
                    final novoPeriodo = await showDateRangePicker(
                      context: context,
                      firstDate:
                          DateTime.now().subtract(const Duration(days: 365)),
                      lastDate: DateTime.now(),
                    );
                    if (novoPeriodo != null) {
                      setState(() {
                        periodo = novoPeriodo;
                      });
                      recalcDadosGap();
                    }
                  },
                ),
              ),
              SizedBox(
                width: 260,
                child:
                    MyDropDownGetComp<InstituicaoModel, InstituicaoServiceImpl>(
                  labelText: 'Selecione a instituicao',
                  initValue: instituicao,
                  onChanged: (value) {
                    instituicao = value;
                    recalcDadosGap();
                  },
                ),
              ),
            ],
          ),
          const Text('Instituição'),

          GraficoPizzaComp<DespesaModel>(
            dados: despesasGapStatus,
          ),

          const Text('Tipo de Despesa'),
          GraficoPizzaTipoDispComp<DespesaModel>(
            dados: despesasGapTipo,
          )

          //    Gráficos
        ],
      ),
    );
  }
}
