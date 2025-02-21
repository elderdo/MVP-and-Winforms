namespace WinFormsApp1
{
    /// <summary>
    /// Represents the main form of the application which implements the IUserInfo interface.
    /// </summary>
    public partial class Form1 : Form, IUserInfo
    {
        private UserInfoPresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        /// <remarks>
        /// The presenter is injected here and it will get invoked by the events triggered by the form.
        /// </remarks>
        public Form1()
        {
            InitializeComponent();
            this._presenter = new UserInfoPresenter(this);
        }

        /// <summary>
        /// Handles the click event of the Save button.
        /// </summary>
        private void Save_Click(object sender, EventArgs e)
        {
            SaveAttempted?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc/>
        string IUserInfo.FirstName { get => this.FirstName.Text; set => this.FirstName.Text = value; }

        /// <inheritdoc/>
        string IUserInfo.LastName { get => this.LastName.Text; set => this.LastName.Text = value; }

        /// <inheritdoc/>
        string IUserInfo.Email { get => this.Email.Text; set => this.Email.Text = value; }

        /// <inheritdoc/>
        string IUserInfo.Phone { get => this.Phone.Text; set => this.Phone.Text = value; }

        /// <inheritdoc/>
        string IUserInfo.ErrorMessage { get => this.ErrorMessage.Text; set => this.ErrorMessage.Text = value; }

        /// <inheritdoc/>
        bool IUserInfo.ShowFormErrors { get => this.ErrorMessage.Visible; set => this.ErrorMessage.Visible = value; }

        /// <summary>
        /// Occurs when a save attempt is made.
        /// </summary>
        public event EventHandler? SaveAttempted;
    }
    /// <summary>
    /// Represents the presenter that handles the interaction between the view and the model.
    /// </summary>
    public class UserInfoPresenter
    {
        private readonly IUserInfo _form;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoPresenter"/> class.
        /// </summary>
        /// <param name="form">The form that implements the <see cref="IUserInfo"/> interface.</param>
        public UserInfoPresenter(IUserInfo form)
        {
            _form = form;
            _form.SaveAttempted += _form_SaveAttempted;
        }

        /// <summary>
        /// Handles the SaveAttempted event of the form.
        /// </summary>
        private void _form_SaveAttempted(object? sender, EventArgs e)
        {
            // Handle save logic here
        }
    }
    /// <summary>
    /// Interface representing user information.
    /// Must have all the inputs that Form1 has as well as any major event that Form1 may trigger as an app.
    /// </summary>
    public interface IUserInfo
    {
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show form errors.
        /// </summary>
        bool ShowFormErrors { get; set; }

        /// <summary>
        /// Occurs when a save attempt is made.
        /// </summary>
        event EventHandler? SaveAttempted;
    }
}