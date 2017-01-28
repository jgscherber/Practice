class Planet {

  float radius;
  float angle;
  float distance;
  Planet[] planets;
  float orbitSpeed;
  PVector v;
  PVector v2;
  Planet(float r, float d) {
    radius = r;
    v = PVector.random3D();
    distance = d;
    v.mult(distance);
    angle = random(TWO_PI);
    orbitSpeed = distance/6000;
    v2 = new PVector(random(1,2),random(1,2),random(1,2));
  }

  void spawnMoons(int total, int level) {

    if (level<3) {
      planets = new Planet[total];
      for (int i = 0; i< planets.length; i++) {
        
        float r = radius*0.5;
        float d = random(75, 300)/(level+1);
        
        planets[i] = new Planet(r, d);
        planets[i].spawnMoons(1, level+1);
      }//next i
    }
  }//end spawnMoons

  void orbit() {
    angle = angle + orbitSpeed;
  }

  void show() {
    
    pushMatrix(); // save all variable states
    noStroke();
    fill(255);
    
    PVector p = v.cross(v2);
    rotate(angle, p.x,p.y,p.z);
    translate(v.x,v.y,v.z);    
    fill(255, 100);
    //ellipse(0, 0, radius*2, radius*2); 
    sphere(radius);
    if (planets != null) { // if planet has moons
      for (int i = 0; i < planets.length; i++) {
        planets[i].show();
        planets[i].orbit();
      }
    }

    popMatrix(); // reverts all variables back
    //translate(-distance,0);
  }
}