using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBox_API
{
    public class ResponseOperation
    {
        public bool ResultOperation { get; set; }
        public string Message { get; set; }
        public ResponseOperation(){}
        public ResponseOperation(bool resulOperation, string message){
            ResultOperation = resulOperation;
            Message = message;
        }
    }
}