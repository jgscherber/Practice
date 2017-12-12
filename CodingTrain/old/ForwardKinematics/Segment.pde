 //<>//
class Segment {
  
  PVector a; // start
  PVector b; // end calculated from a (r cos(), r sin() )
  
  Segment parent = null;
  Segment child = null;
  
  float len;
  float angle;
  float selfAngle;  
  
  float t; // = 0;//random(1000);
  
  Segment(float x, float y, float len_, float angle_, float t_) {
   a = new PVector(x,y);
   len = len_;
   angle = radians(angle_);
   selfAngle = angle;
   calculateB();   
   parent = null;
   t = t_;
  }
  
  Segment(Segment parent_, float len_, float angle_, float t_) {
   parent = parent_;
   a = parent.b.copy();
   
   len = len_;
   angle = radians(angle_);
   selfAngle = angle;
   calculateB();
   t = t_;
  }
  
  void wiggle() {
    float maxAngle = 0.6;
    
    selfAngle = map(noise(t),0,1,maxAngle,-maxAngle);
    t += 0.01;
    //selfAngle += 0.01;
  }
  
  void update() {
    angle = selfAngle;
    if(parent != null) {
     //a.x = parent.b.x;
     //a.y = parent.b.y;
     a = parent.b.copy();
     angle += parent.angle;
    } else {
      angle += -PI/2;
    }
    calculateB();
  }
  
  void calculateB() {
   float dx = len * cos(angle);
   float dy = len * sin(angle);
   
   b = new PVector(a.x + dx, a.y + dy);
   
  }
  
  void show() {
    stroke(255);
    strokeWeight(4);
    line(a.x,a.y,b.x,b.y);
  }
}