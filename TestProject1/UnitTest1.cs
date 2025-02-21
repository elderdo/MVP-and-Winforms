using ClassLibrary1;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FirstNameIsNotEmpty()
        {
            var user = new DummyUser();
            var presenter = new UserInfoPresenter(user);
            user.Email = "Bob@";
            user.Save();
            Assert.AreEqual(expected: null, actual: user.FirstName, message: "The FirstName field should be initialized as null");
            Assert.IsTrue(user.ShowFormErrors, "Null first name should trigger validation error");
            Assert.AreEqual(expected: "\nFirst Name cannot be empty", actual: user.ErrorMessage, "Empty FirstName should have correct error msg");

            user.FirstName = "Bob";
            user.Save(); // save is our only trigger for validation right now
            Assert.AreEqual(expected: "Bob", actual: user.FirstName, message: "The FirstName must be set to a value to remove error");
            Assert.IsFalse(condition: user.ShowFormErrors, message: "A filled in FirstName should not trigger an error");
            Assert.AreEqual(expected: null, actual: user.ErrorMessage, "Filled in first name should remove error message");


        }

        [TestMethod]
        public void EmailIsNotEmpty()
        {
            var user = new DummyUser();
            var presenter = new UserInfoPresenter(user);
            user.FirstName = "Bob";
            user.Save();
            Assert.AreEqual(expected: null, actual: user.Email, message: "The Email field should be initialized as null");
            Assert.IsTrue(user.ShowFormErrors, "Null Email should trigger validation error");
            Assert.AreEqual(expected: "\nEmail cannot be empty", actual: user.ErrorMessage, "Empty Email should have correct error msg");

            user.Email = "Bob@";
            user.Save(); // save is our only trigger for validation right now
            Assert.AreEqual(expected: "Bob@", actual: user.Email, message: "The Email must be set to a value to remove error");
            Assert.IsFalse(condition: user.ShowFormErrors, message: "An appropriate filled in Email should not trigger an error");
            Assert.AreEqual(expected: null, actual: user.ErrorMessage, "Filled in Email should remove error message");


        }

        [TestMethod]
        public void EmailHasAtSymbol()
        {
            var user = new DummyUser();
            var presenter = new UserInfoPresenter(user);
            user.FirstName = "Bob";
            user.Email = "Bob";
            user.Save();
            Assert.AreEqual(expected: "Bob", actual: user.Email, message: "The Email field should be initialized as 'Bob'");
            Assert.IsTrue(user.ShowFormErrors, "Invalid Email should trigger validation error");
            Assert.AreEqual(expected: "\nEmail must contain @ symbol", actual: user.ErrorMessage, "Empty Email should have correct error msg");

            user.Email = "Bob@";
            user.Save(); // save is our only trigger for validation right now
            Assert.AreEqual(expected: "Bob@", actual: user.Email, message: "The Email must be set to a value to remove error");
            Assert.IsFalse(condition: user.ShowFormErrors, message: "A filled in Email should not trigger an error");
            Assert.AreEqual(expected: null, actual: user.ErrorMessage, "Filled in Email should remove error message");


        }

    }

    /// <summary>
    /// This class is a mock implementation of the IUserInfo interface.
    /// It is used to simulate the behavior of a user form in the WinFormApp1 project.
    /// </summary>
    class DummyUser : IUserInfo
    {
        /// <summary>
        /// Gets or sets the first name of the user.
        /// This property maps to the FirstName input field on Form1.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// This property maps to the LastName input field on Form1.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// This property maps to the Email input field on Form1.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// This property maps to the Phone input field on Form1.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the error message to be displayed.
        /// This property is used to show validation errors on Form1.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether form errors should be shown.
        /// This property is used to control the visibility of validation errors on Form1.
        /// </summary>
        public bool ShowFormErrors { get; set; }

        /// <summary>
        /// Event that is triggered when the Save method is called.
        /// This event is used to simulate the save button click on Form1.
        /// </summary>
        public event EventHandler? SaveAttempted;

        /// <summary>
        /// Simulates the save action on Form1.
        /// This method is non-functional but implemented to comply with the IUserInfo interface.
        /// It triggers the SaveAttempted event to allow unit tests to handle the save action.
        /// </summary>
        public void Save() => SaveAttempted?.Invoke(this, EventArgs.Empty);
    }
}