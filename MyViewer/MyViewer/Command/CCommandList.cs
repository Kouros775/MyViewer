using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyViewer.Command;

namespace MyViewer.Command
{
    enum E_COMMAND
    {
        READFILE
    }
    class CCommandList
    {
        private Dictionary<E_COMMAND, ICommand> _dicCommand = new Dictionary<E_COMMAND, ICommand>();

        public CCommandList()
        {

        }
        ~CCommandList()
        {

        }


        public void AddCommand(E_COMMAND eType)
        {
            ICommand command;

            switch(eType)
            {
                case E_COMMAND.READFILE:
                    command = new CCommandReadFile();
                    _dicCommand.Add(eType, command);
                    break;
                default:
                    break;
            }
        }


        private ICommand _getCommand(E_COMMAND eType)
        {
            ICommand command;

            _dicCommand.TryGetValue(eType, out command);

            return command;
        }

        public bool Execute(E_COMMAND eType)
        {
            bool bRes = false;

            ICommand command = _getCommand(eType);
            
            if(command != null)
            {
                command.Execute();
                bRes = true;
            }

            return bRes;
        }
    }
}
