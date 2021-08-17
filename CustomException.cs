using System;

namespace Assessment2
{
    public class DuplicateEmailEception : Exception 
    {
        public DuplicateEmailEception(String message)
            :base(message)
        {

        }

    }
}
