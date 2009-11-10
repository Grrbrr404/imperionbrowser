using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ImperionBrowser
{

    public class TSonde : SpaceShip
    {
        public TSonde()
        {
            _shell = 320;
            _shellStrength = 0;
            _laserCount = 1;
            _laserPower = 1;
            _speed = 200;
            _payload = 0;
            _fuelConsumption = 1;
            _energyUpkeep = 4;
        }
    }

    public class TTransporter : SpaceShip
    {
        public TTransporter()
        {
            _shell = 720;
            _shellStrength = 5;
            _laserCount = 1;
            _laserPower = 1;
            _speed = 9;
            _payload = 2000;
            _fuelConsumption = 11;
            _energyUpkeep = 9;
 
        }
    }

    public class TRecycler : SpaceShip
    {
        public TRecycler()
        {
            _shell = 320;
            _shellStrength = 5;
            _laserCount = 1;
            _laserPower = 1;
            _speed = 12;
            _payload = 600;
            _fuelConsumption = 20;
            _energyUpkeep = 6;
        }
    }

    public class TBigRecycler : SpaceShip
    {
        public TBigRecycler()
        {
            _shell = 2000;
            _shellStrength = 30;
            _laserCount = 28;
            _laserPower = 60;
            _speed = 6;
            _payload = 20000;
            _fuelConsumption = 180;
            _energyUpkeep = 93;
        }
    }

    public class TTankschiff : SpaceShip
    {
        public TTankschiff()
        {
            _shell = 1200;
            _shellStrength = 3;
            _laserCount = 1;
            _laserPower = 1;
            _speed = 9;
            _payload = 0;
            _fuelConsumption = 20;
            _energyUpkeep = 15;
        }
    }

    public class TJaeger : SpaceShip
    {
        public TJaeger()
        {
            _shell = 70;
            _shellStrength = 0;
            _laserCount = 5;
            _laserPower = 18;
            _speed = 14;
            _payload = 60;
            _fuelConsumption = 1;
            _energyUpkeep = 1;
        }
    }

    public class TZerstoerer : SpaceShip
    {
        public TZerstoerer()
        {
            _speed = 10;
        }
    }

    public class TPulsar : SpaceShip
    {
        public TPulsar()
        {
            _speed = 4;
        }
    }

    public class TBomber : SpaceShip
    {
        public TBomber()
        {
            _speed = 3;
        }
    }

    public class TSchlachtschiff : SpaceShip
    {
        public TSchlachtschiff()
        {
            _speed = 15;
        }
    }

    public class TSchwererKreuzer : SpaceShip
    {
        public TSchwererKreuzer()
        {
            _speed = 8;
        }
    }

}
