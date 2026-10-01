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

        // Add more methods for other properties as needed
        public StudentRegistrationFormModel Build()
        {
            return st;
        }
    }
