using System;
using System.Collections.Generic;
using EncryptKeyClient.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace EncryptKeyClient
{
    public partial class EncryptPage : ContentPage
    {
        public EncryptPage()
        {
            InitializeComponent();
            vm = App.ServiceProvider.GetRequiredService<EnctyptVM>();
            this.BindingContext = vm;
        }
        EnctyptVM vm { get; set; }
    }
}
