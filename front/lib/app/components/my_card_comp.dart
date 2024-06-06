import 'package:flutter/material.dart';

class MyCardComp extends StatelessWidget {
  final Widget textButton;
  final double height;
  final double width;
  final Color? color;

  const MyCardComp({
    Key? key,
    required this.textButton,
    this.height = 150,
    this.width = 200,
    this.color,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: SizedBox(
        height: height,
        width: width,
        child: Center(child: textButton),
      ),
    );
  }
}
