using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Campanozzi.Model.DataAccessLayer
{
    public class JSONDataAccessLayer
    {
        public static int _seed = 0;
        private static JSONDataAccessLayer _singleton = null;
        private const string PROJECT_NAME = "Campanozzi";

        private JSONDataAccessLayer()
        {
            string[] pathPart = Directory.GetCurrentDirectory().Split(Path.DirectorySeparatorChar);
            for (int i = 0; i < pathPart.Length && pathPart[i] != PROJECT_NAME; i++)
            {
                ProjectPath += pathPart[i] + Path.DirectorySeparatorChar;
            }
            ProjectPath += PROJECT_NAME;
        }

        public static void GenerateNewSeed()
        {
            _seed = new Random().Next();
        }

        public static JSONDataAccessLayer GetInstance()
        {
            if (_singleton == null)
            {
                _singleton = new JSONDataAccessLayer();
            }
            return _singleton;
        }

        public string ProjectPath { get; private set; }
    }
}
