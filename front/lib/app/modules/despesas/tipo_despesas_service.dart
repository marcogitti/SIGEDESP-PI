import 'package:front/app/modules/despesas/tipo_despesas_model.dart';
import 'package:front/app/service/service.dart';

class TipoDeDespesasServiceImpl extends IService {
  TipoDeDespesasServiceImpl()
      : super(path: 'tipo/despesa', mainConstructor: TipoDespesasModel.new);
}
