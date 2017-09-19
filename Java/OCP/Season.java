
public enum Season {
    WINTER(10), SUMMER(20), FALL(30), SPRING(40);
    private int newOrdinal;
    private Season(int newOrdinal) {
      this.newOrdinal = newOrdinal;
    }
    public int getOrdinal() { return newOrdinal;}
      public static void main(String... args) {
    for(Season season : Season.values()) {
      System.out.println(season.name() + " " + season.getOrdinal());
    }
  }
}//end enunClass
