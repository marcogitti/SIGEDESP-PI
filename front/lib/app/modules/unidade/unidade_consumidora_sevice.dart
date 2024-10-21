import 'package:front/app/modules/unidade/unidade_consumidora_model.dart';
import 'package:front/app/service/service.dart';

class UnidadeConsumidoraServiceImpl extends IService<UnidadeConsumidoraModel> {
  UnidadeConsumidoraServiceImpl()
      : super(
          path: 'unidade/consumidora',
          fromMap: UnidadeConsumidoraModel.fromMap,
          toJson: UnidadeConsumidoraModel.toJson,
        );
}
