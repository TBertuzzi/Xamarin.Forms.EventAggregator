using System;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms.EventAggregator;
using XamarinFormsEventAggregatorSample.Events;

namespace XamarinFormsEventAggregatorSample.ViewModels
{
    public class TextViewModel : BaseViewModel
    {
        private readonly IEventAggregator _EventAggregator;
        public MvvmHelpers.Commands.Command SendTextCommand { get; }
        int _cont = 0;

        string _texto;
        public string Texto
        {
            get
            {
                return _texto;
            }
            set
            {
                SetProperty(ref _texto, value);
            }
        }

        public TextViewModel()
        {
            _texto = "Soma 0";

            SendTextCommand = new MvvmHelpers.Commands.Command(async () => await SendTextCommandExecute());
        }


        private async Task SendTextCommandExecute()
        {
            _cont++;
            var texto = $"Soma {_cont}";
            Texto = texto;

            var TextMessage = new TextMessage
            {
                Text = texto
            };

            EventAggregator.Instance.SendMessage(TextMessage);

        }
    }
}
