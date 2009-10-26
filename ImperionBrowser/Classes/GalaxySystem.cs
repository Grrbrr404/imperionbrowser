using System;
using System.Collections.Generic;
using System.Text;

namespace ImperionBrowser
{
    public class GalaxySystem
    {
        public string _system_id = String.Empty;
        
        private List<Planet> _Planets = new List<Planet>();
        private List<Comet> _Comets = new List<Comet>();
        private List<Debris> _Debris = new List<Debris>();
        

        public GalaxySystem(string iSystemId) 
        {
            _system_id = iSystemId;
        }

        /// <summary>
        /// Search System for a planet id
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Planet this[string index]
        {
            get 
            {
                return _Planets.Find(delegate(Planet p) { return p._planet_id == index; });
            }
            set {  }
        }

        public List<Planet> Planets
        {
            get { return _Planets; }
        }

        public List<Debris> Debris
        {
            get { return _Debris; }
        }

        public List<Comet> Comets
        {
            get { return _Comets; }
        }

        

    }
}
