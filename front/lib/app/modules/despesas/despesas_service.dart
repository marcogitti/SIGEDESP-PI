import 'package:front/app/modules/despesas/despesas_model.dart';
import 'package:front/app/service/service.dart';

class DespesasServiceImpl extends IService {
  DespesasServiceImpl()
      : super(path: 'despesa', mainConstructor: DespesaModel.new);
}
