import 'package:flutter/material.dart';

class UsuarioPage extends StatelessWidget {
  const UsuarioPage({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: const Text('Perfil do Usuário'),
        ),
        body: Padding(
          padding: const EdgeInsets.all(20),
          child: Column(
            children: <Widget>[
              const TextField(
                decoration: InputDecoration(
                  labelText: 'Nome',
                ),
              ),
              const TextField(
                decoration: InputDecoration(
                  labelText: 'Email',
                ),
              ),
              const TextField(
                decoration: InputDecoration(
                  labelText: 'Telefone',
                ),
              ),
              OutlinedButton(
                onPressed: () {},
                child: const Text('Salvar'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
