namespace MyComboxMenuControls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    public class ComboxMenu : ComboBox
    {
        static ComboxMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboxMenu), new FrameworkPropertyMetadata(typeof(ComboxMenu)));
        }

        public Geometry MenuGeometry
        {
            get { return (Geometry)GetValue(MenuGeometryProperty); }
            set { SetValue(MenuGeometryProperty, value); }
        }
        public static readonly DependencyProperty MenuGeometryProperty = DependencyProperty.Register("MenuGeometry", typeof(Geometry), typeof(ComboxMenu), new PropertyMetadata(null));

        public string MenuText
        {
            get { return (string)GetValue(MenuTextProperty); }
            set { SetValue(MenuTextProperty, value); }
        }
        public static readonly DependencyProperty MenuTextProperty = DependencyProperty.Register("MenuText", typeof(string), typeof(ComboxMenu), new PropertyMetadata(null));

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            this.SetValue(IsDropDownOpenProperty, false);
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            this.SetValue(IsDropDownOpenProperty, true);
            this.SetValue(FocusableProperty, true);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var c = (UIElement)e.Source;
            var p = e.GetPosition(this);
            Rect parent = new Rect(this.Margin.Left, this.Margin.Top, this.ActualWidth, this.ActualHeight);
            if (!parent.Contains(p) && this.HasItems)
            {
                var cf = (ComboxMenuItem)this.Items[0];
                if (cf == null)
                    return;
                p = e.GetPosition(cf);
                Rect child = new Rect(cf.Margin.Left, cf.Margin.Top, cf.ActualWidth, cf.ActualHeight * this.Items.Count);
                if (!child.Contains(p))
                {
                    ((UIElement)e.Source).ReleaseMouseCapture();
                }
            }
        }
    }
}
