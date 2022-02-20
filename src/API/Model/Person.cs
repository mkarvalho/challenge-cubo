using System;
using UUIDNext;

namespace API.Model
{
    public class Person
    {
        public Guid Id { get; private set; } 
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public float Participation { get; private set; }

        public Person()
        {
        }

        public Person(string name, string lastName, float participation)
        {
            Id = Uuid.NewDatabaseFriendly();
            Name = name;
            LastName = lastName;
            Participation = participation;
        }

    }   

}
