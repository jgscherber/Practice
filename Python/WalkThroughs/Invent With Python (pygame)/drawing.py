import pygame, sys
from pygame.locals import *

# INIT PYGAME
pygame.init()

# WINDOW
DISPLAYSURF = pygame.display.set_mode((500,400), 0, 32) #resolution, flags, depth
pygame.display.set_caption('Drawing') # title bar

# color constants (python enums are a seperate class)
# class Color(enum)
#   Red = 1, etc
BLACK = (  0,   0,   0)
WHITE = (255, 255, 255)
RED = (255,   0,   0)
GREEN = (  0, 255,   0)
BLUE = (  0,   0, 255)

# DRAW!
DISPLAYSURF.fill(WHITE)
pygame.draw.line(DISPLAYSURF, BLUE, (60, 60), (120, 60), 4)
pygame.draw.rect(DISPLAYSURF, RED, (200,150,100,50))

pixObj = pygame.PixelArray(DISPLAYSURF)
pixObj[480][380] = BLACK # can reference each pixel individually
# can also call line with same start and end points
del pixObj # cleanup (big array)



pygame.display.update()
# LOOP
while 1:
    for event in pygame.event.get(): # returns Eventlist
        if event.type == QUIT:
            pygame.quit()
            sys.exit()
    pygame.display.update()
