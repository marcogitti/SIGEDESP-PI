import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/util/format_util.dart';

class ScaffoldComp extends StatelessWidget {
  const ScaffoldComp({
    Key? key,
    required this.body,
  }) : super(key: key);
  final Widget body;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leadingWidth: 12,
        backgroundColor: const Color(0xFF3C8DBC),
        title: Container(
          margin: const EdgeInsets.all(5),
          child: const FlutterLogo(
            size: 20,
          ),
        ),
        actions: [
          IconButton(
            onPressed: () {},
            icon: const Icon(Icons.notifications, color: Colors.white),
          ),
          IconButton(
            onPressed: () {},
            icon: const Icon(
              Icons.settings,
              color: Colors.white,
            ),
          ),
          const Icon(Icons.account_circle, color: Colors.white),
          const Flexible(
            child: Text(
              'Nome do Usuário',
              style: TextStyle(
                fontSize: 14,
                fontWeight: FontWeight.bold,
                color: Colors.white,
                overflow: TextOverflow.ellipsis,
              ),
            ),
          ),
        ].spaceBetowin(wh: 6),
      ),
      body: LayoutBuilder(
        builder: (BuildContext context, BoxConstraints constraints) {
          if (constraints.maxWidth > 600) {
            return Row(
              children: <Widget>[
                Container(
                  width: 260,
                  color: const Color(0xFF222D32),
                  child: ListView(
                    padding: EdgeInsets.zero,
                    children: <Widget>[
                      DrawerHeader(
                        decoration: const BoxDecoration(
                          color: Color(0xFF222D32),
                        ),
                        child: Center(
                          child: Row(
                            children: [
                              IconButton(
                                  onPressed: () {},
                                  icon: const Icon(Icons.account_circle,
                                      color: Colors.white)),
                              const SizedBox(height: 10),
                              const Text(
                                'Nome do Usuario',
                                style: TextStyle(color: Colors.white),
                              ),
                            ],
                          ),
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.only(top: 20),
                        child: Wrap(
                          runSpacing: 16,
                          spacing: 16,
                          children: [
                            ListTile(
                              title: const Text(
                                'Home Page',
                                style: TextStyle(color: Colors.white),
                              ),
                              onTap: () {
                                return Modular.to.navigate('/');
                              },
                            ),
                            ListTile(
                              title: const Text(
                                'Tipo Instituição',
                                style: TextStyle(color: Colors.white),
                              ),
                              onTap: () {
                                return Modular.to
                                    .navigate('/institutionScreen');
                              },
                            ),
                            ListTile(
                              title: const Text(
                                'Cadastro de Despesas',
                                style: TextStyle(color: Colors.white),
                              ),
                              onTap: () {
                                return Modular.to
                                    .navigate('/cadastroDeDespesas');
                              },
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
                Expanded(
                  child: Container(
                    alignment: Alignment.topCenter,
                    padding:
                        const EdgeInsets.only(left: 26, right: 16, top: 50),
                    child: body,
                  ),
                ),
              ],
            );
          }
          return body;
        },
      ),
    );
  }
}
