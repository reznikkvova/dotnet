using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class TeamListHandlerEventArgs
    {
        string _nameCollection;
        string _typeChanges;
        int _position;


        public TeamListHandlerEventArgs(string nameCollection, string typeChanges, int position)
        {
            _nameCollection = nameCollection;
            _typeChanges = typeChanges;
            _position = position;
        }

        public string NameCollection
        {
            get
            {
                return _nameCollection;
            }

            init
            {
                _nameCollection = value;
            }
        }

        public string TypeChanges
        {
            get
            {
                return _typeChanges;
            }

            init
            {
                _typeChanges = value;
            }
        }

        public int Position
        {
            get
            {
                return _position;
            }

            init
            {
                _position = value;
            }
        }

        public override string ToString()
        {
            return $"Info:\nName: {NameCollection}\nType: {TypeChanges}\n Position: {Position}\n";
        }
    }
}
