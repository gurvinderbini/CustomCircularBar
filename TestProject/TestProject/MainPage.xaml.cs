using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestProject
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    private void Button_OnClicked(object sender, EventArgs e)
	    {
	        if (CustomProgressControl.Progress >= 1d)
	        {
	            CustomProgressControl.Progress = 0d;
                return;
	        }
	        CustomProgressControl.Progress = CustomProgressControl.Progress+.1;
	    }
    }
}
