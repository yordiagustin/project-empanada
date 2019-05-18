using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace Empanada.Views
{
    public partial class WarningPopupPage : PopupPage
    {
        public WarningPopupPage(string tag)
        {
            InitializeComponent();
            Tag.Text = tag.ToUpper();
            switch (tag)
            {
                case "dead":
                    DescriptionLabel.Text = "We recommend you do not touch anything and preferably leave the place.";
                    break;
                case "smoke":
                    DescriptionLabel.Text = "We recommend you stop and look around you.";
                    break;
                case "stop":
                    DescriptionLabel.Text = "We recommend you call (786) 812-1934 to ask for help";
                    break;
                case "voltage":
                    DescriptionLabel.Text = "We recommend you do not touch anything and preferably leave the place.";
                    break;
                case "warning":
                    DescriptionLabel.Text = "We recommend you do not touch anything and preferably leave the place.";
                    break;
                case "warningW":
                    Tag.Text = "WARNING";
                    DescriptionLabel.Text = "We recommend you do not touch anything and preferably leave the place.";
                    break;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // ### Methods for supporting animations in your popup page ###

        // Invoked before an animation appearing
        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();
        }

        // Invoked after an animation appearing
        protected override void OnAppearingAnimationEnd()
        {
            base.OnAppearingAnimationEnd();
        }

        // Invoked before an animation disappearing
        protected override void OnDisappearingAnimationBegin()
        {
            base.OnDisappearingAnimationBegin();
        }

        // Invoked after an animation disappearing
        protected override void OnDisappearingAnimationEnd()
        {
            base.OnDisappearingAnimationEnd();
        }

        protected override Task OnAppearingAnimationBeginAsync()
        {
            return base.OnAppearingAnimationBeginAsync();
        }

        protected override Task OnAppearingAnimationEndAsync()
        {
            return base.OnAppearingAnimationEndAsync();
        }

        protected override Task OnDisappearingAnimationBeginAsync()
        {
            return base.OnDisappearingAnimationBeginAsync();
        }

        protected override Task OnDisappearingAnimationEndAsync()
        {
            return base.OnDisappearingAnimationEndAsync();
        }

        // ### Overrided methods which can prevent closing a popup page ###

        // Invoked when a hardware back button is pressed
        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return base.OnBackButtonPressed();
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return base.OnBackgroundClicked();
        }
    }
}
