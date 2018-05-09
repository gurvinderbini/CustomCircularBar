using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProject.Control
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomControl : ContentView
	{
		public CustomControl ()
		{
			InitializeComponent ();
		    AdjustControlHeight();


		}

        #region Progress Bar Properties

        public static readonly BindableProperty ProgressColorProperty =
            BindableProperty.Create(
                nameof(ProgressColor),
                typeof(Color),
                typeof(CustomControl),
                Color.DodgerBlue);

        public Color ProgressColor
        {
            get => (Color)GetValue(ProgressColorProperty);
            set => SetValue(ProgressColorProperty, value);
        }


	    public static readonly BindableProperty BaseColorProperty =
	        BindableProperty.Create(
	            nameof(BaseColor),
	            typeof(Color),
	            typeof(CustomControl),
	            Color.Gray);
	    
	    public Color BaseColor
        {
	        get => (Color)GetValue(BaseColorProperty);
	        set => SetValue(BaseColorProperty, value);
	    }

	    public static readonly BindableProperty ProgressProperty =
	        BindableProperty.Create(
	            nameof(Progress),
	            typeof(double),
	            typeof(CustomControl),
	            0d);

	    public double Progress
        {
	        get => (double)GetValue(ProgressProperty);
	        set => SetValue(ProgressProperty, value);
	    }

	    public static readonly BindableProperty ControlHeightProperty =
	        BindableProperty.Create(
	            nameof(ControlHeight),
	            typeof(double),
	            typeof(CustomControl),
	            100d);

	    public double ControlHeight
	    {
	        get => (double)GetValue(ControlHeightProperty);
	        set => SetValue(ControlHeightProperty, value);
	    }

	    //public static readonly BindableProperty ControlWidthProperty =
	    //    BindableProperty.Create(
	    //        nameof(ControlWidth),
	    //        typeof(double),
	    //        typeof(CustomControl),
	    //        100d);

	    //public double ControlWidth
	    //{
	    //    get => (double)GetValue(ControlWidthProperty);
	    //    set => SetValue(ControlWidthProperty, value);
	    //}
        #endregion


        protected override void OnPropertyChanged(string propertyName = null)
	    {
	        base.OnPropertyChanged(propertyName);

	        switch (propertyName)
	        {
                case "ProgressColor":
                    ProgressRing.RingProgressColor = ProgressColor;
                    break;
	            case "BaseColor":
	                ProgressRing.RingBaseColor = BaseColor;
	                break;
	            case "Progress":
	                ProgressRing.Progress = Progress;
	                break;
	            case "ControlHeight":
	                ProgressRing.HeightRequest = ControlHeight;
	                ProgressRing.WidthRequest = ControlHeight;
                    AdjustControlHeight();
                    break;
	           
            }
	     
        }


        #region Methods

	    private void AdjustControlHeight()
	    {
	        BaseImage.HeightRequest = ControlHeight * .8;
	        BaseImage.WidthRequest = ControlHeight * .8;
            ProgressRing.RingThickness = ControlHeight * .08;
	        BaseImage.Margin = ControlHeight * .05;
	    }
	   
        #endregion
    }
}