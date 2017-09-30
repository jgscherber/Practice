
float t = 0;

void setup() {
 size(600,800);
 //frameRate(10);
}

void draw() {
  background(0);
  fill(255);
  
  // seeded at initialization and then sampled through time/space
  float x = noise(t);
  x = map(x,0,1,0,width);
  ellipse(x,height/2,40,40);
  t = t + 0.01;
}