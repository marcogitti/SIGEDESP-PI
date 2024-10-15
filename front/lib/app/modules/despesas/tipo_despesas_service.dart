import 'package:front/app/modules/despesas/tipo_despesas_model.dart';
import 'package:front/app/service/service.dart';

class TipoDespesasServiceImpl extends IService<TipoDespesasModel> {
  TipoDespesasServiceImpl()
      : super(
          path: 'tipo/despesa',
          fromMap: TipoDespesasModel.fromMap,
          toJson: TipoDespesasModel.toJson,
        );
}
