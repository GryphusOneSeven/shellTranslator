using DeepL;

namespace ShellTranslator {
    class Program {
/*
        static int Main(string[] args) {
            DeepLTranslator DTranslator = new DeepLTranslator();
            try {
                DTranslator.ParseArgs(args);
            } catch (IncorrectLanguageException ile) {
                Console.WriteLine(ile.Message);
                return -1;
            } catch (FileExtensionException fee) {
                Console.WriteLine(fee.Message);
                return -1;
            } catch (ArgumentOutOfRangeException) {
                Console.WriteLine("Missing output file");
                return -1;
            }
            DTranslator.Launch();
            return 0;
        }
*/
        static async void bidule() {
            try {
                var options = new TranslatorOptions {
                    appInfo =  new AppInfo { AppName = "shellTranslator", AppVersion = "0.1"}
                };
                var translator = new Translator("084251f6-d351-f52c-c71a-4827ad592ffb:fx", options);
                Console.WriteLine("uuuh");
                var translatedText = await translator.TranslateTextAsync(
                    "Hello, world!",
                    LanguageCode.English,
                    LanguageCode.French);
                Console.WriteLine(translatedText);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }


        static void Main(string[] args) {
            bidule();
        }
    }
}
