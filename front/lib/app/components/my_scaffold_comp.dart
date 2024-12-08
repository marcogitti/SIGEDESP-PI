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
          // const Flexible(
          //   child: Text(
          //     'Nome do Usuário',
          //     style: TextStyle(
          //       fontSize: 14,
          //       fontWeight: FontWeight.bold,
          //       color: Colors.white,
          //       overflow: TextOverflow.ellipsis,
          //     ),
          //   ),
          // ),
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
                            // ListTile(
                            //   leading: const Icon(
                            //     Icons.home,
                            //     color: Colors.white,
                            //   ),
                            //   title: const Text(
                            //     "Tela Inicial",
                            //     style: TextStyle(
                            //       color: Colors.white,
                            //     ),
                            //   ),
                            //   onTap: () => Modular.to.navigate("/"),
                            // ),
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
                                  children: <Widget>[
                                    ListTile(
                                      title: const Text(
                                        'Tipo Despesa',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {
                                        Modular.to.navigate('/tipoDeDespesas');
                                      },
                                    ),
                                    ListTile(
                                      title: const Text(
                                        'Despesa',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {
                                        Modular.to.navigate('/despesas');
                                      },
                                    ),
                                  ],
                                ),
                                ExpansionTile(
                                  leading: const Icon(
                                    Icons.attach_money,
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
                                  children: <Widget>[
                                    ListTile(
                                      title: const Text(
                                        'Orçamento',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {
                                        Modular.to.navigate('/orcamento');
                                      },
                                    ),
                                  ],
                                ),
                                // ExpansionTile(
                                //   leading: const Icon(
                                //     Icons.person,
                                //     color: Colors.white,
                                //   ),
                                //   title: const Row(
                                //     children: [
                                //       Text(
                                //         "Usuario",
                                //         style: TextStyle(
                                //           color: Colors.white,
                                //         ),
                                //       ),
                                //     ],
                                //   ),
                                //   children: <Widget>[
                                //     ListTile(
                                //       title: const Text(
                                //         'Usuario',
                                //         style: TextStyle(color: Colors.white),
                                //       ),
                                //       onTap: () {},
                                //     ),
                                //     ListTile(
                                //       title: const Text(
                                //         'Tipo Usuario',
                                //         style: TextStyle(color: Colors.white),
                                //       ),
                                //       onTap: () {},
                                //     ),
                                //   ],
                                // ),
                                ExpansionTile(
                                  leading: const Icon(
                                    Icons.domain,
                                    color: Colors.white,
                                  ),
                                  title: const Row(
                                    children: [
                                      Text(
                                        "Secretaria",
                                        style: TextStyle(
                                          color: Colors.white,
                                        ),
                                      ),
                                    ],
                                  ),
                                  children: <Widget>[
                                    ListTile(
                                      title: const Text(
                                        'Secretaria',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {
                                        Modular.to.navigate('/secretariaPage');
                                      },
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
                                  children: <Widget>[
                                    ListTile(
                                      title: const Text(
                                        'Instituições',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {
                                        Modular.to.navigate('/instituicaoPage');
                                      },
                                    ),
                                    ListTile(
                                      title: const Text(
                                        'Tipo Instituições',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {
                                        Modular.to
                                            .navigate('/tipoInstituicaoPage');
                                      },
                                    ),
                                  ],
                                ),

                                ExpansionTile(
                                  leading: const Icon(
                                    Icons.onetwothree,
                                    size: 30,
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
                                  children: <Widget>[
                                    ListTile(
                                      title: const Text(
                                        'Unidade Consumidora',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {
                                        Modular.to
                                            .navigate('/unidadeConsumidora');
                                      },
                                    ),
                                    ListTile(
                                      title: const Text(
                                        'Unidade Medida',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {
                                        Modular.to.navigate('/unidadeDeMedida');
                                      },
                                    ),
                                  ],
                                ),

                                ExpansionTile(
                                  leading: const Icon(
                                    Icons.diversity_3_outlined,
                                    color: Colors.white,
                                  ),
                                  title: const Row(
                                    children: [
                                      Text(
                                        "Fornecedor",
                                        style: TextStyle(
                                          color: Colors.white,
                                        ),
                                      ),
                                    ],
                                  ),
                                  children: <Widget>[
                                    ListTile(
                                      title: const Text(
                                        'Fornecedor',
                                        style: TextStyle(color: Colors.white),
                                      ),
                                      onTap: () {
                                        Modular.to.navigate('/fornecedorPage');
                                      },
                                    ),
                                  ],
                                ),
                              ],
                            ),
                            const Divider(),
                            const ListTile(
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
                            ListTile(
                              leading: const Icon(
                                Icons.data_thresholding_outlined,
                                color: Colors.white,
                              ),
                              title: const Text(
                                "Dashboard",
                                style: TextStyle(
                                  color: Colors.white,
                                ),
                              ),
                              onTap: () {
                                Modular.to.navigate("/");
                              },
                            ),
                            const Divider(),
                            ExpansionTile(
                              leading: const Icon(
                                Icons.person,
                                size: 30,
                                color: Colors.white,
                              ),
                              title: const Row(
                                children: [
                                  Text(
                                    "Usuário",
                                    style: TextStyle(
                                      color: Colors.white,
                                    ),
                                  ),
                                ],
                              ),
                              children: <Widget>[
                                ListTile(
                                  title: const Text(
                                    'Sair',
                                    style: TextStyle(color: Colors.white),
                                  ),
                                  onTap: () {
                                    Modular.to.navigate('/loginPage');
                                  },
                                ),
                              ],
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
