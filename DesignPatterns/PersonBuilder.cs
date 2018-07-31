using System;
using System.Collections.Generic;
using System.Text;

namespace PersonClasses
{
    public class PersonBuilder
    {
        protected Person person;
        public PersonBuilder(string firstName, string lastName, int age)
        {
            person = new Person(firstName, lastName, age);
        }

        protected PersonBuilder()
        {

        }

        public AddressBuilder Address => new AddressBuilder(person);
        public HobbiesBuilder Hobbies => new HobbiesBuilder(person);

        public static implicit operator Person(PersonBuilder personBuilder)
        {
            return personBuilder.person;
        }
    }
}
