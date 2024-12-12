import 'package:front/app/modules/login/usuario_model.dart';
import 'package:front/app/service/service.dart';

class UsuarioLoginServiceImpl extends IService<UsuarioModel> {
  UsuarioLoginServiceImpl()
      : super(
          path: 'usuario/login',
          fromMap: UsuarioModel.fromMap,
          toJson: UsuarioModel.toJsonLogin,
        );
}
