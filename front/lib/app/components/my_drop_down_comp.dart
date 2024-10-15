import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';

class MyDropDownGetComp<T extends Object, TC extends Object>
    extends StatefulWidget {
  final String labelText;
  final T? initValue;
  final void Function(T?)? onChanged;

  const MyDropDownGetComp({
    super.key,
    this.initValue,
    this.onChanged,
    required this.labelText,
  });

  @override
  State<MyDropDownGetComp> createState() => _MyDropDownCompState<T, TC>();
}

class _MyDropDownCompState<T extends Object, TC extends Object>
    extends State<MyDropDownGetComp<T, TC>> {
  bool isLoad = true;
  T? selectedValue;
  List<T> itens = [];

  @override
  void initState() {
    selectedValue = widget.initValue;
    (Modular.get<TC>() as dynamic).getAll().then((value) {
      setState(() {
        itens = value.getOrThrow() as List<T>;
        isLoad = false;
      });
    });
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    if (isLoad) {
      return const CircularProgressIndicator();
    }
    return DropdownButtonFormField<T?>(
      borderRadius: BorderRadius.circular(10),
      elevation: 10,
      decoration: InputDecoration(
        labelText: widget.labelText,
      ),
      value: selectedValue,
      items: itens
          .map((value) {
            if (((value as dynamic)?.toMap() as Map<String, dynamic>)
                .containsKey('nome')) {
              return DropdownMenuItem<T>(
                value: value,
                child: Text((value as dynamic).nome ?? ''),
              );
            }

            return DropdownMenuItem<T>(
              value: value,
              child: Text((value as dynamic).descricao ?? ''),
            );
          })
          .toList()
          .cast<DropdownMenuItem<T>>(),
      onChanged: (T? newValue) {
        if (widget.onChanged != null) {
          widget.onChanged!(newValue);
        }
        setState(() {
          selectedValue = newValue;
        });
      },
    );
  }
}

//--------

class MyDropDownComp<T extends Object> extends StatelessWidget {
  final String labelText;
  final T? initValue;
  final List<T> itens;
  final void Function(T?)? onChanged;

  const MyDropDownComp({
    super.key,
    this.initValue,
    this.onChanged,
    required this.labelText,
    required this.itens,
  });

  @override
  Widget build(BuildContext context) {
    return DropdownButtonFormField<T>(
      borderRadius: BorderRadius.circular(10),
      elevation: 10,
      decoration: InputDecoration(
        labelText: labelText,
      ),
      value: initValue,
      items: itens
          .map((T value) {
            return DropdownMenuItem<T>(
              value: value,
              child: Text((value as dynamic)?.nome),
            );
          })
          .toList()
          .cast<DropdownMenuItem<T>>(),
      onChanged: onChanged,
    );
  }
}
