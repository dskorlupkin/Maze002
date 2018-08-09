using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazes
{
    public class Maze
    {
        public List<Cell> Cells { get; set; }
        public List<Passage> Passages { get; set; }

        public Maze()
        {
            Cells = new List<Cell>();
            Passages = new List<Passage>();
        }

        public void  LinkCells(int first, int second)
        {
            Passage pass = new Passage() { Cell1 = Cells[first], Cell2 = Cells[second], IsOpen = false };
            Passages.Add(pass);
            pass.Cell1.Passages.Add(pass);
            pass.Cell2.Passages.Add(pass);
        }
    }
}
