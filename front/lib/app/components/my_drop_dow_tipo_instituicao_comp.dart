import 'package:flutter/material.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/modules/instituicao/tipo_instituicao_model.dart';
import 'package:front/app/modules/instituicao/tipo_instituicao_service.dart';

class MyDropDowTipoInstituicaoComp extends StatefulWidget {
  final TipoInstituicaoModel? initValue;
  final void Function(TipoInstituicaoModel?)? onChanged;

  const MyDropDowTipoInstituicaoComp(
      {super.key, this.initValue, this.onChanged});

  @override
  _MyDropDowCompState createState() => _MyDropDowCompState();
}

class _MyDropDowCompState extends State<MyDropDowTipoInstituicaoComp> {
  TipoInstituicaoModel? selectedValue;

  @override
  void initState() {
    selectedValue = widget.initValue;
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
      future: Modular.get<TipoInstituicaoServiceImpl>().getAll(),
      builder: (context, snapshot) {
        if (snapshot.connectionState == ConnectionState.waiting) {
          return const CircularProgressIndicator();
        } else if (snapshot.hasError) {
          return Text('Error: ${snapshot.error}');
        } else if (snapshot.hasData) {
          final result = snapshot.data!;
          return result.fold(
            (tipoInstituicoes) {
              return DropdownButton<TipoInstituicaoModel>(
                borderRadius: BorderRadius.circular(10),
                elevation: 10,
                hint: const Text('Situação'),
                value: selectedValue,
                items: tipoInstituicoes
                    .map((value) {
                      return DropdownMenuItem<TipoInstituicaoModel>(
                        value: value as TipoInstituicaoModel,
                        child: Text(value.descricao ?? ''),
                      );
                    })
                    .toList()
                    .cast<DropdownMenuItem<TipoInstituicaoModel>>(),
                onChanged: (TipoInstituicaoModel? newValue) {
                  setState(() {
                    selectedValue = newValue;
                  });
                  if (widget.onChanged != null) {
                    widget.onChanged!(newValue);
                  }
                },
              );
            },
            (error) => Text('Error: $error'),
          );
        } else {
          return const Text('No data found');
        }
      },
    );
  }
}
