using System;

namespace Drupal_PhotoUpload
{
    public class DrupalEventArgs : EventArgs
    {
        public string ResponseType = "";
        public string TheMessage = "";

        public DrupalEventArgs(string _rType, string _message)
        {
            ResponseType = _rType;
            TheMessage = _message;
        }
    }
}