import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/providers/provider_theme.dart';
import 'package:provider/provider.dart';
import 'app/config/app_module.dart';
import 'app/config/app_widget.dart';

void main() {
  return runApp( 
  ChangeNotifierProvider(
      create: (context) => ThemeProvider(),
      child: ModularApp(
      module: AppModule(),
      child:  AppWidget(),
    ),
    ),
  );
}