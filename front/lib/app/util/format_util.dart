import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

class FormatUtil {
  static String doubleToReal(double? value) => value == null
      ? ''
      : NumberFormat.currency(locale: 'pt_BR', symbol: '', decimalDigits: 2)
          .format(value);
}

extension WidgetExtension on List<Widget> {
  List<Widget> spaceBetowin({double? wh, double? ht}) {
    List<Widget> newList = [];
    forEach((e) {
      newList.add(
        SizedBox(
          height: ht,
          width: wh,
        ),
      );
      newList.add(e);
      newList.add(
        SizedBox(
          height: ht,
          width: wh,
        ),
      );
    });

    return newList;
  }
}

extension DateFormatExtension on DateTime? {
  String get toYMD {
    return DateFormat('yyyy-MM-dd').format(this ?? DateTime.now());
  }

  String get toDMY {
    return DateFormat('dd/MM/yyyy').format(this ?? DateTime.now());
  }

  String get toYYM {
    return DateFormat('yyyy/MM').format(this ?? DateTime.now());
  }
}
