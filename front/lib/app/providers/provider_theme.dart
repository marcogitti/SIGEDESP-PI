import 'package:flutter/material.dart';

class ThemeProvider with ChangeNotifier {
  bool _isHighContrastTheme = true;

  bool get isHighContrastTheme => _isHighContrastTheme;

  void toggleTheme() {
    _isHighContrastTheme = !_isHighContrastTheme;
    notifyListeners();
  }

}
