var data;
var graph;

function preload() {
 data = loadJSON('kevinbacon.json'); 
}

function setup() {
    noCanvas();
    graph = new Graph();
    
    var movies = data.movies;
    
    for(var i = 0; i < movies.length; i++) {
     var movie = movies[i].title;
     var cast = movies[i].cast;
     var n = new Node(movie);
     graph.addNode(n);
    }
    
} // end setup

//function draw() {
//  background(0);
  
//} // end draw