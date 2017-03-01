var s; // global
var scl = 20; // scale
var food;



function setup() {
  createCanvas(600, 600);
  s = new Snake();
  frameRate(10);
  food = createVector(0,0);
  pickLocation();
  //food = createVector(random(width),random(height)); // easily store x and y
  
}

function pickLocation() {
  var cols = floor(width/scl);
  var rows = floor(height/scl);
  
  food.x = floor(random(cols));
  food.y = floor(random(rows));
  food.mult(scl);
  
}

function draw() {
  background(51);
  s.update();
  s.show();
  
  if(s.eat(food)) {
    
    pickLocation();
  }
  
  fill(255, 0, 100);
  rect(food.x, food.y, scl, scl);
  
}

function keyPressed() { // built-in key listener
  if(keyCode === UP_ARROW) {
    s.dir(0,-1) // x, y (zero is the top of the screen
  }
  else if(keyCode === DOWN_ARROW) {
    s.dir(0,1) // x, y
  }
  else if(keyCode === LEFT_ARROW) {
    s.dir(-1,0) // x, y
  }
  else if(keyCode === RIGHT_ARROW) {
    s.dir(1,0) // x, y
  }
  
  
}