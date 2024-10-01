import 'dart:convert';

class Produto {
  String name;
  String description;
  double price;

  Produto(this.name, this.description, this.price);

  String JsonSerialize() {
    return jsonEncode({
      'name': name,
      'description': description,
      'price': price,
    });
  }
}
