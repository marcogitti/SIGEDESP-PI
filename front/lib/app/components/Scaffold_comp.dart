import 'package:flutter/material.dart';

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
          Padding(
            padding: const EdgeInsets.symmetric(horizontal: 8.0),
            child: Row(
              children: [
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
                const SizedBox(width: 2),
                const Text(
                  'Nome do Usuário',
                  style: TextStyle(
                      fontSize: 14,
                      fontWeight: FontWeight.bold,
                      color: Colors.white),
                ),
              ],
            ),
          ),
        ],
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
                        child: Center(
                          child: Row(
                            children: [
                              IconButton(
                                  onPressed: () {},
                                  icon: const Icon(Icons.account_circle,
                                      color: Colors.white)),
                              SizedBox(height: 10),
                              const Text(
                                'Drawer Header',
                                style: TextStyle(color: Colors.white),
                              ),
                            ],
                          ),
                        ),
                        decoration: BoxDecoration(
                          color: const Color(0xFF222D32),
                        ),
                      ),
                      ListTile(
                        title: const Text(
                          'Item 1',
                          style: TextStyle(color: Colors.white),
                        ),
                        onTap: () {
                          Navigator.pop(context);
                        },
                      ),
                      ListTile(
                        title: const Text(
                          'Item 2',
                          style: TextStyle(color: Colors.white),
                        ),
                        onTap: () {
                          Navigator.pop(context);
                        },
                      ),
                    ],
                  ),
                ),
                Expanded(
                  child: Padding(
                    padding: const EdgeInsets.all(12.0),
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
