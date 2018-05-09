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
		  //  BaseImage.HeightRequest = BaseImage.WidthRequest = ControlHeight * .5;


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

	    //public static readonly BindableProperty IconHeightProperty =
	    //    BindableProperty.Create(
	    //        nameof(IconHeight),
	    //        typeof(double),
	    //        typeof(CustomControl),
	    //        100d);

	    //public double IconHeight
     //   {
	    //    get => (double)GetValue(IconHeightProperty);
	    //    set => SetValue(IconHeightProperty, value);
	    //}

	    public static readonly BindableProperty IconProperty =
	        BindableProperty.Create(
	            nameof(Icon),
	            typeof(string),
	            typeof(CustomControl),
	            string.Empty);

	    public string Icon
	    {
	        get => (string)GetValue(IconProperty);
	        set => SetValue(IconProperty, value);
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

	            //case "IconHeight":
	            //    BaseImage.HeightRequest=BaseImage.WidthRequest = IconHeight;
	            //    break;
	            case "Icon":
	                BaseImage.Source = Icon;
	                break;

            }
	     
        }


        #region Methods

	    private void AdjustControlHeight()
	    {
	        RowDefinition1.Height = ControlHeight;
	        ProgressRing.RingThickness = ControlHeight * .08;
	        BaseImage.Margin = ControlHeight * .05;
	        BaseImage.HeightRequest = BaseImage.WidthRequest = ControlHeight * .65;
        }
	   
        #endregion
    }
}