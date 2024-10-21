import 'package:flutter/material.dart';
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
    return const Column(
      children: [
        // Linha com 3 cards horizontais
        Expanded(
          flex:
              2, // Ajuste o flex para controlar o espaço ocupado por esta linha
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Expanded(child: CardWidget()),
              SizedBox(
                  width: 8), // Espaçamento reduzido entre os cards horizontais
              Expanded(child: CardWidget()),
              SizedBox(width: 8),
              Expanded(child: CardWidget()),
            ],
          ),
        ),
        SizedBox(height: 8), // Espaçamento reduzido entre as linhas de cards
        // Linha com 2 cards verticais maiores
        Expanded(
          flex:
              3, // Ajuste o flex para controlar o espaço ocupado por esta linha
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Expanded(child: CardWidget(vertical: true)),
              SizedBox(
                  width: 8), // Espaçamento reduzido entre os cards verticais
              Expanded(child: CardWidget(vertical: true)),
            ],
          ),
        ),
      ],
    );
  }
}

class CardWidget extends StatelessWidget {
  final bool vertical;

  const CardWidget({Key? key, this.vertical = false}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: Container(
        color: Colors.blueAccent,
        height: vertical ? MediaQuery.of(context).size.height / 2 : 150,
        child: Center(
          child: Text(
            'Card ${vertical ? 'Vertical' : 'Horizontal'}',
            style: const TextStyle(color: Colors.white, fontSize: 16),
          ),
        ),
      ),
    );
  }
}
