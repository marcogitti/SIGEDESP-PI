import 'package:front/app/modules/orcamento/orcamento_model.dart';
import 'package:front/app/service/service.dart';

class OrcamentoServiceImpl extends IService<OrcamentoModel> {
  OrcamentoServiceImpl()
      : super(
          path: 'orcamento',
          fromMap: OrcamentoModel.fromMap,
          toJson: OrcamentoModel.toJson,
        );
}
