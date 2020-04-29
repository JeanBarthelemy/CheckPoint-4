using System;

namespace Checkpoint4WPF
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Specialty { get; set; }
        public Troupe Troupe { get; set; }

        public Artist(string name, int age,  string specialty, Troupe troupe)
        {
            Name = name;
            Age = age;
            Specialty = specialty;
            Troupe = troupe;

        }

        public Artist()
        {

        }
    }
}