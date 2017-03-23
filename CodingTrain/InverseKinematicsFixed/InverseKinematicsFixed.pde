

int len = 60;
int pieces = 10;
Segment[] tentacle = new Segment[pieces];

PVector base;

void setup() {
 size(600,400);
 
 tentacle[0] = new Segment(300, 200, len, 0);
 for(int i = 1; i < pieces ; i ++) { 
   len *= 0.9;
   tentacle[i] = new Segment(tentacle[i-1], len, 0); 
 }
 base = new PVector(width/2,height);
 
}

void draw() {
 background(51);
 Segment end = tentacle[pieces-1];
 end.follow(mouseX,mouseY);
 end.update();
 
 for(int i = pieces - 2; i > -1; i--) {   
   tentacle[i].update();
   tentacle[i].follow(tentacle[i+1]);
   
 }
 
 tentacle[0].setA(base);
 for(int i = 1; i < pieces; i++) {
  tentacle[i].setA(tentacle[i-1].b); 
 } 
 
 show(tentacle);
}

void show(Segment[] tentacle) {
 for(int i = 0; i < pieces; i++) {
   tentacle[i].show();
 }
  
}