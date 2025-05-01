using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using This2ThatConverter.Services.Interfaces;

namespace This2ThatConverter.Services
{
    public class SpeechToTextService : ISpeechToTextService
    {
        private readonly string _speechKey;
        private readonly string _speechRegion;
        private static StringBuilder _recognizedText = new();
        private static bool _isListening = false;

        public SpeechToTextService()
        {
            _speechKey = Environment.GetEnvironmentVariable("SPEECH_KEY", EnvironmentVariableTarget.Machine)
                ?? throw new InvalidOperationException("SPEECH_KEY not found.");
            _speechRegion = Environment.GetEnvironmentVariable("SPEECH_REGION", EnvironmentVariableTarget.Machine)
                ?? throw new InvalidOperationException("SPEECH_REGION not found.");
        }

        public async Task<string> ToggleListeningAsync()
        {
            var speechConfig = SpeechConfig.FromSubscription(_speechKey, _speechRegion);
            speechConfig.SpeechRecognitionLanguage = "en-US";

            using var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            using var recognizer = new SpeechRecognizer(speechConfig, audioConfig);

            var result = await recognizer.RecognizeOnceAsync();

            return result.Reason switch
            {
                ResultReason.RecognizedSpeech => result.Text,
                ResultReason.NoMatch => "No speech recognized.",
                ResultReason.Canceled => $"Canceled: {CancellationDetails.FromResult(result).ErrorDetails}",
                _ => "Unknown error"
            };
        }

    }
}
