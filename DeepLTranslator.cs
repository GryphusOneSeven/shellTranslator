using DeepL;

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
//            Console.WriteLine(InputFile);
//            Console.WriteLine(OutputFile);
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

        public async void Launch() {
            Console.WriteLine("Target language set to : " + TargetLang);
            var authKey = "084251f6-d351-f52c-c71a-4827ad592ffb:fx";
            translator1 = new Translator(authKey);
            while (true) {
                String? input = Console.ReadLine();
                if (input == string.Empty || input == null) {
                    continue;
                }
                var translatedText = await translator1.TranslateTextAsync(input, null, TargetLang);
                Console.WriteLine("Translated text from [" + translatedText.DetectedSourceLanguageCode + "] to [" + TargetLang + "]");
                Console.WriteLine(translatedText);
            }
        }
    }
}