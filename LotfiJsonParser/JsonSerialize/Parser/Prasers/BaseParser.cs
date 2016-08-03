using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JsonSerializ.Parser.Prasers
{
    public class BaseParser : IParser
    {
        protected BaseParser successor;

        public BaseParser()
        {

        }
        public void SetSuccessor(BaseParser successor)
        {
            this.successor = successor;
        }
        public virtual BaseParser CanParse(Context.IContextParser context)
        {
            throw new NotImplementedException();
        }

        public virtual void Parse(Context.IContextParser context)
        {
            throw new NotImplementedException();
        }

        protected bool StartWithThisChatecter(Context.IContextParser context, char endChar)
        {
            int i = context.GetIndex();
           ++i;
            while (true)
            {

                char nextCharceter = context.GetCharInIndex(i);
                switch (nextCharceter)
                {
                   
                    case '\\':
                    case '\n':
                    case '\r':
                    case ' ':
                    case ',':
                        i++;
                        break;
                    case '\"':
                    case '\'':
                        i++;
                        break;
                    default:
                        if (endChar.Equals(nextCharceter)) return true;
                        return false;
                        break;
                }

            }
        }

    }
}
