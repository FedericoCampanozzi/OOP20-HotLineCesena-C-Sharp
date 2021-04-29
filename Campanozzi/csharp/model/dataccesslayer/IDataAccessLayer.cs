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
        public static int SEED = 0;
        private static IDataAccessLayer singleton = null;

        public static IDataAccessLayer getInstance()
        {
            if (singleton == null)
            {
                singleton = new JSONDataAccessLayer();
            }
            return singleton;
        }
        
        public static void generateNewSeed()
        {
            SEED = new Random().Next();
        }
        
        public static void newInstance()
        {
            SEED = new Random().Next();
            singleton = new JSONDataAccessLayer();
        }
    }
}
