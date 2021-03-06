﻿using System;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProject.Control
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomProgressControl : ContentView
	{
        private string CountLabelTitle=String.Empty;

        #region CTOR
        public CustomProgressControl()
        {
            InitializeComponent();
            AdjustControlHeight();
        } 
        #endregion

        #region Progress Bar Properties

        public static readonly BindableProperty ProgressColorProperty =
            BindableProperty.Create(
                nameof(ProgressColor),
                typeof(Color),
                typeof(CustomProgressControl),
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
	            typeof(CustomProgressControl),
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
	            typeof(CustomProgressControl),
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
	            typeof(CustomProgressControl),
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



        #endregion

        #region Image Properties
	    public static readonly BindableProperty IconProperty =
	        BindableProperty.Create(
	            nameof(Icon),
	            typeof(string),
	            typeof(CustomProgressControl),
	            string.Empty);

	    public string Icon
	    {
	        get => (string)GetValue(IconProperty);
	        set => SetValue(IconProperty, value);
	    }

	    public static readonly BindableProperty IconBackgroundColorProperty =
	        BindableProperty.Create(
	            nameof(IconBackgroundColor),
	            typeof(Color),
	            typeof(CustomProgressControl),
	            Color.White);

	    public Color IconBackgroundColor
	    {
	        get => (Color)GetValue(IconBackgroundColorProperty);
	        set => SetValue(IconBackgroundColorProperty, value);
	    }

        #endregion

        #region Title Label Properties

        public static readonly BindableProperty TitleProperty =
	        BindableProperty.Create(
	            nameof(Title),
	            typeof(string),
	            typeof(CustomProgressControl),
	            string.Empty);

	    public string Title
        {
	        get => (string)GetValue(TitleProperty);
	        set => SetValue(TitleProperty, value);
	    }

	    public static readonly BindableProperty TitleFontSizeProperty =
	        BindableProperty.Create(
	            nameof(TitleFontSize),
	            typeof(double),
	            typeof(CustomProgressControl),
	            20d);

	    public double TitleFontSize
	    {
	        get => (double)GetValue(TitleFontSizeProperty);
	        set => SetValue(TitleFontSizeProperty, value);
	    }

	    public static readonly BindableProperty TitleTextColorProperty =
	        BindableProperty.Create(
	            nameof(TitleTextColor),
	            typeof(Color),
	            typeof(CustomProgressControl),
	            Color.Black);

	    public Color TitleTextColor
	    {
	        get => (Color)GetValue(TitleTextColorProperty);
	        set => SetValue(TitleTextColorProperty, value);
	    }

	    public static readonly BindableProperty StepCountProperty =
	        BindableProperty.Create(
	            nameof(StepCount),
	            typeof(double),
	            typeof(CustomProgressControl),
	            0d);

	    public double StepCount
        {
	        get => (double)GetValue(StepCountProperty);
	        set => SetValue(StepCountProperty, value);
	    }
        #endregion

        #region Count Label Properties

        public static readonly BindableProperty TotalProgressCountProperty =
	        BindableProperty.Create(
	            nameof(TotalProgressCount),
	            typeof(double),
	            typeof(CustomProgressControl),
	            0d);

	    public double TotalProgressCount
        {
	        get => (double)GetValue(TotalProgressCountProperty);
	        set => SetValue(TotalProgressCountProperty, value);
        }

	    public static readonly BindableProperty CurrentProgressCountProperty =
	        BindableProperty.Create(
	            nameof(CurrentProgressCount),
	            typeof(double),
	            typeof(CustomProgressControl),
	            0d);

	    public double CurrentProgressCount
        {
	        get => (double)GetValue(CurrentProgressCountProperty);
	        set => SetValue(CurrentProgressCountProperty, value);
	    }

        #endregion

        #region Override Methods
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case "ProgressColor":
                    TotalCountLabel.TextColor = CurrentCountLabel.TextColor = 
                        OfLabel.TextColor = ProgressRing.RingProgressColor = ProgressColor;
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
        
                case "Icon":
                    BaseImage.Source = Icon;
                    break;
                case "IconBackgroundColor":
                    MyBoxView.BackgroundColor = IconBackgroundColor;
                    break;

                case "Title":
                    TitleLabel.Text = Title;
                    break;
                case "TitleFontSize":
                    StepCountLabel.FontSize= TitleLabel.FontSize = TitleFontSize;
                    break;
                case "TitleTextColor":
                  StepCountLabel.TextColor=  TitleLabel.TextColor = TitleTextColor;
                    break;
                case "StepCount":
                    StepCountLabel.Text =$"{Convert.ToString(StepCount, CultureInfo.InvariantCulture)}." ;
                    break;


                case "TotalProgressCount":
                    TotalCountLabel.Text = Convert.ToString(TotalProgressCount, CultureInfo.InvariantCulture);
                    break;
                case "CurrentProgressCount":
                    CurrentCountLabel.Text = Convert.ToString(CurrentProgressCount, CultureInfo.InvariantCulture);
                    break;


            }

        } 
        #endregion


        #region Methods

        private void AdjustControlHeight()
	    {
	        RowDefinition1.Height = ControlHeight;
	        ProgressRing.RingThickness = ControlHeight * .08;
	        BaseImage.Margin = ControlHeight * .05;
	        BaseImage.HeightRequest = BaseImage.WidthRequest = ControlHeight * .50;
	        MyBoxView.CornerRadius= MyBoxView.HeightRequest= MyBoxView.WidthRequest = ControlHeight * .70; ;

	    }
	   
        #endregion
    }
}