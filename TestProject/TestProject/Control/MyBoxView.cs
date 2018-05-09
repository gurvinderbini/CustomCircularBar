using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestProject.Control
{
    public class MyBoxView : BoxView
    {
        //Create a Bindable Property For CornerRadius  
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MyBoxView), 0.0);
        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
