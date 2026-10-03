using System;
using System.Collections.Generic;
using System.Text;
using Tests1.Storages.Builders;
using Tests1.Storages.Models;
using Tests1.Enums;

namespace Tests1.Storages.Builders
{
    public class StudentRegistrationBuilder
    {
        private readonly StudentRegistrationFormModel st = new();

        public StudentRegistrationBuilder WithName(string firstName, string lastName)
        {
            st.FirstName = firstName;
            st.LastName = lastName;
            return this;
        }

        public StudentRegistrationBuilder WithEmail(string email)
        {
            st.Email = email;
            return this;
        }

        public StudentRegistrationBuilder WithGender(GenderType gender)
        {
            st.Gender = gender;
            return this;
        }

        public StudentRegistrationBuilder WithMobileNumber(string mobileNumber)
        {
            st.MobileNumber = mobileNumber;
            return this;
        }

        public StudentRegistrationBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            st.DateOfBirth = dateOfBirth;
            return this;
        }

        public StudentRegistrationBuilder WithSubjects(params string[] subjects)
        {
            st.Subjects = subjects.ToList();
            return this;
        }
        public StudentRegistrationBuilder WithHobbies(params HobbyType[] hobbies)
        {
            st.Hobbies = hobbies.ToList();
            return this;
        }
        public StudentRegistrationBuilder WithPicture(string picturePath)
        {
            st.PicturePath = picturePath;
            return this;
        }
        public StudentRegistrationBuilder WithCurrentAddress(string address)
        {
            st.CurrentAddress = address;
            return this;
        }
        public StudentRegistrationBuilder WithStateAndCity(string state, string city)
        {
            st.State = state;
            st.City = city;
            return this;
        }
        public StudentRegistrationFormModel Build()
        {
            return st;
        }
    }
}
