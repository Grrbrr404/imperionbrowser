using System;
using System.Collections.Generic;
using System.Text;

namespace ImperionBrowser
{
    public enum TerranSpaceShip
    {
        ssSonde = 1,
        ssJaeger = 5,
        ssSchlachtschiff = 10,
        ssZerstoerer = 6,
        ssSchwererKreuzer = 11,
        ssPulsar = 7,
        ssBomber = 9,
        ssTankSchiff = 8,
        ssKleinerTransporter = 2,
        ssGrosserRecycler = 3,
        ssRecycler = 4,
        ssKolonieschiff = 12
    }

    public enum XenSpaceShip
    {
        xsSonde = 1,
        xsJaeger = 8,
        xsSchlachtschiff = 5,
        xsZerstoerer = 2,
        xsSchwererKreuzer = 10,
        xsPulsar = 11,
        xsBomber = 3,
        xsTankSchiff = 6,
        xsKleinerTransporter = 7,
        xsGrosserRecycler = 9,
        xsRecycler = 4,
        xsKolonieschiff = 12
    }


    public enum RaceTypes
    {
        rtTerran,
        rtXen,
        rtTitan
    }

    public enum PlanetType
    {
        ptGas = 1,
        ptIce = 2,
        ptWater = 3,
        ptEarth = 4,
        ptDesert = 5,
        ptVulcan = 6
    }

    public enum MissionTypes
    {
        mtAttack = 301,
        mtRaid = 302,
        mtSupport = 303,
        mtSpy = 304,
        mtHoldPosition = 306,
        mtColonize = 307
    }
}
