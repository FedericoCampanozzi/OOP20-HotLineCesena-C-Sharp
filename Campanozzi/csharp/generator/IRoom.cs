using System;
using System.Collections.Generic;
using Campanozzi.Model.DataAccessLayer;

namespace Campanozzi.Controller.Generator
{
    public interface IRoom
    {
        void Generate();

        KeyValuePair<int, int> Center { get; set; }

        IDictionary<KeyValuePair<int, int>, SymbolsType> Map { get; }
        
        IRoom DeepCopy();
    }
}