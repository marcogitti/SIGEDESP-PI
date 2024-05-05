import 'package:front/app/modules/login/usuario_model.dart';
import 'package:front/app/service/service.dart';

class UsuarioServiceImpl extends IService {
  UsuarioServiceImpl()
      : super(path: 'usuario', mainConstructor: UsuarioModel.new);
}
