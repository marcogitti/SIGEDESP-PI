import 'package:flutter_modular/flutter_modular.dart';
import 'package:front/app/modules/home/home_page.dart';
import 'package:front/app/modules/Instituicao/tipo_instituicao_page.dart';
import 'package:front/app/modules/unidade/unidade_consumidora_page.dart';
import 'package:front/app/modules/unidade/unidade_de_medida_page.dart';
import '../modules/despesas/tipo_despesas_page.dart';
import '../modules/login/usuario_page.dart';

class AppModule extends Module {
//   @override
//   List<Bind<Object>> get binds => [];

  @override
  void routes(RouteManager r) {
    r.child('/', child: (_) => const HomePage());
    r.child('/institutionScreen', child: (_) => InstitutionScreen());
    r.child('/tipoDeDespesas', child: (_) => TipoDeDespesas());
    r.child('/tipoUnidadeDeMedida', child: (_) => UnidadeDeMedidaPage());
    r.child('/tipoUnidadeConsumidora', child: (_) => UnidadeConsumidoraPage());
    r.child('/usuarioPage', child: (_) => const UsuarioPage());
    super.routes(r);
  }
}
