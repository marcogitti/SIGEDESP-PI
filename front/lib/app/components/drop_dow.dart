import 'package:flutter/material.dart';
import 'package:front/app/util/situacao_enum.dart';

class MyDropDowComp extends StatelessWidget {
  final SituacaoEnum? initValue;
  final void Function(SituacaoEnum?)? onChanged;

  const MyDropDowComp({super.key, this.initValue, this.onChanged});

  @override
  Widget build(BuildContext context) {
    return DropdownButton<SituacaoEnum>(
      borderRadius: BorderRadius.circular(10),
      elevation: 10,
      hint: const Text('Situação'),
      value: initValue,
      items: SituacaoEnum.values.map((SituacaoEnum value) {
        return DropdownMenuItem<SituacaoEnum>(
          value: value,
          child: Text(value.name),
        );
      }).toList(),
      onChanged: onChanged,
    );
  }
}
