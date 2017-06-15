using Sollicitatiebeheer.Model.Shared;

namespace Sollicitatiebeheer.Model.Afdelingen
{
    public class AfdelingBuilder
    {
        private int _id;
        private string _naam;

        public Afdeling Build()
        {
            return new Afdeling
            {
                Naam = _naam
            };
        }

        public AfdelingBuilder MetId(int id)
        {
            _id = id;
            return this;
        }

        public AfdelingBuilder MetNaam(string naam)
        {
            _naam = naam;
            return this;
        }
    }
}
