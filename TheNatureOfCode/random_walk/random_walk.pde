Walker w;

int size = 10;

void setup() {
  size(800,600);
  // create walker
  w = new Walker(height, width, size, true);
  background(255);
}

void draw() {
  // walk!
  w.step();
  w.render();
}  