import 'package:flutter/material.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:front/app/components/my_scaffold_comp.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return const ScaffoldComp(
      body: ResponsiveCards(),
    );
  }
}

class ResponsiveCards extends StatelessWidget {
  const ResponsiveCards({super.key});

  @override
  Widget build(BuildContext context) {
    const int aPagar = 2;
    const int pago = 0;
    const int pendente = 0;

    return Column(
      children: [
        // Linha com 3 cards horizontais
        const Expanded(
          flex: 2,
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Expanded(
                child: StatusCard(
                    status: 'A Pagar', quantity: aPagar, color: Colors.orange),
              ),
              SizedBox(width: 8), // Espaçamento entre os cards
              Expanded(
                child: StatusCard(
                    status: 'Pago', quantity: pago, color: Colors.green),
              ),
              SizedBox(width: 8),
              Expanded(
                child: StatusCard(
                    status: 'Pendente', quantity: pendente, color: Colors.red),
              ),
            ],
          ),
        ),
        const SizedBox(height: 40), // Espaçamento entre as linhas de cards
        // Linha com 2 cards verticais maiores
        Expanded(
          flex: 3,
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Expanded(child: _buildPieChart(context, aPagar, pago, pendente)),
              const SizedBox(width: 8), // Espaçamento entre os cards verticais
              const Expanded(
                child: Padding(
                  padding: EdgeInsets.only(
                      bottom: 70.0), // Espaço inferior de 70 pixels
                  child: CustomBarChart(
                    aPagar: aPagar,
                    pago: pago,
                    pendente: pendente,
                  ),
                ),
              ),
            ],
          ),
        ),
      ],
    );
  }

  Widget _buildPieChart(
      BuildContext context, int aPagar, int pago, int pendente) {
    final data = [
      aPagar.toDouble(),
      pago.toDouble(),
      pendente.toDouble()
    ]; // Dados com base nas quantidades

    return Row(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        Expanded(
          flex: 3,
          child: Padding(
            padding: const EdgeInsets.all(16.0),
            child: PieChart(
              PieChartData(
                sections: [
                  PieChartSectionData(
                      value: data[0], color: Colors.orange), // A Pagar
                  PieChartSectionData(
                      value: data[1], color: Colors.green), // Pago
                  PieChartSectionData(
                      value: data[2], color: Colors.red), // Pendente
                ],
                sectionsSpace: 2,
                centerSpaceRadius: 40,
              ),
            ),
          ),
        ),
        const SizedBox(width: 16), // Espaço entre o gráfico e a legenda
        Expanded(
          flex: 2,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment:
                CrossAxisAlignment.start, // Alinha as legendas à esquerda
            children: [
              _buildLegend('A Pagar', Colors.orange),
              _buildLegend('Pago', Colors.green),
              _buildLegend('Pendente', Colors.red),
            ],
          ),
        ),
      ],
    );
  }

  Widget _buildLegend(String status, Color color) {
    return Row(
      children: [
        Container(
          width: 10,
          height: 10,
          color: color,
        ),
        const SizedBox(width: 8),
        Text(status, style: const TextStyle(fontSize: 16)),
      ],
    );
  }
}

class CustomBarChart extends StatelessWidget {
  final int aPagar;
  final int pago;
  final int pendente;

  const CustomBarChart(
      {Key? key,
      required this.aPagar,
      required this.pago,
      required this.pendente})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return BarChart(
      BarChartData(
        alignment: BarChartAlignment.spaceAround,
        maxY: (aPagar + pago + pendente).toDouble(),
        barGroups: [
          BarChartGroupData(
            x: 2,
            barRods: [
              BarChartRodData(
                y: aPagar.toDouble(),
                colors: [Colors.orange],
                width: 20,
              ),
            ],
          ),
          BarChartGroupData(
            x: 2,
            barRods: [
              BarChartRodData(
                y: pago.toDouble(),
                colors: [Colors.green],
                width: 20,
              ),
            ],
          ),
          BarChartGroupData(
            x: 3,
            barRods: [
              BarChartRodData(
                y: pendente.toDouble(),
                colors: [Colors.red],
                width: 20,
              ),
            ],
          ),
        ],
        borderData: FlBorderData(show: false),
        titlesData: FlTitlesData(
          bottomTitles: SideTitles(
            showTitles: true,
            getTitles: (double value) {
              switch (value.toInt()) {
                case 2:
                  return 'A Pagar';
                case 3:
                  return 'Pendente';
                default:
                  return '';
              }
            },
          ),
          leftTitles: SideTitles(showTitles: true),
        ),
      ),
    );
  }
}

class StatusCard extends StatelessWidget {
  final String status;
  final int quantity;
  final Color color;

  const StatusCard(
      {Key? key,
      required this.status,
      required this.quantity,
      required this.color})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: Row(
        children: [
          Expanded(
            flex: 3,
            child: Container(
              color: color,
              height: 150,
              child: Center(
                child: Text(
                  status,
                  style: const TextStyle(color: Colors.white, fontSize: 16),
                ),
              ),
            ),
          ),
          Expanded(
            flex: 2,
            child: Container(
              color: color.withOpacity(0.5),
              height: 150,
              child: Center(
                child: Text(
                  quantity.toString(),
                  style: const TextStyle(color: Colors.white, fontSize: 16),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
