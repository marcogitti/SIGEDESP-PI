import 'package:front/app/modules/instituicao/tipo_instituicao_model.dart';
import 'package:front/app/service/service.dart';

class TipoInstituicaoServiceImpl extends IService {
  TipoInstituicaoServiceImpl()
      : super(
          path: 'tipo/instituicao',
          mainConstructor: (json) => TipoInstituicaoModel.fromMap(json),
        );
  static final instance = TipoInstituicaoServiceImpl();
}
