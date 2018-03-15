using System;

namespace labs.lab2
{
    class ElementNotFoundException : Exception
    {
        public ElementNotFoundException() { }
        public ElementNotFoundException(string msg)
            : base(msg){}
        public ElementNotFoundException(string msg, Exception inner)
            : base(msg, inner) {}
    }
}
