using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FieldConfig")]
public class FieldConfig : ScriptableObject
{
    public int Columns;
    public int Rows;
    public float Xspace;
    public float Yspace;
    public int NumPairs; // Adjust this number to the desired number of pairs

    public List<Sprite> images = new List<Sprite>();
}
