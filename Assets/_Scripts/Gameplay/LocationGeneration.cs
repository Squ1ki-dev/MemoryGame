using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocationGenerator
{
    public static int[] Generate(int numPairs)
    {
        int[] locations = new int[numPairs * 2];
        for (int i = 0; i < numPairs; i++)
        {
            locations[2 * i] = i;
            locations[2 * i + 1] = i;
        }
        return locations;
    }
}