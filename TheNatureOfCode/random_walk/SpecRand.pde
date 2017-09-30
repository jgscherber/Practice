
class SpecRand {

  // 0 heavy random by array
  float[] values = {0, 0, 0, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4};
  {
    for (int i = 0; i < values.length; i++) {
      values[i] = values[i] / 4;
    }
  }

  public float getRandomArray(int i) {
    int rand = (int)random(values.length);
    return values[rand]*i;
  }

  // x^2 distribution (more higher values
  public float getRandom(int i) {
    while (true) {
      float r1 = random(1);
      float r2 = random(2);
      float y = r1*r1; // y = x^2
      if (r2 < y) {
       return r1; 
      }
    }
  }
}