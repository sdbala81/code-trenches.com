using FluentBuilderPattern.Models;

namespace FluentBuilderPattern.Builder;

public class GuidedCustomerBuilder
{
    private int _birthYear;
    private string _firstName;
    private string _lastName;


    public static RequiredFirstName Create()
    {
        return new RequiredFirstName(new GuidedCustomerBuilder());
    }


    public class RequiredFirstName
    {
        private readonly GuidedCustomerBuilder _builder;

        public RequiredFirstName(GuidedCustomerBuilder builder)
        {
            _builder = builder;
        }

        public RequiredLastName WithFirstName(string firstName)
        {
            return new RequiredLastName(firstName);
        }
    }

    public class RequiredLastName
    {
        private readonly GuidedCustomerBuilder _builder;
        private readonly string _firstName;

        public RequiredLastName(string firstName)
        {
            _firstName = firstName;
        }

        public RequiredBirthYear WithLastName(string lastName)
        {
            return new RequiredBirthYear(_firstName, lastName);
        }
    }

    public class RequiredBirthYear
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private int? _birthYear;

        public RequiredBirthYear(string firstName, string surname)
        {
            _firstName = firstName;
            _lastName = surname;
        }

        public RequiredBirthYear BornIn(int birthYear)
        {
            _birthYear = birthYear;
            return this;
        }

        public Customer Build()
        {
            return new Customer
            {
                FirstName = _firstName,
                LastName = _lastName,
                BirthYear = _birthYear
            };
        }
    }
}