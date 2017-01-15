
PImage img;
PImage sorted;
int index = 0;

void setup() {
  size(400,400);
  img = loadImage("cat.jpg");
  //img.resize(200,200); // shrink image to speed computation time
  sorted = createImage(img.width,img.height, RGB);
  sorted.loadPixels();

  sorted = img.get(); //copies the img


 
}

void draw() {
  background(0);

    float record = -1;
    int selectedPixel = index;
    // find the next largest
    for (int j = index; j < sorted.pixels.length; j++) {
      color pix = sorted.pixels[j];
      float b = hue(pix);
      if (b > record) {
       selectedPixel = j;
       record = b;
      }
    }
    // swap selected pixel with i
    color temp = sorted.pixels[index];
    sorted.pixels[index] = sorted.pixels[selectedPixel];
    sorted.pixels[selectedPixel] = temp;   
    
    if( index < sorted.pixels.length-1) {
      index++;
    }
  sorted.updatePixels();
  //image(img,0,0);  
  image(sorted,0,0);
}