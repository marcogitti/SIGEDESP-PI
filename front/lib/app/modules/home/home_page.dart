import 'package:flutter/material.dart';
import 'package:front/app/components/Scaffold_comp.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  @override
  Widget build(BuildContext context) {
    return const ScaffoldComp(
      body: Text('data'),
    );
  }
}
