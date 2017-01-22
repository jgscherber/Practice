// Stopped at 22 minutes

var cols = 5;
var rows = 5;
var grid = new Array(cols);
var openSet = []; // the nodes remaining to be evaluated
var closedSet = []; // discarded nodes
var start; // starting node
var end; // ending node
var w,h;

function Spot(i,j) {
    this.x = i;
    this.y = j;    
    this.f = 0; // actual distance to goal??
    this.g = 0; // distance traveled so far
    this.h = 0; // heuristic distance to goal
    
    this.show = function(col){
        fill(col);
        noStroke();
        rect(this.x*w,this.y*h,w-1,h-1); // (posX,posY,x,y)
    }
}// end spot


function setup() {
    createCanvas(400,400);
    console.log('A*')
    
    // scaling for positioning Spots
    w = width / cols;
    h = height / rows;
    
    // making 2D array
    for (var i = 0; i< cols; i++){
        grid[i] = new Array(rows);
        for (var j = 0; j<rows; j++){
            grid[i][j] = new Spot(i,j);
        } // end j
    } // end i
    console.log(grid);
    start = grid[0][0];
    end = grid[cols-1][rows-1];
    openSet.push(start); // openSet only initialized with the starting position
    
    
} // end setup

function draw() {
  
  background(0);
  if(openSet.length > 0){ // keep going
    
  
  } // end if
  else{ // no solution
  
  
  } //end else
  for (var i = 0; i< cols; i++){
       for (var j = 0; j<rows; j++){
           grid[i][j].show(color(255));
           
       } //end j
  }//end i
  
  for (var i =0; i < closedSet.length; i++) {
      closedSet[i].show(color(255,0,0)); // red      
  }//end closedSet
  for (var i =0; i < openSet.length; i++) {
      openSet[i].show(color(0,255,0));
  }// end openSet
  
  
  
} // end draw