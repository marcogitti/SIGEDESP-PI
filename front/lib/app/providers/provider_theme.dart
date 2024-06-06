import 'package:flutter/material.dart';

class ThemeApp {
  final _theme = ValueNotifier(TipoThemeApp.light);

  ValueNotifier<TipoThemeApp> get theme => _theme;

  void toggleTheme(TipoThemeApp value) {
    if (value != _theme.value) {
      _theme.value = value;
    }
  }
}

enum TipoThemeApp {
  light(icon: Icon(Icons.sunny)),
  ligthDaltonico(icon: Icon(Icons.dataset_linked)),
  dark(icon: Icon(Icons.brightness_medium_outlined));

  final Widget icon;

  const TipoThemeApp({required this.icon});
}
