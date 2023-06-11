namespace ShellTranslator {
    class FileExtensionException : Exception {
        public FileExtensionException()
        {
        }

        public FileExtensionException(string message)
            : base(message)
        {
        }
    }
}