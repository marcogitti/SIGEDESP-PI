import 'package:flutter/material.dart';
import 'package:front/app/modules/instituicao/tipo_instituicao_model.dart';
import 'package:front/app/modules/instituicao/tipo_instituicao_service.dart';
import 'package:result_dart/result_dart.dart';

class MyDropDowComp extends StatefulWidget {
  final TipoInstituicaoModel? initValue;
  final void Function(TipoInstituicaoModel?)? onChanged;

  const MyDropDowComp({super.key, this.initValue, this.onChanged});

  @override
  _MyDropDowCompState createState() => _MyDropDowCompState();
}

class _MyDropDowCompState extends State<MyDropDowComp> {
  late Future<Result<List<TipoInstituicaoModel>, String>>
      futureTipoInstituicoes;
  TipoInstituicaoModel? selectedValue;

  @override
  void initState() {
    super.initState();
    futureTipoInstituicoes = TipoInstituicaoServiceImpl.instance.getAll();
    selectedValue = widget.initValue;
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<Result<List<TipoInstituicaoModel>, String>>(
      future: futureTipoInstituicoes,
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
                items: tipoInstituicoes.map((TipoInstituicaoModel value) {
                  return DropdownMenuItem<TipoInstituicaoModel>(
                    value: value,
                    child: Text(value.descricao ?? ''),
                  );
                }).toList(),
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
