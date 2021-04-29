using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campanozzi.Model.DataAccessLayer
{
    public interface IDataAccessLayer
    {

    }

    public class JSONDataAccessLayer : IDataAccessLayer
    {
        public static int _seed = 0;

        public static void generateNewSeed()
        {
            _seed = new Random().Next();
        }
    }
}
