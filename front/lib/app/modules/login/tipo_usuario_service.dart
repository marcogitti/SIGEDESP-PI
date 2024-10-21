import 'package:front/app/modules/login/tipo_usuario_model.dart';
import 'package:front/app/service/service.dart';

class TipoUsuarioServiceImpl extends IService<TipoUsuarioModel> {
  TipoUsuarioServiceImpl()
      : super(
          path: 'tipo/usuario',
          fromMap: TipoUsuarioModel.new,
          toJson: TipoUsuarioModel.new,
        );
}
