using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Xamarin.Forms.EventAggregator
{
    public class EventAggregator : IEventAggregator
    {

        private readonly List<Delegate> _handlers = new List<Delegate>();

        private readonly SynchronizationContext _synchronizationContext;

        public EventAggregator()
        {
            _synchronizationContext = SynchronizationContext.Current;
        }

        private static EventAggregator instance;
        public static EventAggregator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventAggregator();
                }
                return instance;
            }
        }


        public void SendMessage<T>(T message)
        {
            if (message == null)
            {
                return;
            }

            if (_synchronizationContext != null)
            {
                _synchronizationContext.Send(
                    m => Dispatch<T>((T)m),
                    message);
            }
            else
            {
                Dispatch(message);
            }
        }


        public void PostMessage<T>(T message)
        {
            if (message == null)
            {
                return;
            }

            if (_synchronizationContext != null)
            {
                _synchronizationContext.Post(
                    m => Dispatch<T>((T)m),
                    message);
            }
            else
            {
                Dispatch(message);
            }
        }

        public Action<T> RegisterHandler<T>(Action<T> eventHandler)
        {
            if (eventHandler == null)
            {
                throw new ArgumentNullException("eventHandler");
            }

            _handlers.Add(eventHandler);
            return eventHandler;
        }


        public void UnregisterHandler<T>(Action<T> eventHandler)
        {
            if (eventHandler == null)
            {
                throw new ArgumentNullException("eventHandler");
            }

            _handlers.Remove(eventHandler);
        }


        private void Dispatch<T>(T message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var compatibleHandlers
                = _handlers.OfType<Action<T>>()
                    .ToList();
            foreach (var handler in compatibleHandlers)
            {
                handler(message);
            }
        }


    }
}
