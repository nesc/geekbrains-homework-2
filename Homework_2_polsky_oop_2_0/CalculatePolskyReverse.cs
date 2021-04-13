using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_2_polsky_oop_2_0
{
    class CalculatePolskyReverse
    {
        public string result;
        protected float countNumber;
        protected float buferNumber;
        protected float doubleBuferNumber;
        protected string[] list = new string[50];
        protected int countList;
        protected int found;


        public void GetResult(string input_expression)
        {
            countList = 0;
            countNumber = 0;
            found = 0;
            list = input_expression.Split(' ');
            Element calculateElement = new Element();

            while (countList < list.Length)
            {
                calculateElement.Initialization(list[countList]);
                if (calculateElement.type == "Number" && countNumber == 0 && found == 0)
                {
                    countNumber = float.Parse(calculateElement.symbol);
                    found = 1;
                }

                if (countNumber != 0 && found == 0)
                {
                    if (calculateElement.type == "Number" && found == 0 && buferNumber == 0)
                    {
                        buferNumber = float.Parse(calculateElement.symbol);
                        found = 1;
                    }

                    if (calculateElement.type == "Operation" && buferNumber != 0 && found == 0 && doubleBuferNumber == 0)
                    {
                        if (calculateElement.symbol == "+")
                        {
                            countNumber += buferNumber;
                            buferNumber = 0;
                            found = 1;
                        }
                        if (calculateElement.symbol == "-")
                        {
                            countNumber -= buferNumber;
                            buferNumber = 0;
                            found = 1;
                        }
                        if (calculateElement.symbol == "*")
                        {
                            countNumber *= buferNumber;
                            buferNumber = 0;
                            found = 1;
                        }
                        if (calculateElement.symbol == "/")
                        {
                            countNumber /= buferNumber;
                            buferNumber = 0;
                            found = 1;
                        }
                    }

                    if (calculateElement.type == "Number" && buferNumber != 0 && found == 0)
                    {
                        doubleBuferNumber = float.Parse(calculateElement.symbol);
                        found = 1;
                    }

                    if (calculateElement.type == "Operation" && buferNumber != 0 && doubleBuferNumber != 0 && found == 0)
                    {
                        if (calculateElement.symbol == "+")
                        {
                            buferNumber += doubleBuferNumber;
                            doubleBuferNumber = 0;
                            found = 1;
                        }
                        if (calculateElement.symbol == "-")
                        {
                            buferNumber -= doubleBuferNumber;
                            doubleBuferNumber = 0;
                            found = 1;
                        }
                        if (calculateElement.symbol == "*")
                        {
                            buferNumber *= doubleBuferNumber;
                            doubleBuferNumber = 0;
                            found = 1;
                        }
                        if (calculateElement.symbol == "/")
                        {
                            buferNumber /= doubleBuferNumber;
                            doubleBuferNumber = 0;
                            found = 1;
                        }
                    }

                }
                countList++;
                found = 0;
            }
            result = countNumber.ToString();
        }

    }
}
