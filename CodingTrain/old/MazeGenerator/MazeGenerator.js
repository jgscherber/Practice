// part 2 4:20

var cols, rows;
var w = 40;
var grid = [];

var current; //current cell

function setup() {
    createCanvas(400,400);
    console.log('')
    cols = floor(width/w);
    rows = floor(height/w);
    
    for (var i = 0;i< rows; i++){
      for (var j = 0; j<cols; j++){
        var cell = new Cell(i,j);    
        grid.push(cell);
      }//next j
    }//next i
    current = grid[0];
} // end setup

function draw() {
  current.visited = true;
  background(51);
  for (var i=0; i<grid.length; i++) {
    grid[i].show();
    
  }//next i
  
  
  
} // end draw

function Cell(i,j) {
  this.i = i;
  this.j = j;
  this.walls = [true,true,true,true] // top, right, bottom, left
  this.visited = false;
  this.show = function(){
    var x = this.i*w;
    var y = this.j*w;    
    stroke(255);
    if(this.walls[0]){line(x,y,x+w,y);} // top
    if(this.walls[1]){line(x+w,y,x+w,y+w);} // right
    if(this.walls[2]){line(x,y+w,x+w,y+w);} // bottom
    if(this.walls[3]){line(x,y,x,y+w);} // left
    if (this.visited) {
       fill(255,0,255,100);
       rect(x,y,w,w);
    }
  }//end show
  
  
}//end cell