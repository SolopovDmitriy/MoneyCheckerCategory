using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MoneyChecker
{
    class TabViewController
    {
        private Grid _bodyControl;

        private  List<TabViewControl> _tabs = new List<TabViewControl>();

        private ToolBar _toolBar;
        private Frame _frame;
        public Grid Body
        {
            get
            {
                return _bodyControl;
            }
        }
        public TabViewController()
        {
            _bodyControl = new Grid();
            _bodyControl.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            _bodyControl.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;

            RowDefinition rowButtons = new RowDefinition();
            rowButtons.Height = new GridLength(60, GridUnitType.Pixel);
            _bodyControl.RowDefinitions.Add(rowButtons);
            
            _bodyControl.RowDefinitions.Add(new RowDefinition());
            _bodyControl.ColumnDefinitions.Add(new ColumnDefinition());
            _bodyControl.Height = Double.NaN;
            _toolBar = new ToolBar() { VerticalAlignment = System.Windows.VerticalAlignment.Top, Height = 60};
            Grid.SetRow(_toolBar, 0);
            Grid.SetColumn(_toolBar, 0);

            _frame = new Frame();
            _frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            Grid.SetRow(_frame, 1);
            Grid.SetColumn(_frame, 0);

            _bodyControl.Children.Add(_toolBar);
            _bodyControl.Children.Add(_frame);
        }

        private void renderTab(TabViewControl tabViewControl)
        {
            _toolBar.Items.Add(tabViewControl.Tab.Key);
            _frame.Navigate(tabViewControl.Tab.Value);
        }

        public void AddTab(TabViewControl tabViewControl)
        {
            _tabs.Add(tabViewControl);
            renderTab(tabViewControl);
            tabViewControl.Tab.Key.Click += Key_Click;
        }

        private void Key_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ToggleButton cliked = (ToggleButton)sender;

            foreach (var item in _tabs)
            {
                item.Tab.Key.IsChecked = false;
                if(item.Tab.Key == cliked)
                {
                    item.Tab.Key.IsChecked = true;
                    _frame.Navigate(item.Tab.Value);
                }
            }
        }
    }
}
