import 'package:front/app/modules/login/tipo_usuario_model.dart';
import 'package:front/app/service/service.dart';

class TipoUsuarioServiceImpl extends IService {
  TipoUsuarioServiceImpl()
      : super(path: 'tipo/usuario', mainConstructor: TipoUsuarioModel.new);
}
