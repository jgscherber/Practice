function make2DArray(cols, rows) {
    let arr = new Array(cols)
    for(let i=0;i<arr.length; i++) {
	arr[i] = new Array(rows);      
    }
    return arr;
}

let oldGrid;
let newGrid;

let cols;
let rows;
let resolution = 20;

function setup() {
    createCanvas(600,400);
    console.log('')
    
    cols = width / resolution;
    rows = height / resolution;
    
    oldGrid = make2DArray(cols,rows);
    newGrid = make2DArray(cols,rows);
       
    // setup initial values
    for(let i=0; i<cols;i++) {
	for (let j =0; j<rows;j++){
	    oldGrid[i][j] = floor(random(2));
	}
    }

    // display old grid once
    for(let i=0; i<cols;i++) {
	for (let j =0; j<rows;j++){

	    let x = i * resolution;
	    let y = j * resolution;
	    if(oldGrid[i][j] == 1 ) {
		fill(255);
		stroke(255);
    		rect(x,y,resolution,resolution);
	    }

	}
    }
    
    
} // end setup

function draw() {
    frameRate(10);
    background(255);

    let i;
    let j;
    
    // update non-edge values into new grid
    for(i=0; i<cols;i++) {
	for (j =0; j<rows;j++){
	    let sum = 0;
	    for(let c = -1; c < 2; c++) {
		for(let r=-1; r < 2; r++) {
		    if(c == 0 || r == 0) continue;
		    let i2 = i;
		    let j2 = j;
		    if(i+c < 0) i2 = cols;
		    if(j+r < 0) j2 = rows;
		    if(i+c >= cols) i2 = -1;
		    if(j+r >= rows) j2 = -1;

		    sum += oldGrid[i2+c][j2+r];

		}
	    } //end sum
	    //console.log("" + i + " " + j + " " + sum);
	    switch(sum) {
	    case 2:
		newGrid[i][j] = oldGrid[i][j];
		break;
	    case 3:
		newGrid[i][j] = 1;
		break;
	    default:
		newGrid[i][j] = 0;
	    }
	}
    }



    // display new grid
    for(let i=0; i<cols;i++) {
	for (let j =0; j<rows;j++){

	    let x = i * resolution;
	    let y = j * resolution;
	    if(newGrid[i][j] == 1 ) {
		fill(0);
		stroke(0);
    		rect(x,y,resolution,resolution);
	    }

	}
    }

    // new grid becomes old grid
    oldGrid = newGrid
  
} // end draw
