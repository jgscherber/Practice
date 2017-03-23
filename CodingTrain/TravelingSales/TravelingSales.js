var cities = [];
var totalCities = 7;

var recordDistance;
var bestPath;

function setup() {
  createCanvas(400,300);
  for(var i = 0; i < totalCities ; i++) {
    var buffer = 16;
    cities[i] = createVector(random(buffer,width-buffer),
                              random(buffer,height-buffer));
  }  
  
  recordDistance = calcDistance(cities);
  bestPath = cities.slice(); // makes a shallow copy
  console.log(recordDistance);
} // end setup()

function draw() {
  background(0);
  
  drawPath(cities, 255, 255, 255);
  drawPath(bestPath, 255, 0, 255);  
  
  var i = floor(random(cities.length));
  var j = floor(random(cities.length));
  swap(cities, i, j);
  
  var d = calcDistance(cities);
  
  if(d < recordDistance) {
    recordDistance = d;
    bestPath = cities.slice();
    console.log(recordDistance);
  }
} // end draw()

function swap(a, i, j) {
  var temp = a[i];
  a[i] = a[j];
  a[j] = temp;
  
} // end swap()

function calcDistance(points) { // return total distance of between points, in-order
  var sum = 0;
  for(var i = 0; i < points.length-1; i++) {
    var d = dist(points[i].x, points[i].y, points[i+1].x, points[i+1].y);
    sum += d;
  }
  return sum;
} // end calcDistance()

function drawPath(cities, r, g, b) {
  
  fill(r, g, b);  
  for(var i = 0; i < totalCities ; i++) {
    var rad = 8;
    ellipse(cities[i].x, cities[i].y, rad, rad);
  }
  
  stroke(r, g, b);
  strokeWeight(2);
  noFill();
  beginShape();
  for(var i = 0; i < totalCities ; i++) {
    vertex(cities[i].x, cities[i].y);
  }
  endShape();
}