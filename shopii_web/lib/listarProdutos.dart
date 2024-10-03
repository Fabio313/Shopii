import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class ProdutoPage extends StatefulWidget {
  @override
  _ProdutoPageState createState() => _ProdutoPageState();
}

class _ProdutoPageState extends State<ProdutoPage> {
  List<dynamic> produtos = [];
  bool isLoading = true;

  @override
  void initState() {
    super.initState();
    fetchEquipamentos();
  }

  Future<void> fetchEquipamentos() async {
    try {
      final response =
          await http.get(Uri.parse('https://localhost:7012/api/v1/product'));

      if (response.statusCode == 200) {
        setState(() {
          produtos = jsonDecode(response.body)['products'];
          isLoading = false;
        });
      } else {
        throw Exception('Falha ao carregar equipamentos');
      }
    } catch (e) {
      setState(() {
        isLoading = false;
      });
      print(e);
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Equipamentos')),
      body: isLoading
          ? const Center(child: CircularProgressIndicator())
          : ListView.builder(
              itemCount: produtos.length,
              itemBuilder: (context, index) {
                final produto = produtos[index];
                return Container(
                  margin: const EdgeInsets.all(8.0), // Espaçamento externo
                  decoration: BoxDecoration(
                    border: Border.all(
                        color: Colors.blue, width: 2), // Borda personalizada
                    borderRadius:
                        BorderRadius.circular(10), // Borda arredondada
                    color: Colors.white, // Cor de fundo opcional
                  ),
                  child: ListTile(
                    title: Text(produto['name']),
                    subtitle: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(produto['description']),
                        Text(produto['price'].toString()),
                      ],
                    ),
                  ),
                );
              },
            ),
    );
  }
}
