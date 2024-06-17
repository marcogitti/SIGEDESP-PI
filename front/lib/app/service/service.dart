import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:dson_adapter/dson_adapter.dart';
import 'package:result_dart/result_dart.dart';

class IService<T extends Object> {
  final String path;
  final Function mainConstructor;
  final Map<String, dynamic> inner;

  IService(
      {required this.path,
      required this.mainConstructor,
      this.inner = const {}});

  Future<Result<T, String>> getById(int id, classModel) async {
    try {
      final response = await http.get(Uri.http('localhost:5052', '/api/$path'));

      if (response.statusCode == 200) {
        return (const DSON()
                .fromJson(response.body, mainConstructor, inner: inner))
            .toSuccess();
      } else {
        return 'Falha ao carregar dados da API'.toFailure();
      }
    } catch (e) {
      return 'Erro ao processar requisição: $e'.toFailure();
    }
  }

  Future<Result<List<T>, String>> getAll() async {
    try {
      final response = await http.get(Uri.http('localhost:5052', '/api/$path'));
      await Future.delayed(const Duration(seconds: 1));
      if (response.statusCode == 200) {
        final decodedData = jsonDecode(response.body) as List;
        final dataList = decodedData
            .map((e) => const DSON().fromJson(e, mainConstructor, inner: inner))
            .toList()
            .cast<T>();
        return dataList.toSuccess();
      } else {
        return 'Falha ao carregar dados da API'.toFailure();
      }
    } catch (e) {
      return 'Erro ao processar requisição: $e'.toFailure();
    }
  }

  Future<Result<T, String>> postData(T data) async {
    try {
      final response = await http.post(
        Uri.http('localhost:5052', '/api/$path'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: data,
      );

      if (response.statusCode == 200 || response.statusCode == 201) {
        return data.toSuccess();
      } else {
        return 'Falha ao enviar dados para a API'.toFailure();
      }
    } catch (e) {
      return 'Erro ao processar requisição: $e'.toFailure();
    }
  }

  Future<Result<T, String>> editData(T data) async {
    try {
      final response = await http.put(
        Uri.http('localhost:5052', '/api/$path'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: data,
      );

      if (response.statusCode == 200) {
        return data.toSuccess();
      } else {
        return 'Falha ao editar dados na API'.toFailure();
      }
    } catch (e) {
      return 'Erro ao processar requisição: $e'.toFailure();
    }
  }

  Future<Result<String, String>> deleteData(int id) async {
    try {
      final response =
          await http.delete(Uri.http('localhost:5052', '/api/$path/$id'));

      if (response.statusCode == 200) {
        return 'apagado com sucesso'.toSuccess();
      } else {
        return 'Falha ao excluir dados na API'.toFailure();
      }
    } catch (e) {
      return 'Erro ao processar requisição: $e'.toFailure();
    }
  }
}
