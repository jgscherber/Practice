

class Bobcat {
  public void findDen() {}
}

public class annotate extends Bobcat {
  /*
  @Override // error: method does not override of implement a method from a super type
  public void findDen(boolean b) {}
  */

  @Override // ok, self-catch that it was over-ridden
  public void findDen() {}
}
