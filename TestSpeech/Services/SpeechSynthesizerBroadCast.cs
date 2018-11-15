using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;

namespace TestSpeech.Services
{
    public class SpeechSynthesizerBroadCast : IBroadCast
    {
        private static SpeechSynthesizer _Instance;

        public SpeechSynthesizerBroadCast()
        {
            instance();
        }

        public void SetRate(int readSpeed)
        {
            _Instance.Rate = readSpeed;
        }

        public void Speak(string content)
        {
            _Instance.Speak(content);
        }

        public void Dispose()
        {
            _Instance.Dispose();
        }

        public static SpeechSynthesizer instance()
        {
            return _Instance ?? (_Instance = new SpeechSynthesizer());
        }
    }
}
