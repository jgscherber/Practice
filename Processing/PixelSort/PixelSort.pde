
PImage img;
PImage sorted;
PImage f_img;

void setup() {
  size(800,400);
  f_img = loadImage("cat.jpg");
  img = f_img.get();
  img.resize(150,150); // shrink image to speed computation time
  sorted = createImage(img.width,img.height, RGB);
  sorted.loadPixels();

  sorted = img.get(); //copies the img
  for (int i=0; i < sorted.pixels.length; i++) {
    float record = -1;
    int selectedPixel = i;
    // find the next largest
    for (int j = i; j < sorted.pixels.length; j++) {
      color pix = sorted.pixels[j];
      float b = hue(pix);
      if (b > record) {
       selectedPixel = j;
       record = b;
      }
    }
    // swap selected pixel with i
    color temp = sorted.pixels[i];
    sorted.pixels[i] = sorted.pixels[selectedPixel];
    sorted.pixels[selectedPixel] = temp;   
    
    
    
  }
  // resize again for clarity
  
  sorted.resize(400,400);  
}

void draw() {
  background(0);
  image(f_img,0,0);
  image(sorted,f_img.width,0);
}