class Walker {
  int x = 0;
  int y = 0;
  int size = 0;
  int[] c = {122, 122, 122};
  boolean spec_random = false;
  private SpecRand specRand = new SpecRand();
  
  public Walker(int h, int w, int size, boolean spec_random) {
    this.y = h/2;
    this.x = w/2;
    this.size = size;
    this.spec_random = spec_random;
  }
  public void step() {
   float rand;
   if (spec_random) rand = specRand.getRandom(1);
   else rand = random(1);
   
   if(rand < 0.25 && x < (height - size)) x = x + size;
   else if (rand < 0.5 && x > size) x = x - size;
   else if (rand < 0.75 && y < (width - size)) y = y + size;
   else if (y > size) y = y - size;
   
   color_change(c);
   
  }
  
  public void render() {
    stroke(c[0],c[1],c[2]);
    fill(c[0],c[1],c[2]);
    rect(x,y,size,size);
  }

// idea: have the color pulled from an image
  private void color_change(int[] c) {
    float rand;
    // red
    if (spec_random) rand = specRand.getRandom(1);
     else rand = random(1);
    if(rand < 0.5 && c[0] < 255) c[0] = c[0] + size;
     else if (c[0] > size) c[0] = c[0] - size;
    // green
    if (spec_random) rand = specRand.getRandom(1);
   else rand = random(1);
    if(rand < 0.5 && c[1] < 255) c[1] = c[1] + size;
     else if (c[1] > size) c[1] = c[1] - size;
    // blue
    if (spec_random) rand = specRand.getRandom(1);
   else rand = random(1);
    if(rand < 0.5 && c[2] < 255) c[2] = c[2] + size;
     else if (c[2] > size) c[2] = c[2] - size;
  }

}