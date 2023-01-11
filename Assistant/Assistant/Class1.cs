//using Microsoft.Speech.Recognition;
//using Microsoft.Speech.Recognition.SrgsGrammar;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Jarvis
//{
//    internal class Class1
//    {
//        static void Main()
//        {
//            //Создаем распознаватель с русской локализацией
//            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("ru-RU"));

//            string grammarPath = @"";
//            //Компилируем наше грамматическое правило в файл Маршруты.cfg
//            FileStream fs = new FileStream(grammarPath + "Маршруты.cfg", FileMode.Create);
//            SrgsGrammarCompiler.Compile(grammarPath + "Маршруты.grxml", (Stream)fs);
//            fs.Close();

//            Grammar gr = new Grammar(grammarPath + " Маршруты.cfg", "Маршруты");

//            //Загружаем скомпилированный файл грамматики
//            sre.LoadGrammar(gr);

//            //Подписываемся на событие распознавания
//            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);

//            //Пусть голос поступает с устройства по умолчанию
//            sre.SetInputToDefaultAudioDevice();

//            //Запускаем асинхронно распознаватель
//            sre.RecognizeAsync(RecognizeMode.Multiple);

//            //Процедура распознавания
//            void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
//            {
//                //Распознанная фраза
//                string recoString = e.Result.Text;
//                //Имя команды
//                string cmdName = e.Result.Semantics["cmd"].Value.ToString();
//                //Точка А маршрута
//                string pointA = e.Result.Semantics["from"].Value.ToString();
//                //Точка Б маршрута
//                string pointB = e.Result.Semantics["to"].Value.ToString();
//                //Показываем сообщение
//                MessageBox.Show($"Маршрут от точки А: {pointA} до точки Б: {pointB}");
//            }
//        }
//    }
//}
