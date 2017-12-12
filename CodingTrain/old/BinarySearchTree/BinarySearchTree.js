var tree; // js isnt hard typed

function setup() {
  noCanvas();
  tree = new Tree();
  for(var i = 0; i < 9; i++) {
    tree.addValue((int)(random()*10));
  }
  tree.traverse();
  tree.find(3);
  //console.log(tree);
} // end setup


//function draw() {
//  background(0);
  
//} // end draw