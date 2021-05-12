using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MoneyChecker
{
    class TabViewControl
    {
        private KeyValuePair<ToggleButton, Page> _tab;
        public TabViewControl(ToggleButton toggleButton, Page page)
        {
            _tab = new KeyValuePair<ToggleButton, Page>(toggleButton, page);
        }
        public KeyValuePair<ToggleButton, Page> Tab
        {
            get
            {
                return _tab;
            }
        }
        public static ToggleButton GetToggleButton(Bitmap img, string text)
        {
            ToggleButton tmp = new ToggleButton();
            tmp.FontFamily = new System.Windows.Media.FontFamily("Consolas");
            WrapPanel wrapPanel = new WrapPanel();
            tmp.Content = wrapPanel;
            wrapPanel.Orientation = Orientation.Vertical;
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            image.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                img.GetHbitmap(),
                                IntPtr.Zero,
                                Int32Rect.Empty,
                                BitmapSizeOptions.FromEmptyOptions());
            image.Height = 25;
            wrapPanel.Children.Add(image);
            TextBlock tb = new TextBlock();
            tb.Text = text;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            wrapPanel.Children.Add(tb);
            return tmp;
        }
    }
}
