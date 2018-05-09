using System;
using TestProject.Control;
using TestProject.iOS.Native;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyBoxView), typeof(RoundBoxViewRender))]

namespace TestProject.iOS.Native
{
    public class RoundBoxViewRender : BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            if (Element == null) return;
            Layer.MasksToBounds = true;
            Layer.CornerRadius = (float)((MyBoxView)this.Element).CornerRadius / 2.0f;
        }
    }
}