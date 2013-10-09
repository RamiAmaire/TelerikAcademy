namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string AdditionalInformation { get; set; }

        /// <remarks>
        ///     I had a dilemma should isOlderThan take student or date time and decided that when
        ///     comparing people's age this is the more appropriate way. peter.isOlderThan(1989, 09, 23)
        ///     is illogical. We tend to compare our age with other people's age not a date. (same with
        ///     other attributes :P)
        /// </remarks>
        /// <param name="other">The other student</param>
        /// <returns>true if older than, false if not.</returns>
        public bool IsOlderThan(Student other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Other student object cannot be null");
            }

            DateTime currentStudentBirthDate = this.BirthDate;
            DateTime otherStudentBirthDate = other.BirthDate;
            bool isOlder = currentStudentBirthDate < otherStudentBirthDate;

            return isOlder;
        }
    }
}
