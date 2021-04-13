using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_2_polsky_oop_2_0
{
    class ProcessingExpression
    {
        public string resultExpression;
        protected string operation = "";
        protected string operationInBracket = "";
        protected int bracketLevel = 0;
        protected string bracketExpression = "";
        public void GetOutputString(string expression)
        {
            CollectPolskyReverseString calculateResult = new CollectPolskyReverseString();
            for (int i = 0; i < expression.Length; i++)
            {
                Element thisElement = new Element();
                thisElement.Initialization(expression[i].ToString());

                if (thisElement.type == "Number")
                {
                    if (operation != "" && bracketLevel == 0)
                    {
                        calculateResult.AddCharToResult(thisElement.symbol + " " + operation);
                        operation = "";
                    }
                    else if (operation == "" && bracketLevel == 0)
                        calculateResult.AddCharToResult(thisElement.symbol);

                    if (operationInBracket != "" && bracketLevel != 0)
                    {
                        bracketExpression += operationInBracket;
                        bracketExpression += thisElement.symbol;
                    }
                    else if (operationInBracket == "" && bracketLevel != 0)
                        bracketExpression += thisElement.symbol;
                }

                if (thisElement.type == "Operation")
                {
                    if (operation != "" && bracketLevel == 0)
                    {
                        calculateResult.AddCharToResult(thisElement.symbol);
                        operation = "";
                    }
                    else if (operation == "" && bracketLevel == 0)
                        operation = thisElement.symbol;

                    if (operationInBracket != "" && bracketLevel != 0)
                    {
                        calculateResult.AddCharToResult(thisElement.symbol);
                        operationInBracket = "";
                    }
                    else if (operationInBracket == "" && bracketLevel != 0)
                        operationInBracket = thisElement.symbol;
                }

                if (thisElement.type == "Bracket")
                {
                    if (thisElement.symbol == "(")
                        bracketLevel += 1;

                    if (thisElement.symbol == ")")
                    {
                        ProcessingExpression calculateBracket = new ProcessingExpression();
                        calculateBracket.GetOutputString(bracketExpression);
                        calculateResult.AddCharToResult(calculateBracket.resultExpression.Trim());
                        if (operation != "")
                        {
                            calculateResult.AddCharToResult(operation);
                            operation = "";
                        }
                        bracketLevel -= 1;
                    }
                }
            }
            resultExpression = calculateResult.polskyString;
        }
    }
}
