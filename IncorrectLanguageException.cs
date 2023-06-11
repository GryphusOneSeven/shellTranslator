namespace ShellTranslator {
    class IncorrectLanguageException : Exception {
        public IncorrectLanguageException()
        {
        }

        public IncorrectLanguageException(string message)
            : base(message)
        {
        }
    }
}