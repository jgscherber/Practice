
Segment tentacle;
int len = 30;


void setup() {
 size(600,400);
 
 Segment current = new Segment(300, 200, len, 0);
 for(int i = 0; i < 30 ; i ++) {
   
   Segment next = new Segment(current, len, 0); 
   current = next;
 }
 tentacle = current;
 
}

void draw() {
 background(51);
 Segment next = tentacle;
 next.follow(mouseX,mouseY);
 while(next.parent != null) {
   next.show();
   next.update();
   next.parent.follow(next);
   next = next.parent;
 }
}