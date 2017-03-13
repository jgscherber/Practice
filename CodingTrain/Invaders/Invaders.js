// 7:42

var ship;

function setup() {
    createCanvas(400,400);
    ship = new Ship();
    
} // end setup

function draw() {
  background(51);
  ship.show();
  
} // end draw

// 5 == "5" equal value
// 5 === "5" equal value and type

function keyPressed() {
 if(keyCode === RIGHT_ARROW) {
   ship.left();   
 } else if (keyCode = LEFT_ARROW) {
   ship.right(); 
 }
}