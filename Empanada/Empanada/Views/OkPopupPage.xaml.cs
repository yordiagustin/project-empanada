using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Empanada.Views
{
    public partial class OkPopupPage : PopupPage
    {
        public OkPopupPage(string tag)
        {
            InitializeComponent();
            Tag.Text = tag.ToUpper();

            switch (tag)
            {
                case "exit":
                    DescriptionLabel.Text = "We recommend you follow the signal if you want to leave the place";
                    break;
                case "cross":
                    DescriptionLabel.Text = "We recommend you call (786) 812-1934 to ask for help";
                    break;
            }
        }
    }
}
