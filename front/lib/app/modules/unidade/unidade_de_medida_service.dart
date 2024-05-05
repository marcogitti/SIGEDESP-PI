import 'package:front/app/modules/unidade/unidade_de_medida_model.dart';
import 'package:front/app/service/service.dart';

class UnidadeMedidaServiceImpl extends IService {
  UnidadeMedidaServiceImpl()
      : super(
            path: 'unidade/medida', mainConstructor: UnidadeDeMedidaModel.new);
}
