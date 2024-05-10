import 'package:front/app/modules/Instituicao/instituicao_model.dart';
import 'package:front/app/service/service.dart';

class InstituicaoServiceImpl extends IService {
  InstituicaoServiceImpl()
      : super(path: 'instituica', mainConstructor: InstituicaoModel.new);
}
