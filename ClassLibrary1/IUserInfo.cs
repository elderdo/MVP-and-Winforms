namespace ClassLibrary1
{
    /// <summary>
    /// Interface representing user information.
    /// Must have all the inputs that Form1 has as well as any major event that Form1 may trigger as an app.
    /// </summary>
    public interface IUserInfo
    {
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show form errors.
        /// </summary>
        public bool ShowFormErrors { get; set; }

        /// <summary>
        /// Event triggered when a save attempt is made.
        /// </summary>
        public event EventHandler SaveAttempted;
    }
}