using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    //Container to keep data
    public string[] units;

    //Point to where to start retrieving data
    //E.G: (Unit Name:)
    string getName = "Unit Name:";
    string getCost = "Unit Cost:";
    string getSynergy = "Unit Synergy:";
    string getSynergy2 = "Unit Second Synergy:";
    string getHP = "Unit Health Points:";
    string getMana = "Unit Mana Points:";
    string getAbility = "Unit Ability:";
    string getAttackSpeed = "Unit Attack Speed:";
    string getDamage = "Unit Damage:";
    string getArmor = "Unit Armor:";
    string name = "";

    //Variables to get stats
    public string unitName;
    public int cost;
    public string synergy;
    public string synergy2;
    public int HP;
    public int mana;
    public string ability;
    public int attackSpeed;
    public int damage;
    public int armor;

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
        GetStatsOfCurrentUnit();
        //print(GetDataValue(units[0], index2));
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

    void GetStatsOfCurrentUnit()
    {
        print("Ran this method");
        //what is the current unit?
        name = gameObject.tag;
        print(name);

        //find which element based on unitName
        for (int i = 0; i < units.Length-1; i++)
        {
            print(GetDataValue(units[i], getName));
            if (GetDataValue(units[i], getName).Equals(name))
            {
                unitName = GetDataValue(units[i], getName);
                print(getCost.Length + " " + units[i]);
                cost = int.Parse(GetDataValue(units[i], getCost));
                synergy = GetDataValue(units[i], getSynergy);
                synergy2 = GetDataValue(units[i], getSynergy2);
                HP = int.Parse(GetDataValue(units[i], getHP));
                mana = int.Parse(GetDataValue(units[i], getMana));
                ability = GetDataValue(units[i], getAbility);
                attackSpeed = int.Parse(GetDataValue(units[i], getAttackSpeed));
                damage = int.Parse(GetDataValue(units[i], getDamage));
                armor = int.Parse(GetDataValue(units[i], getArmor));
            }
        }
        print("found Element based on name");


    }
}
