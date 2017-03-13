var xspeed = 10;

function Ship() {
  this.x = width/2 - 10;
  
  this.show = function() {
    fill(255);
    rect(this.x, height-20, 20, 20);
  }
  
  this.left = function() {
    this.x = this.x + xspeed;
  }
  
  this.right = function() {
    this.x = this.x - xspeed;
  }
  
}