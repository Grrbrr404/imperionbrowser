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
        Terran,
        Xen,
        Titan
    }

    public enum PlanetType
    {
        Gas = 1,
        Ice = 2,
        Water = 3,
        Earth = 4,
        Desert = 5,
        Vulcan = 6
    }

    public enum MissionTypes
    {
        Attack = 301,
        Raid = 302,
        Support = 303,
        Spy = 304,
        HoldPosition = 306,
        Colonize = 307
    }
}
