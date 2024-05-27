import 'package:flutter/material.dart';

class MyCardComp extends StatelessWidget {
  final Widget textButton;
  final double height;
  final double width;
  final Color color;

  const MyCardComp({
    Key? key,
    required this.textButton,
    this.height = 150,
    this.width = 200,
    this.color = const Color.fromARGB(255, 224, 224, 224),
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      height: height,
      width: width,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20),
        color: color,
      ),
      child: Center(child: textButton),
    );
  }
}
