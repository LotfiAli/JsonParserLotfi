using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JsonSerializ.JSonBase;
using JsonSerializ.JSonBase.Poperty;
using JsonSerializ.Parser.EnumParser;
using JsonSerializ.Parser.Prasers;
using JsonSerializ.Poperty;

namespace JsonSerializ.Parser.Context
{
    public class ContextParser : IContextParser
    {
        private const string Null = "null";

        private readonly string _JsonString;
        private readonly char[] _JsonChar;
        private readonly int _Lentght;
        private readonly BaseParser _RootParser;
        private readonly Stack<ICompositeProperty> _StackCoposite = new Stack<ICompositeProperty>();
        private ICompositeProperty _ActiveCompositive = new CompoiteProperty {Name = "OutBound"};
        private int _Index;
        private string _Key;
        private CurrentState currentState = CurrentState.Start;

        public ContextParser(string jsonString, BaseParser rootParser)
        {
            this._JsonString = jsonString;
            var textReader = new StringReader(jsonString);
            this._JsonChar = new char[jsonString.Length];
            textReader.Read(this._JsonChar, 0, jsonString.Length);
            this._Lentght = jsonString.Length;
            this._RootParser = rootParser;
        }

        public void AddComposite(ICompositeProperty compositeProperty)
        {
            this._StackCoposite.Push(compositeProperty);
            compositeProperty.Parent = this._ActiveCompositive;
            this._ActiveCompositive.AddToList(compositeProperty);
            this._ActiveCompositive = compositeProperty;
            this._Index++;
        }
        public void AddProperty(IBaseProperty baseProperty)
        {
            baseProperty.Parent = this._ActiveCompositive;
            this._ActiveCompositive.AddToList(baseProperty);
        }

        public void RemoveComposite()
        {
            this._StackCoposite.Pop();
            if (this._StackCoposite.Count > 0)
                this._ActiveCompositive = this._StackCoposite.Peek();
            this._Index++;
        }
        public char GetNextSpecificCharacters()
        {
            return this._JsonChar[this._Index];
        }
        public string GetKey()
        {
            return this._Key;
        }
        public void GoAhead(int count = 1)
        {
            this._Index += count;
        }

        public int GetIndex()
        {
            return this._Index;
        }

        public char GetCharInIndex(int index)
        {
            return this._JsonChar[index];
        }
        public IBaseProperty GetParent()
        {
            return this._ActiveCompositive;
        }
        public CompoiteProperty ParseJosn()
        {
            if (this._JsonString.Equals(Null))
                return new CompoiteProperty {Name = "empty"};
           do
            {
                this.ParseValue();
                var selectChain = this._RootParser.CanParse(this);
                if (selectChain != null)
                    selectChain.Parse(this);
            }
            while (this._StackCoposite.Count > 0);
            return this._ActiveCompositive as CompoiteProperty;
        }
        private void ParseValue()
        {
            this._Key = string.Empty;
            while (true)
            {
                if (this._JsonChar.Length <= this._Index)
                    throw new Exception("TODO");
                var nextCharceter = this._JsonChar[this._Index];
                switch (nextCharceter)
                {
                    case '\\':
                    case '\n':
                    case '\r':
                    case ' ':
                    case ',':
                        this._Index++;
                        break;
                    case '\"':
                    case '\'':
                        this._Key = this.GetKeyFromString();
                        break;
                    case ':':
                        this.ParseObject();
                        return;
                    default:
                        return;
                }
            }
        }
        private void ParseObject()
        {
            while (true)
            {
                if (this._JsonChar.Length <= this._Index)
                    throw new Exception("TODO");
                var nextCharceter = this._JsonChar[this._Index];
                switch (nextCharceter)
                {
                    case ' ':
                        this._Index++;
                        break;
                    case '\"':
                    case '\'':
                        this._Index++;
                        break;
                    case ':':
                        this._Index++;
                        break;
                    default:
                        return;
                }
            }
        }
        public string GetKeyFromString()
        {
            var key = string.Empty;
            if (this._Index == this._Lentght || this._Index + 1 == this._Lentght)
                return string.Empty;
            while (true)
            {
                var nextCharceter = this._JsonChar[this._Index];
                switch (nextCharceter)
                {
                    case '\\':
                    case '\n':
                    case '\r':
                    case ' ':
                        this._Index++;
                        break;
                    case '\"':
                    case '\'':
                        this._Index++;
                        break;
                    case ':':
                        return key;
                    default:
                        this._Index++;
                        key += nextCharceter;
                        break;
                }
            }
        }
    }
}