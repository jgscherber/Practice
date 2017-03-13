class Drop {
 float x = width / 2;
 float y = 0;
 
 float yspeed = 10;
 
 Drop(float x, float yspeed) {
   this.x = x;
   this.yspeed = yspeed;
 }
 
 void fall() {
   y = y + yspeed;
   if(y > height) {
    y = 0;
    yspeed = random(1,5);     
   }
 }
 
 void show() {
   stroke(138, 43, 226);
   line(x, y, x, y+10);
   
 }
 
 
  
}