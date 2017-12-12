function Node(val) {
  this.value = val; // value at the node
  this.left = null;
  this.right = null;
  
  // methods defined within the function get recreated with each instance
}

Node.prototype.visit = function() {
  if(this.left != null) { this.left.visit(); }
  console.log(this.value);
  if(this.right != null) { this. right.visit(); }
}

Node.prototype.find = function(val) {
  var temp = null;
  if( this.value == val) { temp = this; }
  // searches only in the direction needed
  else if(val < this.value && this.left != null) { this.left.find(val); }
  else if(val > this.value && this.right != null) { this. right.find(val); }
  return temp;
}

Node.prototype.addNode = function(n) {
  if( n.value < this.value) { 
    if( this.left == null) {this.left = n; }
    else { this.left.addNode(n); } 
  } else {
    if( this.right == null) { this.right = n}
    else { this.right.addNode(n); }
  }
}