using DeepL;
using System.IO;

namespace ShellTranslator {
    class DeepLTranslator {
        String TargetLang;
        FileInfo? InputFile;
        FileInfo? OutputFile;
        bool DocumentSet;
        Translator? translator1;
        String[] Languages = {"BG", "CS", "DA", "DE", "EL", "EN", "ES", "ET", "FI", "FR", "HU", "ID", "IT", "JA", "KO", "LT", "LV", "NB", "NL", "PL", "PT", "RO", "RU", "SK", "SL", "SV", "TR", "UK", "ZH"};
        String[] Extensions = {"docx", "pptx", "pdf", "html", "htm", "txt", "xlf"};
        public DeepLTranslator() { 
            TargetLang = string.Empty;
            InputFile = null;
            OutputFile = null;
            DocumentSet = false;
            translator1 = null;
        }

        private void SetFiles(List<string> args, int i) {
            DocumentSet = true;
            InputFile = new FileInfo(args.ElementAt(i + 1));
            OutputFile = new FileInfo(args.ElementAt(i + 2));
            string[] tmp1 = InputFile.ToString().Split(".");
            string[] tmp2 = OutputFile.ToString().Split(".");
            if (!Extensions.Contains(tmp1[1]) || !Extensions.Contains(tmp2[1]))
                throw new FileExtensionException("File is not a supported format");
        }

        public void ParseArgs(string[] args) {
            List<string> argsList = new List<string>(args);

            if (!Languages.Contains(argsList.ElementAt(0).ToUpper()))
                throw new IncorrectLanguageException("Error : Incorrect target language!");
            else {
                TargetLang = argsList.ElementAt(0).ToUpper();
                argsList.RemoveAt(0);
            }

            for (int j = 0; j < argsList.Count(); j++) {
                if (argsList.ElementAt(j) == "-d" && DocumentSet == false) {
                    SetFiles(argsList, j);
                }
            }
        }

        public async Task Launch() {
            Console.WriteLine("Target language set to : " + TargetLang);
            var authKey = "ENTER YOUR API KEY";
            translator1 = new Translator(authKey);
            var usage = await translator1.GetUsageAsync();
            if (usage.Character == null)
                throw new NullReferenceException();
            if (usage.Character.Count >= 450000)
                throw new CriticalCharLimitException("Limit of 450,000 characters exceeded");
            Console.WriteLine((500000 - usage.Character.Count) + " characters left for this API key");
            while (!DocumentSet) {
                String? input = Console.ReadLine();
                if (input == string.Empty || input == null) {
                    continue;
                }
                var translatedText = await translator1.TranslateTextAsync(input, null, TargetLang);
                Console.WriteLine("Translated text from [" + translatedText.DetectedSourceLanguageCode.ToUpper() + "] to [" + TargetLang + "]");
                Console.WriteLine(translatedText);
            }
            if (DocumentSet && InputFile != null && OutputFile != null) {
                try {
                    Console.WriteLine("Translating file...");
                    await translator1.TranslateDocumentAsync(InputFile, OutputFile, null, TargetLang);
                    Console.WriteLine("Translated file to [" + OutputFile.Name + "]");
                } catch (DocumentTranslationException ex) {
                    Console.WriteLine("Error occurred during document upload: " + ex.Message);
                }
            }
        }
    }
}