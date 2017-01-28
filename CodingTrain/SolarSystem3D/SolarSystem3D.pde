import peasy.*;
import peasy.org.apache.commons.math.*;
import peasy.org.apache.commons.math.geometry.*;

// 5:57

Planet sun;
PeasyCam cam;

void setup(){
  size(1000,1000, P3D);
  cam = new PeasyCam(this, 500);
  sun = new Planet(50,0);
  sun.spawnMoons(5, 0);
  
}//end setup


void draw(){
  background(0);
  lights();
  sun.show();
  
  
  
}//end draw