"""
Starting in the top left corner of a 2x2 grid, and only being able to move to
the right and down, there are exactly 6 routes to the bottom right corner.


How many such routes are there through a 20x20 grid?
"""

# only can move right or down

# how to represent edge graph
# 1. dict of nodes with key being current and value being list of connections

#Example code for finding all paths:

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

# need an easy way to generate graph structure.. will only go columns greater
# than itself, and rows greater than itself or equal (to the right)
graph_2x2 = {
    1:[2,4],
    2:[3,5],
    3:[6],
    4:[5,7],
    5:[6,8],
    6:[9],
    7:[8],
    8:[9]
    }
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

# each element goes to the next column and next row as long as either are <=20
graph_20x20 = {"33":[]}
m = 1
n = 1

for m in range(1,21):
    graph_20x20[str(m)+'1'] = [str(m)+'2',str(m+1) + '1']
    graph_20x20[str(m)+'21'] = [str(m+1) + '21']
    graph_20x20['211'] = ['212']
    for n in range(2,21):
        graph_20x20[str(m)+str(n)] = [str(m)+str(n+1),str(m+1) + str(n)]
        graph_20x20['1'+str(n)] = ['1'+str(n+1),'2' + str(n)]
        graph_20x20['21'+str(n)] = ['21'+str(n+1)]
        
        

    
    
#print(graph_20x20)
print(len(find_all_paths(graph_20x20,"11","2121")))
