using System;
using Microsoft.Speech.Recognition;
using System.Globalization;
using System.IO;
using Microsoft.Speech.Recognition.SrgsGrammar;
using System.Linq;

namespace Jarvis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(CultureInfo.CurrentCulture))
            {
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                // Configure input to the speech recognizer.  
                recognizer.SetInputToDefaultAudioDevice();

                string directoryPath = "D:\\Хранилище\\source\\Repos\\Jarvis\\Jarvis\\Grammars\\";

                var grammarPaths = Directory.GetFiles(directoryPath).Where(s=>s.EndsWith(".xml"));
                foreach (string grammarPath in grammarPaths)
                {
                    string filename = grammarPath.Substring(grammarPath.LastIndexOf('\\') + 1, grammarPath.IndexOf('.') - grammarPath.LastIndexOf('\\') -1);
                    FileStream stream = new FileStream(directoryPath + filename + ".cfg", FileMode.Create);
                    SrgsGrammarCompiler.Compile(grammarPath, stream);
                    stream.Close();

                    Grammar grammar = new Grammar(directoryPath + filename + ".cfg", filename);
                    recognizer.LoadGrammar(grammar);
                }


                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                // Keep the console window open.  
                while (true)
                {

                }
            }
        }

        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var words = e.Result.Words;
            foreach (var word in words)
                if(word.Confidence <= 0.3)
                {
                    Console.WriteLine("Простите, я вас не поняла");
                    return;
                }

            Console.WriteLine(e.Result.Text + "\t:" + e.Result.Confidence);

            Console.ForegroundColor= ConsoleColor.Yellow;
            foreach(var word in words )
                Console.WriteLine(word.LexicalForm + "\t:" + word.Confidence);
            Console.ResetColor();
            Console.WriteLine("\n\n");
        }        
    }
}
