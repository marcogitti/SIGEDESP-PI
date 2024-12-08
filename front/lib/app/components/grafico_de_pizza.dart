// ignore_for_file: public_member_api_docs, sort_constructors_first
import 'dart:math';

import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:collection/collection.dart';
import 'package:front/app/modules/despesas/despesas_model.dart';

class GraficoPizzaComp<T> extends StatefulWidget {
  final List<List<DespesaModel>>? dados;

  const GraficoPizzaComp({
    Key? key,
    required this.dados,
  }) : super(key: key);

  @override
  State<GraficoPizzaComp> createState() => _GraficoPizzaCompState();
}

class _GraficoPizzaCompState extends State<GraficoPizzaComp> {
  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        SizedBox(
          width: 360,
          height: 140,
          child: PieChart(
            PieChartData(
              sections: widget.dados?.isEmpty ?? true
                  ? _generatePieChartSections()
                  : widget.dados
                      ?.map((e) => PieChartSectionData(
                            color: e.firstOrNull?.statusDespesa?.cor,
                            value: e.length * 1,
                            title:
                                '${(e.length * 100 / widget.dados!.flattened.length).round()}%',
                            radius: 50,
                            titleStyle: const TextStyle(
                              fontSize: 14,
                              fontWeight: FontWeight.bold,
                              color: Colors.white,
                            ),
                          ))
                      .toList(),
              centerSpaceRadius: 40,
              sectionsSpace: 2,
              borderData: FlBorderData(show: false),
            ),
          ),
        ),
        SizedBox(
          height: 26,
        ),
        Wrap(
          children: [
            ...widget.dados
                    ?.map(
                      (e) => _buildStatusCard(
                        e.first.statusDespesa?.nome ?? '',
                        e.length.toString(),
                        e.firstOrNull?.statusDespesa?.cor ?? Colors.black,
                      ),
                    )
                    .toList() ??
                []
          ],
        )
      ],
    );
  }

  Widget _buildStatusCard(String title, String value, Color color) {
    return Card(
      color: color,
      child: Container(
        padding: const EdgeInsets.all(16.0),
        constraints: const BoxConstraints(
          minWidth: 120,
        ),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              title,
              style: const TextStyle(
                color: Colors.white,
                fontSize: 16,
                fontWeight: FontWeight.bold,
              ),
            ),
            const SizedBox(height: 10),
            Text(
              value,
              style: const TextStyle(
                color: Colors.white,
                fontSize: 24,
                fontWeight: FontWeight.bold,
              ),
            ),
          ],
        ),
      ),
    );
  }

  List<PieChartSectionData> _generatePieChartSections() {
    return [
      PieChartSectionData(
        color: Colors.blue,
        value: 100,
        title: '0%',
        radius: 50,
        titleStyle: const TextStyle(
          fontSize: 16,
          fontWeight: FontWeight.bold,
          color: Colors.white,
        ),
      ),
    ];
  }
}

///////////////////////

class GraficoPizzaTipoDispComp<T> extends StatefulWidget {
  final List<List<DespesaModel>>? dados;

  const GraficoPizzaTipoDispComp({
    Key? key,
    required this.dados,
  }) : super(key: key);

  @override
  State<GraficoPizzaTipoDispComp> createState() =>
      _GraficoPizzaCompTipoDispState();
}

class _GraficoPizzaCompTipoDispState extends State<GraficoPizzaTipoDispComp> {
  Color getColorBk(int? index) {
    if (index != null) {
      return Color((Random(index * 2).nextDouble() * 0xFFFFFF).toInt())
          .withOpacity(1.0);
    }
    return Colors.black;
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        SizedBox(
          width: 320,
          height: 140,
          child: PieChart(
            PieChartData(
              sections: widget.dados?.isEmpty ?? true
                  ? _generatePieChartSections()
                  : widget.dados
                      ?.map((e) => PieChartSectionData(
                            color: getColorBk(widget.dados?.indexOf(e)),
                            value: e.length * 1,
                            title:
                                '${(e.length * 100 / widget.dados!.flattened.length).round()}%',
                            radius: 50,
                            titleStyle: const TextStyle(
                              fontSize: 14,
                              fontWeight: FontWeight.bold,
                              color: Colors.white,
                            ),
                          ))
                      .toList(),
              centerSpaceRadius: 40,
              sectionsSpace: 2,
              borderData: FlBorderData(show: false),
            ),
          ),
        ),
        SizedBox(
          height: 36,
        ),
        SingleChildScrollView(
          child: Wrap(
            children: [
              ...widget.dados
                      ?.mapIndexed((index, e) => MapEntry(
                            index,
                            _buildStatusCard(
                              e.first.tipoDespesa?.descricao ?? '',
                              e.length.toString(),
                              getColorBk(index),
                            ),
                          ).value)
                      .toList() ??
                  []
            ],
          ),
        ),
      ],
    );
  }

  Widget _buildStatusCard(String title, String value, Color color) {
    return Card(
      color: color,
      child: Container(
        padding: const EdgeInsets.all(16.0),
        constraints: const BoxConstraints(
          minWidth: 120,
        ),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              title,
              style: const TextStyle(
                color: Colors.white,
                fontSize: 16,
                fontWeight: FontWeight.bold,
              ),
            ),
            const SizedBox(height: 10),
            Text(
              value,
              style: const TextStyle(
                color: Colors.white,
                fontSize: 24,
                fontWeight: FontWeight.bold,
              ),
            ),
          ],
        ),
      ),
    );
  }

  List<PieChartSectionData> _generatePieChartSections() {
    return [
      PieChartSectionData(
        color: Colors.blue,
        value: 100,
        title: '0%',
        radius: 50,
        titleStyle: const TextStyle(
          fontSize: 16,
          fontWeight: FontWeight.bold,
          color: Colors.white,
        ),
      ),
    ];
  }
}
