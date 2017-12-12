
Tentacle t;
ArrayList<Tentacle> tentacles;

void setup() {
 size(600,400);
 tentacles = new ArrayList<Tentacle>();
 for(float x = width/20; x < (width-width/20); x += random(20)) {
  tentacles.add(new Tentacle(x, height, 400)); 
 }
 
 for(float x = width/20; x < (width-width/20); x += random(20)) {
  tentacles.add(new Tentacle(x, 0, 400)); 
 }
 
}

void draw() {
 background(51);
 for(Tentacle t : tentacles) {
   t.update();
   t.show((int)random(255),(int)random(255),(int)random(255),(int)random(5));
 }
}