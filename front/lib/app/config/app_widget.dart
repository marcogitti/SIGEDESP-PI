import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/providers/provider_theme.dart';
import 'package:provider/provider.dart';
import 'package:overlay_support/overlay_support.dart';
import 'package:bot_toast/bot_toast.dart'; // Importando BotToastNavigatorObserver

class AppWidget extends StatelessWidget {
   const AppWidget({super.key, });

  @override
  Widget build(BuildContext context) {
    final GlobalKey<NavigatorState> navigatorKey = GlobalKey<NavigatorState>();

    return Consumer<ThemeProvider>(
      builder: (context, themeProvider, child) {
        return MaterialApp.router(
          title: 'Accessible App',
          debugShowCheckedModeBanner: false,
          // theme: themeProvider.isHighContrastTheme;
              // ? _highContrastDarkTheme
              // : _normalDarkTheme,
          routeInformationParser: Modular.routeInformationParser,
          routerDelegate: Modular.routerDelegate,
          builder: (context, router) {
            return OverlaySupport(
              child: MaterialApp(
                debugShowCheckedModeBanner: false,
                navigatorKey: navigatorKey,
                title: 'App',
                theme: ThemeData(
                  primarySwatch: Colors.blue,
                  visualDensity: VisualDensity.adaptivePlatformDensity,
                ),
                navigatorObservers: [
                  BotToastNavigatorObserver(),
                ],
                home: router!,
              ),
            );
          },
        );
      },
    );
  }
}

// final ThemeData _highContrastDarkTheme = ThemeData(
//   brightness: Brightness.dark,
//   primaryColor: Colors.black,
//   hintColor: Colors.yellow,
//   textTheme: const TextTheme(
//     bodyLarge: TextStyle(fontSize: 20.0, color: Colors.white),
//     bodyMedium: TextStyle(fontSize: 18.0, color: Colors.white),
//     displayLarge: TextStyle(
//         fontSize: 26.0, color: Colors.yellow, fontWeight: FontWeight.bold),
//   ),
//   elevatedButtonTheme: ElevatedButtonThemeData(
//     style: ElevatedButton.styleFrom(
//       foregroundColor: Colors.yellow,
//       backgroundColor: Colors.black,
//       textStyle: const TextStyle(fontSize: 20),
//     ),
//   ),
// );

// final ThemeData _normalDarkTheme = ThemeData(
//   brightness: Brightness.dark,
//   primaryColor: Colors.black,
//   hintColor: Colors.white,
//   textTheme: const TextTheme(
//     bodyLarge: TextStyle(fontSize: 18.0, color: Colors.white),
//     bodyMedium: TextStyle(fontSize: 16.0, color: Colors.white),
//     displayLarge: TextStyle(
//         fontSize: 24.0, color: Colors.white, fontWeight: FontWeight.bold),
//   ),
//   elevatedButtonTheme: ElevatedButtonThemeData(
//     style: ElevatedButton.styleFrom(
//       foregroundColor: Colors.white,
//       backgroundColor: Colors.black,
//       textStyle: const TextStyle(fontSize: 18),
//     ),
//   ),
// );
