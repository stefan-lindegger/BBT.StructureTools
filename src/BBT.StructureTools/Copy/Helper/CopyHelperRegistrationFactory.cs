namespace BBT.StructureTools.Copy.Helper
{
    /// <summary>
    /// Factory to create an instance of CopyHelperRegistration.
    /// </summary>
    internal class CopyHelperRegistrationFactory : ICopyHelperRegistrationFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CopyHelperRegistrationFactory"/> class.
        /// </summary>
        public CopyHelperRegistrationFactory()
        {
        }

        /// <summary>
        /// Creates an instance of CopyHelperRegistration.
        /// </summary>
        /// <typeparam name="T">Creation type.</typeparam>
        /// <returns>Created instance of CopyHelperRegistration.</returns>
        public IInternalCopyHelperRegistration<T> Create<T>()
            where T : class
        {
            return new CopyHelperRegistration<T>();
        }
    }
}