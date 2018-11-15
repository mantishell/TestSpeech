using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using TestSpeech.Services;

namespace TestSpeech
{
    public partial class Form1 : Form
    {
        private static readonly IBroadCast _iBroadCast = new SpeechSynthesizerBroadCast();

        public Form1()
        {
            InitializeComponent();
            textContent.Text = "http://mozilla.com.cn/forum.php?mod=viewthread&tid=409003";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            //方式1
            //var str = textContent.Text.Trim();
            //_iBroadCast.Speak(string.IsNullOrEmpty(str)?"小娜小娜，呼叫小娜":str);
            //方式2
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                synth.SetOutputToDefaultAudioDevice();
                var str = textContent.Text.Trim();
                synth.Speak(string.IsNullOrEmpty(str) ? "小娜小娜，呼叫小娜" : str);
            }

            //读取网页的文字
            //WebBrowser web = new WebBrowser();
            //var str = textContent.Text.Trim();
            //try {
            //    web.Navigate(str);
            //    web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
            //}catch(Exception ex)
            //{

            //}
            
        }

        void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser web = (WebBrowser)sender;
            HtmlElement element = web.Document.GetElementById("content");
            HtmlElementCollection table = element.GetElementsByTagName("table");
            
            //MessageBox.Show(element.InnerText);

            foreach (HtmlElement item in table)
            {
                //MessageBox.Show(item.InnerText);
                if (!string.IsNullOrEmpty(item.InnerText))
                {
                    _iBroadCast.Speak(item.InnerText);
                }
            }
        }
    }
}
