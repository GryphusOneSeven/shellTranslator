namespace ShellTranslator {
    class CriticalCharLimitException : Exception {
        public CriticalCharLimitException()
        {
        }

        public CriticalCharLimitException(string message)
            : base(message)
        {
        }
    }
}