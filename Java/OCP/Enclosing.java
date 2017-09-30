
public class Enclosing {
  static class Nested {
    private static int price = 6;
  }
  public static void main(String... args) {
    System.out.println(Nested.price);
  }
}
