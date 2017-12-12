class Segment {
  
 PVector a;
 float angle;
 float len;
 
 Segment parent;
 PVector b = new PVector();
  
  Segment(float x, float y, float len_, float angle_) {
   a = new PVector(x,y);
   len = len_;
   angle = radians(angle_);
   calculateB();
  }
  
  Segment(Segment parent_, float len_, float angle_) {
   parent = parent_;
   a = parent.b.copy();
   len = len_;
   angle = radians(angle_);
   calculateB();
  }
  
  void calculateB() {
    float dx = len * cos(angle);
    float dy = len * sin(angle);
    b.set(a.x + dx, a.y + dy); // avoid repeated creation of new objects
                               // due to delay of garbage collection (... or lack of)
  }
  
  void follow(float tx, float ty) {
    PVector target = new PVector(tx,ty);
    PVector dir = PVector.sub(target, a);
    angle = dir.heading();
    
    dir.setMag(len);
    dir.mult(-1);
    a = PVector.add(target, dir);
  }  
  
  void follow(Segment seg) {
   follow(seg.a.x, seg.a.y); 
  }
  
  void update() {
    calculateB();
  }
  
  
  void show() {
    stroke(255);
    strokeWeight(4);
    line(a.x,a.y,b.x,b.y);
  }
  
  
}