import 'package:flutter/material.dart';

import 'package:shopii_web/cadastroProduto.dart';
import 'package:shopii_web/listarProdutos.dart';

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
      },
    );
  }
}

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Menu')),
      drawer: Drawer(
        child: ListView(
          children: [
            ListTile(
              title: Text('Consultar Produtos'),
              onTap: () {
                Navigator.pushNamed(context, '/produtos');
              },
            ),
            ListTile(
              title: Text('Cadastrar Produto'),
              onTap: () {
                Navigator.pushNamed(context, '/cadastro-produto');
              },
            ),
          ],
        ),
      ),
      body: Center(child: Text('Bem-vindo ao Sistema de Produtos!')),
    );
  }
}
