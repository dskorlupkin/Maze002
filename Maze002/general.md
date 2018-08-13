# Maze Experiments 2.0

## Maze generation algorithm

Using «Growing Tree» algorithm.

1. At start we have an empty *list* and array of cells
2. Peek starting cell
3. Put starting cell to *list*
4. While *list* is not empty do:  
5. Pick cell from *list* (`selected_cell`)
6. Check if `selected_cell` has at least one "unvisited" neighbor. If no – remove cell from list and go back to step 5.
7. Pick "unvisited" `neighbor` cell and set passage from current cell to selected neighbor. 
8. Check do this `neighbor` has any "unvisited" neighbors, if yes add `neighbor` to *list*
9. Check if `selected_cell` has any "unvisited" neighbors, if no - remove `selected_cell` from list

Some notes on algorithm

- It doesn't matter how to pick starting cell
- There are variety of methods to pick cell at step 5. They will provide different resulting "texture" of maze
- unvisited cell will have no open passages

### Cell Structure

Basically cell should have following properties/fields

- id (int)
- array of possible passages (exits)

Each passage is considered to have such properties as

- target cell
- some indicators to show is passage opened or not
- some "direction" **(should not be present in *basic* structure)**  
  In first version of Maze app "ordered" array was used for passages. First item pointed to north, second to east and so on. But this works only for _"uniform"_ mazes.

So, at first lets provide following structure

#### `BasicCell` class

|Name|Type|Description|
|----|----|-----------|
|Id  | int |Id of cell|
|Passages|List<int>|possible passages|

`Passages` list contains just Id's of neighbor cells. If `Passages[i]>0` passage is opened. if its `<0` passage exists (is possible) but closed. Initially all cells have all passages &lt;0.
This way "visited" cell will have at least one passage >0

This solution has some special features:

- Id's of all cells should be greater than zero
- On opening cell_1's passage from cell_1 to cell_2 we have to open proper passage of cell_2

WorkAround (ToDo):  
Create separate structure for 'Passage' type, which should store ID's of end-point cells, Opened/Closed flag and so on.  
Store Passages in separate list.  
In 'Cell' structure's passages array store pointers to item of Passages list.

#### 'Advanced' cell type

`BasicCell` is enough for building (and solving) mazes.
But it's not possible to visualize such maze. (Actually, it may be possible, but visualizing of graphs/trees is a separate task)

So, lets add few properties for graphical representation of maze.

First of all, we will need some coordinates of cell.

---
Тут мне надоело писать на английском.

## Few words about visualization

There are few ways to draw maze.
First one is 'old-school classic'

    █████████  
    █ █     █  
    █ █ ███ █
    █   █   █ 
    █ ███ ███
    █   █   █ 
    ███ ███ █
    █   █   █ 
    █████████

Walls only

    ╔═══╦═══╦═══╗       ╔═══╦═══╦═══╗
    ║ 1 ║ 2 ║ 3 ║       ║ 1 ║ 2   3 ║
    ╠═══╬═══╬═══╣       ╠   ╬═══╬   ╣
    ║ 4 ║ 5 ║ 6 ║       ║ 4   5 ║ 6 ║
    ╠═══╬═══╬═══╣       ╠═══╬   ╬   ╣
    ║ 7 ║ 8 ║ 9 ║       ║ 7   8   9 ║
    ╚═══╩═══╩═══╝       ╚═══╩═══╩═══╝

Passages only

    1┄┄2┄┄3    1┄┄2──3    ▫┄┄▫┄┄▫
    ┊  ┊  ┊    │  ┊  │    ┊  ┊  ┊
    4┄┄5┄┄6    4──5┄┄6    ▫┄┄▫┄┄▫
    ┊  ┊  ┊    ┊  │  │    ┊  ┊  ┊
    7┄┄8┄┄9    7──8──9    ▫┄┄▫┄┄▫



### Grid Steps

#### Rectangular Grid step

By default using 1.

#### Hex Grid Steps

Horizontal-straight grids:

    ⬡⬡⬡  
     ⬡⬡⬡