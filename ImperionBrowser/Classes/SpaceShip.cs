using System;
using System.Collections.Generic;
using System.Text;

namespace ImperionBrowser
{
    public class SpaceShip
    {
        protected float _shell;
        protected float _shellStrength;
        protected float _laserCount;
        protected float _laserPower;
        protected float _energyUpkeep;
        protected float _speed;
        protected float _payload;
        protected float _fuelConsumption;
        protected Resources _costs = new Resources();
    }
}
