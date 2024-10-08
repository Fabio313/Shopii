import 'package:flutter/material.dart';

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
            )
          ],
        ),
      ),
      body: const Center(child: Text('Bem-vindo ao Sistema de Produtos!')),
    );
  }
}
