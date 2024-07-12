namespace FluentBuilderPattern.Builder;

public class GuidedActorBuilder
{
    public class Step1
    {
        private readonly GuidedActorBuilder _builder;

        public Step1(GuidedActorBuilder builder)
        {
            _builder = builder;
        }

        public Step2 WithFirstName(string firstName)
        {
            _builder._firstName = firstName;
            return new Step2(_builder);
        }
    }

    public class Step2
    {
        private readonly GuidedActorBuilder _builder;

        public Step2(GuidedActorBuilder builder)
        {
            _builder = builder;
        }

        public Step3 WithLastName(string lastName)
        {
            _builder._lastName = lastName;
            return new Step3(_builder);
        }
    }

    public class Step3
    {
        private readonly GuidedActorBuilder _builder;

        public Step3(GuidedActorBuilder builder)
        {
            _builder = builder;
        }

        public Step3 BornIn(int birthYear)
        {
            _builder._birthYear = birthYear;
            return this;
        }

        public Actor Build()
        {
            return new Actor
            {
                FirstName = _builder._firstName,
                LastName = _builder._lastName,
                BirthYear = _builder._birthYear
            };
        }
    }

    private string _firstName;
    private string _lastName;
    private int _birthYear;

    public static Step1 Create()
    {
        return new Step1(new GuidedActorBuilder());
    }
}

public class Actor
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int BirthYear { get; set; }
}
