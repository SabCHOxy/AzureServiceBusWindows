using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.Producer.Services
{
    interface IMessagePublisher
    {
        Task Publish<T>(T obj);
        Task Publish(string message);
    }
}
