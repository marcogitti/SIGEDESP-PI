import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/providers/provider_theme.dart';
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
          PopupMenuButton(
            itemBuilder: (context) {
              return TipoThemeApp.values
                  .map((tipo) {
                    return PopupMenuItem(
                      child: tipo.icon,
                      onTap: () {
                        Modular.get<ThemeApp>().toggleTheme(tipo);
                      },
                    );
                  })
                  .toList()
                  .cast<PopupMenuItem>();
            },
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
                      const DrawerHeader(
                        decoration: BoxDecoration(
                          color: Color(0xFF222D32),
                        ),
                        child: Center(
                          child: Text(
                            'SIGEDESP',
                            style: TextStyle(color: Colors.white),
                          ),
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.only(top: 20),
                        child: Wrap(
                          runSpacing: 8,
                          spacing: 8,
                          children: [
                            const ExpansionTile(
                              leading: Icon(
                                Icons.home,
                                color: Colors.white,
                              ),
                              title: Text(
                                "Tela Inicial",
                                style: TextStyle(
                                  color: Colors.white,
                                ),
                              ),
                            ),
                            const Divider(),
                            ExpansionTile(
                              leading: const Icon(
                                Icons.edit,
                                color: Colors.white,
                              ),
                              title: const Text(
                                "Cadastros",
                                style: TextStyle(
                                  color: Colors.white,
                                ),
                              ),
                              children: [
                                ExpansionTile(
                                  leading: const Icon(
                                    Icons.request_quote_outlined,
                                    color: Colors.white,
                                  ),
                                  title: const Row(
                                    children: [
                                      Text(
                                        "Despesas",
                                        style: TextStyle(
                                          color: Colors.white,
                                        ),
                                      ),
                                    ],
                                  ),
                                  trailing: const Icon(
                                    Icons.keyboard_arrow_down,
                                    color: Colors.white,
                                  ),
                                  children: <Widget>[
                                    ListTile(
                                      leading: const Icon(
                                        Icons.description,
                                        color: Colors.white,
                                      ),
                                      title: const Text(
                                        'Cadastro Tipo Despesa',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {},
                                    ),
                                    ListTile(
                                      leading: const Icon(
                                        Icons.description,
                                        color: Colors.white,
                                      ),
                                      title: const Text(
                                        'Cadastro De Despesa',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {},
                                    ),
                                  ],
                                ),
                                ExpansionTile(
                                  leading: const Icon(
                                    Icons.person,
                                    color: Colors.white,
                                  ),
                                  title: const Row(
                                    children: [
                                      Text(
                                        "Usuario",
                                        style: TextStyle(
                                          color: Colors.white,
                                        ),
                                      ),
                                    ],
                                  ),
                                  trailing: const Icon(
                                    Icons.keyboard_arrow_down,
                                    color: Colors.white,
                                  ),
                                  children: <Widget>[
                                    ListTile(
                                      leading: const Icon(
                                        Icons.description,
                                        color: Colors.white,
                                      ),
                                      title: const Text(
                                        'Cadastro Usuario',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {},
                                    ),
                                    ListTile(
                                      leading: const Icon(
                                        Icons.description,
                                        color: Colors.white,
                                      ),
                                      title: const Text(
                                        'Cadastro Tipo Usuario',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {},
                                    ),
                                  ],
                                ),
                                ExpansionTile(
                                  leading: const Icon(
                                    Icons.maps_home_work_outlined,
                                    color: Colors.white,
                                  ),
                                  title: const Row(
                                    children: [
                                      Expanded(
                                        child: Text(
                                          "Orgãos Públicos ",
                                          style: TextStyle(
                                            color: Colors.white,
                                          ),
                                        ),
                                      ),
                                    ],
                                  ),
                                  trailing: const Icon(
                                    Icons.keyboard_arrow_down,
                                    color: Colors.white,
                                  ),
                                  children: <Widget>[
                                    ListTile(
                                      leading: const Icon(
                                        Icons.description,
                                        color: Colors.white,
                                      ),
                                      title: const Text(
                                        'Cadastro Instituições',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {},
                                    ),
                                    ListTile(
                                      leading: const Icon(
                                        Icons.description,
                                        color: Colors.white,
                                      ),
                                      title: const Text(
                                        'Cadastro Tipo Instituições',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {},
                                    ),
                                    ListTile(
                                      leading: const Icon(
                                        Icons.description,
                                        color: Colors.white,
                                      ),
                                      title: const Text(
                                        'Cadastro Secretaria',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {},
                                    ),
                                  ],
                                ),
                                ExpansionTile(
                                  leading: const Icon(
                                    Icons.request_quote_outlined,
                                    color: Colors.white,
                                  ),
                                  title: const Row(
                                    children: [
                                      Text(
                                        "Unidades",
                                        style: TextStyle(
                                          color: Colors.white,
                                        ),
                                      ),
                                    ],
                                  ),
                                  trailing: const Icon(
                                    Icons.request_quote,
                                    color: Colors.white,
                                  ),
                                  children: <Widget>[
                                    ListTile(
                                      leading: const Icon(
                                        Icons.description,
                                        color: Colors.white,
                                      ),
                                      title: const Text(
                                        'Cadastro Unidade Consumidora',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {},
                                    ),
                                    ListTile(
                                      leading: const Icon(
                                        Icons.description,
                                        color: Colors.white,
                                      ),
                                      title: const Text(
                                        'Cadastro Unidade Medida',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {},
                                    ),
                                  ],
                                ),
                                ExpansionTile(
                                  leading: const Icon(
                                    Icons.request_quote_outlined,
                                    color: Colors.white,
                                  ),
                                  title: const Row(
                                    children: [
                                      Text(
                                        "Orçamento",
                                        style: TextStyle(
                                          color: Colors.white,
                                        ),
                                      ),
                                    ],
                                  ),
                                  trailing: const Icon(
                                    Icons.price_change_outlined,
                                    color: Colors.white,
                                  ),
                                  children: <Widget>[
                                    ListTile(
                                      leading: const Icon(
                                        Icons.description,
                                        color: Colors.white,
                                      ),
                                      title: const Text(
                                        'Cadastro Orçamento',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {},
                                    ),
                                  ],
                                ),
                              ],
                            ),
                            const Divider(),
                            const ExpansionTile(
                              leading: Icon(
                                Icons.receipt_long,
                                color: Colors.white,
                              ),
                              title: Text(
                                "Relatorios",
                                style: TextStyle(
                                  color: Colors.white,
                                ),
                              ),
                            ),
                            const ExpansionTile(
                              leading: Icon(
                                Icons.data_thresholding_outlined,
                                color: Colors.white,
                              ),
                              title: Text(
                                "Dashboard",
                                style: TextStyle(
                                  color: Colors.white,
                                ),
                              ),
                            ),
                            const Divider(),
                            const ExpansionTile(
                              leading: Icon(
                                Icons.person,
                                color: Colors.white,
                              ),
                              title: Text(
                                "Perfil",
                                style: TextStyle(
                                  color: Colors.white,
                                ),
                              ),
                            ),
                            const Divider(),
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
