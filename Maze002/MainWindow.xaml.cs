using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Mazes;
using Maze002.ViewModels;
namespace Maze002
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public CellStyleVM cellStyle = new CellStyleVM() { HexFill = "Cyan", SimpleSize = 10 };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Maze maze = MazeMeshGenerator.GenerateRectMesh(5, 5, 50, 50);

            foreach (var item in maze.Cells)
            {
                Ellipse ell = new Ellipse() { Width = 10, Height = 10, Fill = new SolidColorBrush(Colors.Black) };
                //Canvas.SetLeft(ell, item.Position.X-5);
                //Canvas.SetTop(ell, item.Position.Y-5);
                //Canvas.Children.Add(ell);
                ell.Margin = new Thickness(item.Position.X, item.Position.Y, 0, 0);
                ell.VerticalAlignment = VerticalAlignment.Top;
                ell.HorizontalAlignment = HorizontalAlignment.Left;
                Grd.Children.Add(ell);
                //Grid.SetRow(ell, 0);
            }

            foreach (var item in maze.Passages)
            {
                Line ln = new Line();
                ln.X1 = (item.Cell1 as Cell).Position.X;
                ln.Y1 = (item.Cell1 as Cell).Position.Y;

                ln.X2 = (item.Cell2 as Cell).Position.X;
                ln.Y2 = (item.Cell2 as Cell).Position.Y;
                ln.Stroke = new SolidColorBrush(item.IsOpen ? Colors.Blue : Colors.Navy);
                ln.StrokeThickness = 3;
                Grd.Children.Add(ln);
                //Canvas.Children.Add(ln);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Visibility v = (Visibility)this.Resources["Visibility1"];
            v = v == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            this.Resources["Visibility1"] = v;
        }
    }
}
