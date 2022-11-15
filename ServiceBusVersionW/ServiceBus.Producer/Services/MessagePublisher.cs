using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Producer.Services
{
    class MessagePublisher : IMessagePublisher
    {
        private readonly IQueueClient _queuedClient;

        public MessagePublisher(IQueueClient queuedClient)
        {
            _queuedClient = queuedClient;
        }
        public Task Publish<T>(T obj)
        {
            var objAsText = JsonConvert.SerializeObject(obj);
            var msg = new Message(Encoding.UTF8.GetBytes(objAsText));
            return _queuedClient.SendAsync(msg);
        }

        public Task Publish(string message)
        {
            var msg = new Message(Encoding.UTF8.GetBytes(message));
            return _queuedClient.SendAsync(msg);

        }
    }
}
