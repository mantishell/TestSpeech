using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSpeech.Services
{
    public interface IBroadCast
    {
        void SetRate(int readSpeed);
        void Speak(string content);
        void Dispose();
    }
}
