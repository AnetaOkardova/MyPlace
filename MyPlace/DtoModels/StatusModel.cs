using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlace.DtoModels
{
    public class StatusModel
    {
        public StatusModel()
        {
            IsSuccessful = true;    
        }
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
