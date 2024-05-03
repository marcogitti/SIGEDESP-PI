import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/secretaria/secretaria_model.dart';
import 'package:front/app/service/service.dart';
import 'package:result_dart/result_dart.dart';

class SecretariaServiceImpl extends IService {
  SecretariaServiceImpl() : super(path: 'secretaria');
}

void main() async {
  final secretariaService = Modular.get<SecretariaServiceImpl>();

  await secretariaService
      .deleteData(1)
      .fold((success) {}, (error) => print(error));

  final resp = await secretariaService.getAll(SecretariaModel.new);

  resp.fold((success) => null, (failure) => null);
}
