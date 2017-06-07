
import pygame, sys, os
from pygame.locals import *
# image download
from urllib.request import urlopen
from urllib.request import urlretrieve

pygame.init()

FPS = 30
fpsClock = pygame.time.Clock()

MAINSURF = pygame.display.set_mode((400,300),0,32)

WHITE = (255,255,255)

file_path = os.path.dirname(os.path.realpath(__file__))
catImg = pygame.image.load(file_path + r"\cat.png")
catX = 10
catY = 10

while 1:
    MAINSURF.fill(WHITE)
    catX += 5

    MAINSURF.blit(catImg, (catX, catY))

    for event in pygame.event.get():
        if event.type == QUIT:
            pygame.quit()
            sys.exit()

    pygame.display.update()
    fpsClock.tick(0.5)

