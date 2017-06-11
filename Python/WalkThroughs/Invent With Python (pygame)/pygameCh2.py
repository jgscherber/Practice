

import pygame, sys
from pygame.locals import *
pygame.init() # needs to be called first

# DISPLAYSURF is a member variable, used by update()
DISPLAYSURF = pygame.display.set_mode((400,300)) # FULLSCREEN flag
pygame.display.set_caption('Hello World')
while 1:
    for event in pygame.event.get():
        if event.type == QUIT:
            pygame.quit()
            sys.exit()
    pygame.display.update()
