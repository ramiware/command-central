using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandCentral.CC_CoreObjects
{
    class CommandBuffer
    {
        private List<string> cmdBuffer = new List<string>();
        private int currIndex = 0;

        public void addEntry(string value)
        {
            cmdBuffer.Add(value);
            currIndex++;
        }

        public string getNextEntry()
        {
            if (cmdBuffer.Count == 0)
                return "";

            if (cmdBuffer.Count == 1)
                return cmdBuffer[0];

            if (currIndex == cmdBuffer.Count - 1)
                currIndex = 0;
            else
                currIndex++;

            return cmdBuffer[currIndex];
        }

        public string getPreviousEntry()
        {
            if (cmdBuffer.Count == 0)
                return "";

            if (cmdBuffer.Count == 1)
                return cmdBuffer[0];

            if (currIndex == 0)
                currIndex = cmdBuffer.Count - 1;
            else
                currIndex--;

            return cmdBuffer[currIndex];
        }
    }
}
