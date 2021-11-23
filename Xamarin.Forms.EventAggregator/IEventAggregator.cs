using System;
namespace Xamarin.Forms.EventAggregator
{
    public interface IEventAggregator
    {
        // Envia Mensagem e aguarda para ser processado na UI thread antes de retornar
        void SendMessage<T>(T message);
        // Publica a mensagem para processamento posterior na UI thread , retornando imediatamente.
        void PostMessage<T>(T message);
        //Registra o Delegate
        Action<T> RegisterHandler<T>(Action<T> eventHandler);
        //retira o registro do Delegate
        void UnregisterHandler<T>(Action<T> eventHandler);
    }
}
