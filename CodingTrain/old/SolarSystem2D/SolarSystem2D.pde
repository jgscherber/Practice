
Planet sun;

void setup(){
  size(1000,1000);
  sun = new Planet(50,0);
  sun.spawnMoons(5, 0);
  
}//end setup


void draw(){
  background(0);
  translate(width/2, height/2);
  sun.show();
  
  
  
}//end draw