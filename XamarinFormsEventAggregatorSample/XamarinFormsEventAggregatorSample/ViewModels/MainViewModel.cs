using System;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms.EventAggregator;
using XamarinFormsEventAggregatorSample.Events;

namespace XamarinFormsEventAggregatorSample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IEventAggregator _EventAggregator;
        public MvvmHelpers.Commands.Command TextViewCommand { get; }

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

        public MainViewModel(IEventAggregator eventAggregator)
        {
            _texto = "Soma 0";
            _EventAggregator = eventAggregator;

            //Registra o Evento
            EventAggregator.Instance.RegisterHandler<TextMessage>(
       TextHandler);

            TextViewCommand = new MvvmHelpers.Commands.Command(async () => await SendTextViewCommandExecute());
        }

       

        private void TextHandler(
    TextMessage message)
        {
            Texto = message.Text;
        }


        private async Task SendTextViewCommandExecute()
        {
            await Xamarin.Forms.Application.Current.
            MainPage.Navigation.PushAsync(new SomarPage());
        }
    }
}
