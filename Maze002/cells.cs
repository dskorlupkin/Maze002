using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mazes
{
    public class BasicCell
    {
        int id;
        
        //TODO check value should be grater than zero
        public int ID { get { return id; }  set { id = value; } }
        public List<Passage> Passages { get; set; }

        public BasicCell(int id) { this.id = id; Passages = new List<Passage>(); }
    }

    public class Passage
    {
        BasicCell cell1;
        BasicCell cell2;

        public bool IsOpen { get; set; }
        public BasicCell Cell1 { get { return cell1; } set { cell1 = value; } }
        public BasicCell Cell2 { get { return cell2; } set { cell2 = value; } }
    }
    public class Cell : BasicCell
    {
        public Point Position { get; set; }

        public Cell(int id): base(id) { }
    }
}
