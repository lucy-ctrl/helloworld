using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.Threading.Tasks;

namespace helloworld
{
    class Program
    {
        public static async Task RecognizeSpeech()
        {
            var speechConfig = SpeechConfig.FromSubscription("0b3abd1c585b4403a373e6b862099949", "uksouth");
            using var recognizer = new SpeechRecognizer(speechConfig);


            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recgonizer = new SpeechRecognizer(speechConfig, audioConfig);

            var result = await recognizer.RecognizeOnceAsync();

            if (result.Reason == ResultReason.RecognizedSpeech)
            {
                if (result.Text == "Red")
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"RECOGNIZED: Text={result.Text}");
                }
                else
                {
                    if (result.Text == "Blue")
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"RECOGNIZED: Text={result.Text}");
                    }
                }
            }

        }

        static async Task Main()
        {
            await RecognizeSpeech();
        }
    }

   

}
