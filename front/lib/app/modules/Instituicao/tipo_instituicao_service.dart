import 'package:front/app/modules/instituicao/tipo_instituicao_model.dart';
import 'package:front/app/service/service.dart';

class TipoInstituicaoServiceImpl extends IService<TipoInstituicaoModel> {
  TipoInstituicaoServiceImpl()
      : super(
          path: 'tipo/instituicao',
          fromMap: TipoInstituicaoModel.fromMap,
          toJson: TipoInstituicaoModel.toJson,
        );
}
