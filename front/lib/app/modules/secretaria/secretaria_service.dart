import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/modules/secretaria/secretaria_model.dart';
import 'package:front/app/service/service.dart';
import 'package:result_dart/result_dart.dart';

class SecretariaServiceImpl extends IService {
  SecretariaServiceImpl()
      : super(path: 'secretaria', mainConstructor: SecretariaModel.new);
}

void main() async {
  final secretariaService = Modular.get<SecretariaServiceImpl>();

  await secretariaService
      .deleteData(1)
      .fold((success) {}, (error) => print(error));

  final resp = await secretariaService.getAll();

  resp.fold((success) => null, (failure) => null);
}
