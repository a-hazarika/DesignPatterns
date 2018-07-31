using System;
using System.Collections.Generic;
using System.Text;

namespace PersonClasses
{
    public class AddressBuilder : PersonBuilder
    {
        public AddressBuilder(Person person)
        {
            this.person = person;
        }

        public AddressBuilder LivesAt(string streetName)
        {
            person.StreetName = streetName;

            return this;
        }

        public AddressBuilder AtZipCode(string zipCode)
        {
            person.ZipCode = zipCode;

            return this;
        }
    }
}
