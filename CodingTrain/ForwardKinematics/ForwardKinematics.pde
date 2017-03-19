Segment tentacle;
int len = 20;

void setup() {
    size(600,400);
    float t = 0;
    tentacle = new Segment(width/2, height, len, 0, t);
    
    Segment current = tentacle; // as linked list 
    for(int i = 0; i < 20; i++) {
      t += 0.1;
      len -= 0.8;
      Segment next = new Segment(current, len, 0, t);
      current.child = next;
      current = next;
    }
} // end setup

void draw() {
  background(51);
  Segment current = tentacle;
  
  
  while(current != null) {
    current.wiggle();
    current.update();
    current.show();
    current = current.child;
  }
  
  
} // end draw