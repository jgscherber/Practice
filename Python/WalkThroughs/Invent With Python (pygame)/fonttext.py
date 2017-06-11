
import pygame, sys
from pygame.locals import *

pygame.init()
MAIN = pygame.display.set_mode((400,300))

WHITE = (255, 255, 255)
GREEN = (0,255,0)
BLUE = (0,0,128)

fontObj = pygame.font.SysFont('arial', 32)
MAIN.fill(WHITE)
surfObj = fontObj.render(str(0),True,GREEN,BLUE)
textRect = surfObj.get_rect() # bounding rectangle?
textRect.center = (200,150)

CLOCK = pygame.time.Clock();
count = 0
total = 0
FPS = 30
while 1:
    count += 1
    if count == FPS:
        count = 0
        total += 1
        MAIN.fill(WHITE)
        surfObj = fontObj.render(str(total), True, GREEN, BLUE)
        textRect = surfObj.get_rect()  # bounding rectangle?
        textRect.center = (200, 150)
    MAIN.blit(surfObj, textRect)
    for event in pygame.event.get():
        if event.type == QUIT:
            pygame.quit()
            sys.exit()
    pygame.display.update()
    CLOCK.tick(FPS)