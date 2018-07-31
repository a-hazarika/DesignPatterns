using System;
using System.Collections.Generic;
using System.Text;

namespace PersonClasses
{
    public class HobbiesBuilder : PersonBuilder
    {
        public HobbiesBuilder(Person person)
        {
            this.person = person;
        }

        public HobbiesBuilder Likes(string hobby)
        {
            person.HobbiesList.Add(hobby);

            return this;
        }
    }
}
