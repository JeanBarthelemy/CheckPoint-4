using System.Collections.Generic;

namespace Checkpoint4WPF
{
    public class Troupe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Artist> Artists { get; set; }

        public Troupe(string name)
        {
            Name = name;
        }

        public Troupe()
        {

        }
    }
}