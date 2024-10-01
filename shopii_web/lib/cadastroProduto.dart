import 'package:flutter/material.dart';
import 'package:http/http.dart'
    as http; // Certifique-se de importar a biblioteca http
import 'produto.dart'; // Certifique-se de importar corretamente a classe Produto

class CadastroProdutoPage extends StatefulWidget {
  @override
  _CadastroProdutoPageState createState() => _CadastroProdutoPageState();
}

class _CadastroProdutoPageState extends State<CadastroProdutoPage> {
  final _formKey = GlobalKey<FormState>();
  Produto produto = Produto("", "", 0);

  // Função para cadastrar o produto
  Future<void> cadastrarProduto() async {
    if (_formKey.currentState!.validate()) {
      _formKey.currentState!.save();

      try {
        // Fazendo a requisição POST para a API
        final response = await http.post(
          Uri.parse('https://localhost:7012/api/v1/product'),
          headers: {"Content-Type": "application/json"},
          body: produto
              .JsonSerialize(), // Serializando o objeto Produto para JSON
        );

        if (response.statusCode == 200) {
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(content: Text('Produto cadastrado com sucesso!')),
          );
          Navigator.pop(context);
        } else {
          throw Exception('Falha ao cadastrar produto');
        }
      } catch (e) {
        print(e);
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(content: Text('Erro ao cadastrar produto')),
        );
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Cadastro de Produto')),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: Column(
            children: [
              TextFormField(
                decoration: const InputDecoration(labelText: 'Nome'),
                onSaved: (value) => produto.name = value ?? '',
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Informe o nome';
                  }
                  return null;
                },
              ),
              TextFormField(
                decoration: const InputDecoration(labelText: 'Descrição'),
                onSaved: (value) => produto.description = value ?? '',
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Informe a descrição';
                  }
                  return null;
                },
              ),
              TextFormField(
                decoration: const InputDecoration(labelText: 'Preço'),
                keyboardType:
                    const TextInputType.numberWithOptions(decimal: true),
                onSaved: (value) =>
                    produto.price = double.tryParse(value ?? '0') ?? 0,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Informe o preço';
                  }
                  if (double.tryParse(value) == null) {
                    return 'Informe um valor numérico válido';
                  }
                  return null;
                },
              ),
              const SizedBox(height: 16),
              ElevatedButton(
                onPressed: cadastrarProduto,
                child: const Text('Cadastrar'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
