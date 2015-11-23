using SimplexNoise;
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

namespace NoiseTest
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


        public int Factor2
        {
            get { return (int)GetValue(Factor2Property); }
            set { SetValue(Factor2Property, value); }
        }

        // Using a DependencyProperty as the backing store for Factor2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Factor2Property =
            DependencyProperty.Register("Factor2", typeof(int), typeof(Controller), new PropertyMetadata(1));


        #endregion


        public Controller()
        {
            
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            DataContext = this;
            btnStartGenerator.Click += StartGenerator_Executed;
        }

        public void StartGenerator_Executed(object sender, RoutedEventArgs e)
        {
            byte[] oNewBytes = new byte[512];
            Random oRnd = new Random(Seed);
            oRnd.NextBytes(oNewBytes);
            Noise.perm = oNewBytes;
            int iHeigtInt = Height * Factor2;
            int iWidthInt = Width * Factor2;
            byte[] oBitData = new byte[iWidthInt * iHeigtInt  * 3];
            Viewer oView = new Viewer();
            oView.oImage.Height = Height;
            oView.oImage.Width = Width;
            oView.Show();

            for (int x = 0; x < iWidthInt; x++)
            {
                for (int y = 0; y < iHeigtInt; y++)
                {
                    byte cval = (byte)(Noise.Generate(x / 100f, y / 100f) * 128 + 128);
                    oBitData[(x * iWidthInt + y) * 3] = cval;
                    oBitData[(x * iWidthInt + y) * 3 + 1] = 0;
                    oBitData[(x * iWidthInt + y) * 3 + 2] = 0;
                }
            }
            //int stride = ((Width * 24 + 23) & ~23) / 8;
            BitmapSource oSrc = BitmapSource.Create(iWidthInt, iHeigtInt, 1, 1, PixelFormats.Rgb24, BitmapPalettes.Halftone256, oBitData, iWidthInt * 3);
            
            oView.oImage.Source = oSrc;

        }
    }
}
