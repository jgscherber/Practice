// Stopped at 22 minutes

var cols = 25;
var rows = 25;
var grid = new Array(cols);
var openSet = []; // the nodes remaining to be evaluated
var closedSet = []; // discarded nodes
var start; // starting node
var end; // ending node
var w,h;
var path=[];

function removeFromArray(arr, elt) {
    for (var i = arr.length-1; i >=0; i--) {
        if (arr[i] == elt) {
            arr.splice(i,1)
        }//end if
    }//end for
}//end function

function heuristic(a,b){
    //var d = dist(a.i,a.j,b.i,b.j);
    var d = abs(a.i-b.i) + abs(a.j-b.j);
    
    return d;
}//end function


function Spot(i,j) {
    this.i = i;
    this.j = j;    
    this.f = 0; // f(n) := g(n) + h(n)
    this.g = 0; // distance traveled so far
    this.h = 0; // heuristic distance to goal
    this.neighbors = [];
    this.previous = undefined;
    
    this.show = function(col){
        fill(col);
        noStroke();
        rect(this.i*w,this.j*h,w-1,h-1); // (posX,posY,x,y)
    }
    
    this.addNeighbors = function(grid) {
        var i = this.i;
        var j = this.j;
        if(i < cols - 1) {
        this.neighbors.push(grid[i+1][j]);
        }
        if (i > 0) {
        this.neighbors.push(grid[i-1][j]);
        }
        if (j< rows - 1){
        this.neighbors.push(grid[i][j+1]);
        }
        if (j > 0) {
        this.neighbors.push(grid[i][j-1]);
        }
        
        
    }//end function
    
    
    
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
    
    for (var i = 0; i< cols; i++){
       for (var j = 0; j<rows; j++){
           grid[i][j].addNeighbors(grid);
       }
    }
    console.log(grid);
    start = grid[0][0];
    end = grid[cols-1][rows-1];
    openSet.push(start); // openSet only initialized with the starting position
    
    
} // end setup

function draw() {
  
  background(0);
  if(openSet.length > 0){ // keep going
    var winner = 0;
    for (var i = 0; i < openSet.length; i++) {
        if(openSet[i].f < openSet[winner].f) {winner = i;}        
    }//next i
    
    var current = openSet[winner];
    
    if (current == end) {
        // find the path
        var temp = current;
        path.push(temp);
        while(temp.previous) {
            path.push(temp.previous);
            temp = temp.previous;
        noLoop();
        console.log("Done");
        }// end if
    }
    removeFromArray(openSet, current);
    closedSet.push(current);
    
    var neighbors = current.neighbors;
    for(var i = 0; i < neighbors.length; i++){
        var neighbor = neighbors[i];
        if (!closedSet.includes(neighbor)) {
            var tempG = current.g + 1;
            
            if (openSet.includes(neighbor)) {
                if(tempG < neighbor.g) {
                    neighbor.g = tempG;
                }
            }
            else {
                neighbor.g = tempG;
                openSet.push(neighbor);
            }
            neighbor.h = heuristic(neighbor,end);
            neighbor.f = neighbor.g + neighbor.h;
            neighbor.previous = current;
        }
    }
    
    
  } // end if
  else{ // no solution
  
  
  } //end else
    path = [];
    var temp = current;
    path.push(temp);
        while(temp.previous) {
            path.push(temp.previous);
            temp = temp.previous;
        }
  for (var i = 0; i < cols; i++){      
    for (var j = 0; j < rows; j++){           
           grid[i][j].show(color(255));           
    } //end j
  }//end i
  
  for (var i =0; i < closedSet.length; i++) {
      closedSet[i].show(color(255,0,0)); // red      
  }//end closedSet
  for (var i =0; i < openSet.length; i++) {
      openSet[i].show(color(0,255,0));
  }// end openSet
  
  for (var i = 0; i < path.length; i++) {
      path[i].show(color(0,0,250));
  }
  
} // end draw