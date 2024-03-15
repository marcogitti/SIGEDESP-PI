import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/modules/home/home_page.dart';
import 'package:front/app/modules/tipoInstituicao/tipo_instituicao_page.dart';

import '../modules/despesas/cadastro_despesas_page.dart';
import '../modules/login/usuario_page.dart';

class AppModule extends Module {
  @override
  List<Bind<Object>> get binds => [];

  @override
  List<ModularRoute> get routes => [
        ChildRoute('/', child: (context, args) => const HomePage()),
        ChildRoute('/institutionScreen',
            child: (context, args) => InstitutionScreen()),
        ChildRoute('/cadastroDeDespesas',
            child: (context, args) => CadastroDeDespesas()),
        ChildRoute('/usuarioPage',
            child: (context, args) => const UsuarioPage()),
      ];
}
