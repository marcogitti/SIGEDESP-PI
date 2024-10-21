import 'package:front/app/modules/secretaria/secretaria_model.dart';
import 'package:front/app/service/service.dart';

class SecretariaServiceImpl extends IService<SecretariaModel> {
  SecretariaServiceImpl()
      : super(
          path: 'secretaria',
          fromMap: SecretariaModel.fromMap,
          toJson: SecretariaModel.toJson,
        );
}

// void main() async {
//   final secretariaService = Modular.get<SecretariaServiceImpl>();

  // await secretariaService
  //     .deleteData(1)
  //     .fold((success) {}, (error) => print(error));

  // final resp = await secretariaService.getAll();

  // resp.fold((success) => null, (failure) => null);

