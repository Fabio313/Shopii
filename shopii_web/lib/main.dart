import 'package:flutter/material.dart';

import 'package:shopii_web/cadastroProduto.dart';
import 'package:shopii_web/listarProdutos.dart';
import 'package:shopii_web/loginUser.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: HomePage(),
      routes: {
        '/produtos': (context) => ProdutoPage(),
        '/cadastro-produto': (context) => CadastroProdutoPage(),
        '/login': (context) => LoginScreen()
      },
    );
  }
}

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Menu')),
      drawer: Drawer(
        child: ListView(
          children: [
            ListTile(
              title: const Text('Consultar Produtos'),
              onTap: () {
                Navigator.pushNamed(context, '/produtos');
              },
            ),
            ListTile(
              title: const Text('Cadastrar Produto'),
              onTap: () {
                Navigator.pushNamed(context, '/cadastro-produto');
              },
            ),
            ListTile(
              title: const Text('Login'),
              onTap: () {
                Navigator.pushNamed(context, '/login');
              },
            ),
          ],
        ),
      ),
      body: const Center(child: Text('Bem-vindo ao Sistema de Produtos!')),
    );
  }
}
