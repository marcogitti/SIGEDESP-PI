import 'package:front/app/modules/login/usuario_model.dart';
import 'package:front/app/service/service.dart';

class UsuarioServiceImpl extends IService<UsuarioModel> {
  UsuarioServiceImpl()
      : super(
          path: 'usuario',
          fromMap: UsuarioModel.fromMap,
          toJson: UsuarioModel.toJson,
        );
}
