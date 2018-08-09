using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes
{
    public static class MazeMeshGenerator
    {
        public static Maze GenerateRectMesh(int w, int h, int dx=1, int dy = 1)
        {
            //number of cells in maze
            int count = w * h;
            Maze maze = new Maze();
            //creating cells
            for (int i = 0; i < count; i++)
            {
                maze.Cells.Add(new Cell(i));
            }

            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    int idx = i * w + j;
                    /*if (j>0) //not a first row, link to top
                    {
                        int idx2 = idx - w;
                        maze.LinkCells(idx, idx2);
                    }*/
                    if(idx-w>=0) maze.LinkCells(idx, idx-w); //link up
                    if (j > 0) maze.LinkCells(idx, idx - 1); //link left
                    maze.Cells[idx].Position=new System.Windows.Point(j*dx,i*dy);
                }
            }
            return maze;
        }
    }
}
