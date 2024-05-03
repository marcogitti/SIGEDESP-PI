import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:dson_adapter/dson_adapter.dart';
import 'package:result_dart/result_dart.dart';

class IService<T extends Object> {
  final String path;

  IService({required this.path});

  Future<Result<List<T>, String>> getById(int id, classModel) async {
    try {
      final response =
          await http.get(Uri.http('https://localhost:7274/api/$path'));

      if (response.statusCode == 200) {
        final decodedData = jsonDecode(response.body);
        final List<T> dataList = List<T>.from(
            decodedData.map((item) => const DSON().fromJson(item, classModel)));
        return Result<List<T>, String>.success(dataList);
      } else {
        return Result<List<T>, String>.failure(
            'Falha ao carregar dados da API');
      }
    } catch (e) {
      return Result<List<T>, String>.failure(
          'Erro ao processar requisição: $e');
    }
  }

  Future<Result<List<T>, String>> getAll(classModel) async {
    try {
      final response =
          await http.get(Uri.http('https://localhost:7274/api/$path'));

      if (response.statusCode == 200) {
        final decodedData = jsonDecode(response.body);
        final List<T> dataList = List<T>.from(
            decodedData.map((item) => const DSON().fromJson(item, classModel)));
        return Result<List<T>, String>.success(dataList);
      } else {
        return Result<List<T>, String>.failure(
            'Falha ao carregar dados da API');
      }
    } catch (e) {
      return Result<List<T>, String>.failure(
          'Erro ao processar requisição: $e');
    }
  }

  Future<Result<T, String>> postData(T data) async {
    try {
      final response = await http.post(
        Uri.http('https://localhost:7274/api/$path'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(data),
      );

      if (response.statusCode == 201) {
        return Result<T, String>.success(data);
      } else {
        return Result<T, String>.failure('Falha ao enviar dados para a API');
      }
    } catch (e) {
      return Result<T, String>.failure('Erro ao processar requisição: $e');
    }
  }

  Future<Result<T, String>> editData(int id, T data) async {
    try {
      final response = await http.put(
        Uri.http('https://localhost:7274/api/$path/$id'),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
        },
        body: jsonEncode(data),
      );

      if (response.statusCode == 200) {
        return Result<T, String>.success(data);
      } else {
        return Result<T, String>.failure('Falha ao editar dados na API');
      }
    } catch (e) {
      return Result<T, String>.failure('Erro ao processar requisição: $e');
    }
  }

  Future<Result<String, String>> deleteData(int id) async {
    try {
      final response =
          await http.delete(Uri.http('https://localhost:7274/api/$path/$id'));

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
