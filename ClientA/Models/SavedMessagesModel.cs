using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientA.Models
{
    public class SavedMessagesModel
    {
        public string message { get; set; }
        public string date { get; set; }

        public override string ToString()
        {
            return string.Format("Message: {0} ,Date: {1}", message, date);
        }
    }
}
