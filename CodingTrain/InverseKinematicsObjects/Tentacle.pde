class Tentacle {
  
  float len;
  int pieces;
  Segment[] segments;
  
  PVector base;
  
  Tentacle(float x, float y, float len_) {
     len = len_ / 10;
     pieces = 10;
     segments = new Segment[pieces];
     segments[0] = new Segment(x, y, len, 0);
     for(int i = 1; i < pieces ; i ++) { 
       len *= 0.95;
       segments[i] = new Segment(segments[i-1], len, 0); 
     }
     base = new PVector(x, y);
    
  }
  
  void update() {
     Segment end = segments[pieces-1];
     end.follow(mouseX,mouseY);
     end.update();
     
     for(int i = pieces - 2; i > -1; i--) {   
       segments[i].update();
       segments[i].follow(segments[i+1]);
       
     }
     
     segments[0].setA(base);
     for(int i = 1; i < pieces; i++) {
      segments[i].setA(segments[i-1].b); 
     }        
  } // end update() 
  
  
  void show(int r, int g, int b, int w) {
     for(Segment s : segments) {
       s.show(r, g, b, w);
     }    
  }
  
} // end class