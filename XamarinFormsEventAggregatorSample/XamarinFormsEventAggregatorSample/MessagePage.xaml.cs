using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinFormsEventAggregatorSample.ViewModels;

namespace XamarinFormsEventAggregatorSample
{
    public partial class MessagePage : ContentPage
    {
        public MessagePage()
        {
            InitializeComponent();

            this.BindingContext = new MessageViewModel();
        }
    }
}
