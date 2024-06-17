import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/modules/secretaria/secretaria_model.dart';
import 'package:front/app/service/service.dart';

class InstituicaoServiceImpl extends IService {
  InstituicaoServiceImpl()
      : super(
            path: 'instituicao',
            mainConstructor: InstituicaoModel.new,
            inner: {'secretaria': SecretariaModel.new});
}
