using System;

namespace EQW {
    public class ProfileExistsException : Exception {
        public ProfileExistsException(string message) : base(message) { }
        public ProfileExistsException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
