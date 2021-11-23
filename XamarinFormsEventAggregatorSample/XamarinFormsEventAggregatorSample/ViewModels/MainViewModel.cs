using System;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms.EventAggregator;
using XamarinFormsEventAggregatorSample.Events;

namespace XamarinFormsEventAggregatorSample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MvvmHelpers.Commands.Command TextViewCommand { get; }

        string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                SetProperty(ref _text, value);
            }
        }

        public MainViewModel()
        {
            _text = string.Empty;

            //Register EventHandler
            EventAggregator.Instance.RegisterHandler<TextMessage>(
       TextHandler);

            TextViewCommand = new MvvmHelpers.Commands.Command(async () => await SendTextViewCommandExecute());
        }

       

        private void TextHandler(
    TextMessage message)
        {
            Text = message.Text;
        }


        private async Task SendTextViewCommandExecute()
        {
            await Xamarin.Forms.Application.Current.
            MainPage.Navigation.PushAsync(new MessagePage());
        }
    }
}
