import 'package:http/http.dart' as http;
import 'dart:convert';

Future<void> fetchDados() async {
  final response =
      await http.get(Uri.http('https://localhost:7274/api/TipoDespesa'));

  if (response.statusCode == 200) {
    return jsonDecode(response.body);
  } else {
    throw Exception('Falha ao carregar dados da API');
  }
}
