using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace Maze002.ViewModels
{
    public class CellStyleVM:ViewModelBase
    {
        double simpleSize;
        SolidColorBrush brush;

        public double SimpleSize { get => simpleSize; set => SetField(ref simpleSize, value); }
        public string HexFill { get => brush.Color.ToString(); set => SetField(ref brush, new SolidColorBrush((Color)ColorConverter.ConvertFromString(value))); }
    }
}
