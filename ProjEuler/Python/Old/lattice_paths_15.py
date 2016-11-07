"""
Starting in the top left corner of a 2x2 grid, and only being able to move to
the right and down, there are exactly 6 routes to the bottom right corner.


How many such routes are there through a 20x20 grid?
"""
import cProfile
import time

# only can move right or down

# Code for finding all paths:
def find_all_paths(graph, start, end, path=[]):
    # adds the starting location to the list
    path = path + [start]
    # catches non-moving paths and the base case for recursion
    if start == end:
        return [path]
    # if the start node had no exit points, return an empty path
    if not graph.has_key(start):
        return []
    # variable for storing all paths
    paths = []
    # for each exit path of the 1st node
    for node in graph[start]:
        # if the node hasn't yet been visited in the current path
        if node not in path:
            # use it as a new starting point for another path
            # will recusively add elements until the start and end are equal
            newpaths = find_all_paths(graph, node, end, path)
            for newpath in newpaths:
                paths.append(newpath)
    return paths

# another possible implimentation
gridSize = [20,20]
 
def recPath(gridSize):
    """
    Recursive solution to grid problem. Input is a list of x,y moves remaining.
    """
    # base case, no moves left
    if gridSize == [0,0]: return 1
    # recursive calls
    paths = 0
    # move left when possible
    if gridSize[0] > 0:
        paths += recPath([gridSize[0]-1,gridSize[1]])
    # move down when possible
    if gridSize[1] > 0:
        paths += recPath([gridSize[0],gridSize[1]-1])
 
    return paths
# takes over 4 hours to complete for 20x20 grid


# along left edge
# "11" -> "12" and "21"
# "21" -> "22" and "31"
#etc.

# along top edge
# "12" -> "13" and "22"
# "13" -> "14" and "23"
# etc.

# middle
# "22" -> "23" and "32"
# etc.
def make_grid(size):
    # each element goes to the next column and next row as long as either are <=20
    grid = size
    s_grid = str(grid)
    graph = {s_grid+s_grid:[]}


    # build relationship dictionary
    for m in range(1,grid):
        s_m = str(m)
        graph[s_m+'1'] = [s_m+'2',str(m+1) + '1']
        graph[s_m+s_grid] = [str(m+1) + s_grid]
        graph[s_grid+'1'] = [s_grid+'2']
        for n in range(2,grid):
            s_n = str(n)
            graph[s_m+s_n] = [s_m+str(n+1),str(m+1) + s_n]
            graph['1'+s_n] = ['1'+str(n+1),'2' + s_n]
            graph[s_grid+s_n] = [s_grid+str(n+1)]
        
# Recursion goes too deep, runs out of memory
# at 12x12 grid, calling  7 million times...
#print(cProfile.run('find_all_paths(make_grid(20),"11","2121")'))


"""_____Dynamic Solution_______

for n in the natural numbers and the sequence S(i,j)

       = 1 if j=0
S(i,j) = S(i,j-1)+ S(i-1,j) if 0<j<i
       = 2S(i,j-1) if i=j

0<=i<=n ; 0<=j<=i

Num_paths from top-left to bottom-right through n x n grid is S(n,n)
    -> Recursive functions S(n,n) = 2S(n,n-1) = 2(S(n,n-2) + S(n-1,n-1)) = ...
    -> Base: if j=0: return 1

Can be verified graphically (1's along edges, sum adjascent nodes)
"""

# runs very slow, still transversing all the path, (could be avoided by passing
# a cache (dict) that prevent re-calculation of branches that have already been
# calculated) just more efficiently than accessing list/dict indexes
def paths(i,j):
    if j==0: return 1
    if 0<j<i: return paths(i,j-1) + paths(i-1,j)
    if i==j: return 2*paths(i,j-1)

#cProfile.run('paths(20,20)')

# runs very fast! Only summing possible diagonals
def route_num(cube_size):
    # creates a list 20 entries long, all ones
    L = [1] * cube_size
    for i in range(cube_size):
        for j in range(i):
            # reassigns the jth item to the sum of itself and the previous entry
            L[j] = L[j]+L[j-1]
        # assigns the ith element to twice the previous element (summing two
        # symetrical entries on the previous diagonal)
        L[i] = 2*L[i-1]
    return L[cube_size - 1]
    

print(route_num(20))
# 137846528820

# Possible combinatorial solution:
"""
total = 1
for i in range(n):
    total *= (n+1)/i
"""








