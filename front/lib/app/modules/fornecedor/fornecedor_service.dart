import 'package:front/app/modules/fornecedor/fornecedor_model.dart';
import 'package:front/app/service/service.dart';

class FornecedorServiceImpl extends IService<FornecedorModel> {
  FornecedorServiceImpl()
      : super(
          path: 'instituicao',
          fromMap: FornecedorModel.fromMap,
          toJson: FornecedorModel.toJson,
        );
}
