using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SmsNotification : INotification
    {
        public void Notify(string message)
        {
            //TODO: Send Email
            Console.WriteLine($"SMS: {message}");

        }
    }
}
