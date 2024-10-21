import 'package:front/app/modules/instituicao/instituicao_model.dart';
import 'package:front/app/service/service.dart';

class InstituicaoServiceImpl extends IService<InstituicaoModel> {
  InstituicaoServiceImpl()
      : super(
          path: 'instituicao',
          fromMap: InstituicaoModel.fromMap,
          toJson: InstituicaoModel.toJson,
        );
}
