import 'package:front/app/modules/Instituicao/tipo_instituicao_model.dart';
import 'package:front/app/service/service.dart';

class TipoInstituicaoServiceImpl extends IService {
  TipoInstituicaoServiceImpl()
      : super(
            path: 'tipo/instituica', mainConstructor: TipoInstituicaoModel.new);
}
