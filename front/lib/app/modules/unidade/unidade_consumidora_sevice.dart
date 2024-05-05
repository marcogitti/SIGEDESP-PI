import 'package:front/app/modules/unidade/unidade_consumidora_model.dart';
import 'package:front/app/service/service.dart';

class UnidadeConsumidoraServiceImpl extends IService {
  UnidadeConsumidoraServiceImpl()
      : super(
            path: 'unidade/consumidora',
            mainConstructor: UnidadeConsumidoraModel.new);
}
