using System;
using System.Collections.Generic;
using Campanozzi.Model.DataAccessLayer;

namespace Campanozzi.Controller.Generator
{
    public interface IRoom
    {
        /// <summary>
        /// Define how generate a room
        /// </summary>
        void Generate();

        /// <summary>
        /// get or set center
        /// </summary>
        KeyValuePair<int, int> Center { get; set; }

        /// <summary>
        /// get map
        /// </summary>
        IDictionary<KeyValuePair<int, int>, SymbolsType> Map { get; }

        /// <summary>
        /// A copy of this room in a new object
        /// </summary>
        IRoom DeepCopy();
    }
}