import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/providers/provider_theme.dart';
import 'package:bot_toast/bot_toast.dart'; // Importando BotToastNavigatorObserver

class AppWidget extends StatefulWidget {
  const AppWidget({
    super.key,
  });

  @override
  State<AppWidget> createState() => _AppWidgetState();
}

class _AppWidgetState extends State<AppWidget> {
  @override
  void initState() {
    Modular.setObservers([BotToastNavigatorObserver()]);
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return ValueListenableBuilder(
        valueListenable: Modular.get<ThemeApp>().theme,
        builder: (_, tipo, __) {
          return MaterialApp.router(
            title: 'Accessible App',
            debugShowCheckedModeBanner: false,
            theme: createTheme(tipo),
            routeInformationParser: Modular.routeInformationParser,
            routerDelegate: Modular.routerDelegate,
            builder: BotToastInit(),
          );
        });
  }
}

ThemeData createTheme(TipoThemeApp tipo) {
  switch (tipo) {
    case TipoThemeApp.light:
      return ThemeData(
        brightness: Brightness.light,
        colorSchemeSeed: Colors.blue,
        elevatedButtonTheme: ElevatedButtonThemeData(
          style: ElevatedButton.styleFrom(
            foregroundColor: Colors.white,
            backgroundColor: Colors.orange,
            textStyle: const TextStyle(fontSize: 18),
          ),
        ),
      );

    case TipoThemeApp.ligthDaltonico:
      return ThemeData(
        brightness: Brightness.light,
        colorSchemeSeed: Colors.blue,
      );
    case TipoThemeApp.dark:
      return ThemeData(
        brightness: Brightness.dark,
        primaryColor: Colors.black,
        hintColor: Colors.yellow,
        textTheme: const TextTheme(
          bodyLarge: TextStyle(fontSize: 20.0, color: Colors.white),
          bodyMedium: TextStyle(fontSize: 18.0, color: Colors.white),
          displayLarge: TextStyle(
              fontSize: 26.0,
              color: Colors.yellow,
              fontWeight: FontWeight.bold),
        ),
        elevatedButtonTheme: ElevatedButtonThemeData(
          style: ElevatedButton.styleFrom(
            foregroundColor: Colors.yellow,
            backgroundColor: Colors.black,
            textStyle: const TextStyle(fontSize: 20),
          ),
        ),
      );

    default:
      return ThemeData();
  }
}
