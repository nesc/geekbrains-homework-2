using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_2_polsky_oop_2_0
{
    class Element
    {
        public string symbol;
        public string type;
        public void Initialization(string symbol)
        {
            this.symbol = symbol;
            if (symbol == "+"
             || symbol == "-"
             || symbol == "*"
             || symbol == "/")
            {
                type = "Operation";
            }
            if (symbol == "1"
             || symbol == "2"
             || symbol == "3"
             || symbol == "4"
             || symbol == "5"
             || symbol == "6"
             || symbol == "7"
             || symbol == "8"
             || symbol == "9"
             || symbol == "0")
            {
                type = "Number";
            }
            if (symbol == "("
             || symbol == ")")
            {
                type = "Bracket";
            }
        }
    }
}
