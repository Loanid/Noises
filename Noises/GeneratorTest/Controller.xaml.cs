using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeneratorTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Controller : Window
    {
        #region Properties

        public int Width
        {
            get { return (int)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Width.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(int), typeof(Controller), new PropertyMetadata(500));


        public int Height
        {
            get { return (int)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Height.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(int), typeof(Controller), new PropertyMetadata(500));


        public int Seed
        {
            get { return (int)GetValue(SeedProperty); }
            set { SetValue(SeedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Seed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SeedProperty =
            DependencyProperty.Register("Seed", typeof(int), typeof(Controller), new PropertyMetadata(new Random().Next()));

        #endregion

        public static RoutedCommand StartGenerator = new RoutedCommand();

        public Controller()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            CommandBindings.Add(new CommandBinding(StartGenerator, StartGenerator_Executed));
            DataContext = this;
        }

        public static void StartGenerator_Executed(object sender ,RoutedEventArgs e)
        {

        }
    }
}
