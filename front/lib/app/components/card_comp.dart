// ignore_for_file: public_member_api_docs, sort_constructors_first

import 'package:flutter/material.dart';

class MyCardComp extends StatelessWidget {
  const MyCardComp({
    Key? key,
    required this.child,
    this.height,
    this.width,
    this.color,
  }) : super(key: key);
  final Widget child;
  final double? height;
  final double? width;
  final Color? color;

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(10),
      height: height,
      width: width,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20),
        color: color,
      ),
      child: child,
    );
  }
}
