using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour
{

    public int _exp = 0;

    void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("people");

        for (var i = 0; i < data.Count; i++)
        {
            Debug.Log("index " + (i).ToString() + " : " + data[i]["x"] + " " + data[i]["y"]);
        }

    }
}