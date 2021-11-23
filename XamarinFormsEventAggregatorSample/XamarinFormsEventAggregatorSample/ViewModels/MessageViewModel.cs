using System;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms.EventAggregator;
using XamarinFormsEventAggregatorSample.Events;

namespace XamarinFormsEventAggregatorSample.ViewModels
{
    public class MessageViewModel : BaseViewModel
    {
        public MvvmHelpers.Commands.Command SendTextCommand { get; }
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

        public MessageViewModel()
        {
            _text = string.Empty;

            SendTextCommand = new MvvmHelpers.Commands.Command(async () => await SendTextCommandExecute());
        }


        private async Task SendTextCommandExecute()
        { 

            var TextMessage = new TextMessage
            {
                Text = Text
            };

            EventAggregator.Instance.SendMessage(TextMessage);

            await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();

        }
    }
}
