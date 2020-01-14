namespace MyComboxMenuControls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class ComboxMenuItem : ComboBoxItem
    {
        static ComboxMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboxMenuItem), new FrameworkPropertyMetadata(typeof(ComboxMenuItem)));
        }

        public Geometry ItemGeometry
        {
            get { return (Geometry)GetValue(ItemGeometryProperty); }
            set { SetValue(ItemGeometryProperty, value); }
        }

        public static readonly DependencyProperty ItemGeometryProperty = DependencyProperty.Register("ItemGeometry", typeof(Geometry), typeof(ComboxMenuItem), new PropertyMetadata(null));
    }
}
