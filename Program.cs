namespace ShellTranslator {
    class Program {

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
            } catch (CriticalCharLimitException) {
                Console.WriteLine("API Access has reached a critical character limit");
                return -1;
            } catch (NullReferenceException nre) {
                Console.WriteLine(nre.Message);
                return -1;
            }
            DTranslator.Launch().Wait();
            return 0;
        }
    }
}
