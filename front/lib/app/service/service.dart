import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:dson_adapter/dson_adapter.dart';
import 'package:result_dart/result_dart.dart';

class IService<T> {
  final String path;
  final Function classModel;

  IService({required this.path, required this.classModel});

  AsyncResult<List<T>, String> getById(int id) async {
    final response =
        await http.get(Uri.http('https://localhost:7274/api/$path'));

    if (response.statusCode == 200) {
      return (DSON().fromJson(response.body, classModel)).toSuccess();
    } else {
      return 'Falha ao carregar dados da API'.toFailure();
    }
  }

  getAll() {}

  // Future Result<List<T>, String> getAll() async {
  //   final response =
  //       await http.get(Uri.http('https://localhost:7274/api/$path'));

    // if (true) {
    //   final List<Map> resp = [
    //     {"id": 0, "tipoDespesa": "string", "solicitaUC": "string"},
    //     {"id": 1, "tipoDespesa": "carro", "solicitaUC": "string"},
    //   ];
    //   return resp
    //       .map((e) => DSON().fromJson(e, classModel))
    //       .toList()
    //       .cast<T>()
    //       .toSuccess();
    // } else {
    //   return 'Falha ao carregar dados da API'.toFailure();
    // }
  }

  Future<T?> postDados(Map body) async {
    final response = await http
        .post(Uri.http('https://localhost:7274/api/$path'), body: body);

    if (response.statusCode == 200) {
      return jsonDecode(response.body);
    } else {
      throw Exception('Falha ao carregar dados da API');
    }
  }
}
