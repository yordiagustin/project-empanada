using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace Empanada.Views
{
    public partial class HomePage : ContentPage
    {

        public const string ServiceApiUrl = "https://australiaeast.api.cognitive.microsoft.com/customvision/v3.0/Prediction/9bb16b44-9cad-4b30-8a01-e2676735de1d/classify/iterations/Iteration2/image";
        public const string ApiKey = "c7ba676027384427ab654b96fbb753c0";
        private MediaFile _foto = null;

        public HomePage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            await Plugin.Media.CrossMedia.Current.Initialize();
            
            _foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() 
            {
                Directory = "Vision",
                Name = "Target.jpg"
            });
            LottieView.IsVisible = false;
            srcImage.Source = FileImageSource.FromFile(_foto.Path);


            var stream = _foto.GetStream();

            var httpClient = new HttpClient();
            var url = ServiceApiUrl;
            httpClient.DefaultRequestHeaders.Add("Prediction-Key", ApiKey);

            var content = new StreamContent(stream);

            var response = await httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                await DisplayAlert("Ups!", "Error 404", "a");
                return;
            }

            var json = await response.Content.ReadAsStringAsync();

            var c = JsonConvert.DeserializeObject<ClasificationResponse>(json);

            var p = c.Predictions.FirstOrDefault();
            if (p == null)
            {
                await DisplayAlert("Ups!", "Imagen no reconocida", "Ok");
                return;
            }
            //ResultLabel.Text = $"{p.TagName} - {p.Probability:p0}";

            if(p.TagName=="cross"|| p.TagName == "exit")
            {
                await Navigation.PushPopupAsync(new OkPopupPage(p.TagName));
            }
            else
            {
                await Navigation.PushPopupAsync(new WarningPopupPage(p.TagName));
            }




        }

        public class ClasificationResponse
        {
            public string Id { get; set; }
            public string Project { get; set; }
            public string Iteration { get; set; }
            public DateTime Created { get; set; }
            public Prediction[] Predictions { get; set; }
        }

        public class Prediction
        {
            public string TagId { get; set; }
            public string TagName { get; set; }
            public float Probability { get; set; }
        }
    }
}
