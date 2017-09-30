
public class Ball {
  
  private PVector velocity = new PVector(10,7);
  private PVector location = new PVector(width / 2, height/2);
  
  private float r = 10;   
  
  public void display() {
    fill(0);
   ellipse(location.x,location.y,r,r); 
  }
  
  public void move(){
   //location.x += velocity.x;
   //location.y += velocity.y;
   
   // can also add vectors direction (element wise)
   location.add(velocity);
   
}
  public void bounce(){
   if(location.x < r || location.x > (width - r)) velocity.x *= -1;
   if(location.y < r || location.y > (height - r)) velocity.y *= -1;
}

  
}