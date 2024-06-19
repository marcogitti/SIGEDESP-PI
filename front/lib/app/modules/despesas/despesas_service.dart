import 'package:front/app/modules/despesas/despesas_model.dart';
import 'package:front/app/service/service.dart';

class DespesasServiceImpl extends IService<DespesaModel> {
  DespesasServiceImpl()
      : super(
          path: 'despesa',
          toJson: DespesaModel.new,
          fromMap: DespesaModel.new,
        );
}
