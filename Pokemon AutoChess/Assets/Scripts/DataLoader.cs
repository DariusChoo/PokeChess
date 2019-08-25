using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    //Container to keep data
    public string[] units;

    //Point to where to start retrieving data
    //E.G: (Unit Name:)
    public string index2;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Extracts data from this page
        WWW UnitData = new WWW("http://localhost/PokeChess/UnitData.php");

        //Waits for downloading to finish before running further code
        yield return UnitData;

        //Displays all data retrieved in Console
        string UnitDataString = UnitData.text;
        print(UnitDataString);

        //Splits said data by semi colon - so it's separated by each row
        units = UnitDataString.Split(';');


        print(GetDataValue(units[0], index2));
    }

    string GetDataValue(string data, string index)
    {
        //First it gets the whole row of record in string form
        //Next it cuts it to a substring starting with index
        //Then it cuts off everything else from the point where | begins
        //Returns remainder substring
        string value = data.Substring(data.IndexOf(index) + index.Length);
        value = value.Remove(value.IndexOf("|"));
        return value;
    }
}
