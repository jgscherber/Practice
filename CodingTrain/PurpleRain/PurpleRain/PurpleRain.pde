// Colors
// (138, 43, 226)
// (230, 230, 250)


Drop[] drops = new Drop[100];

void setup() {
  size(640, 360);
  for(int i = 0; i < drops.length ; i++) {
    drops[i] = new Drop(random(width), random(1,5));
  }
}

void draw() {
  background(230, 230, 250);
  for(int i = 0; i < drops.length ; i++) {
    drops[i].fall();
    drops[i].show();
  }
  
}