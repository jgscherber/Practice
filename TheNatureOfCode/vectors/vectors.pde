Ball b;

void setup() {
   size(400, 400);
   b = new Ball();
}

void draw() {
  background(255);
   b.display();
   b.move();
   b.bounce();
}