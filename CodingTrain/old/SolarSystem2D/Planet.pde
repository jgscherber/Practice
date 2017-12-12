class Planet {

  float radius;
  float angle;
  float distance;
  Planet[] planets;
  float orbitSpeed;

  Planet(float r, float d) {
    radius = r;
    distance = d;
    angle = random(TWO_PI);
    orbitSpeed = distance/6000;
  }

  void spawnMoons(int total, int level) {

    if (level<3) {
      planets = new Planet[total];
      for (int i = 0; i< planets.length; i++) {
        float r = radius*0.5;
        float d = random(75, 300)/(level+1);
        planets[i] = new Planet(r, d);
        planets[i].spawnMoons((int)random(1, 4), level+1);
      }//next i
    }
  }//end spawnMoons

  void orbit() {
    angle = angle + orbitSpeed;
  }

  void show() {
    pushMatrix(); // save all variable states
    rotate(angle);
    translate(distance, 0);    
    fill(255, 100);
    ellipse(0, 0, radius*2, radius*2);
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