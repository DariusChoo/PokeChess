using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    //Container to keep data
    public string[] units;
    public string[] ranks;
    public string[] abilities;

    //Point to where to start retrieving data from Unit Data
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

    //Point to where to start retrieving data from Rank Data
    string getRankName = "Rank Name:";
    string getRankEXP = "Rank EXP:";

    //Point to where to start retrieving data from Ability Data
    string getAbilityName = "Ability Name:";
    string getAbilitySingleTarget = "Ability Single Target:";
    string getAbilityAOE = "Ability AOE:";
    string getAbilityDamage = "Ability Damage:";
    string getAbilityType = "Ability Type:";
    string getAbilityLevel = "Ability Level:";

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

    //Variables to get ranks
    public string rankName;
    public int rankEXP;

    //Variables to get abilities
    public string abilityName;
    public bool abilitySingleTarget;
    public bool abilityAOE;
    public int abilityDamage;
    public string abilityType;
    public int abilityLevel;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Extracts data from this page
        WWW UnitData = new WWW("http://localhost/PokeChess/UnitData.php");
        WWW RankData = new WWW("http://localhost/PokeChess/RankData.php");
        WWW AbilityData = new WWW("http://localhost/PokeChess/AbilityData.php");

        //Waits for downloading to finish before running further code
        yield return UnitData;
        yield return RankData;
        yield return AbilityData;

        //Displays all data retrieved in Console
        string UnitDataString = UnitData.text;
        string RankDataString = RankData.text;
        string AbilityDataString = AbilityData.text;
        print(UnitDataString+"\n\n"+RankDataString+"\n\n"+AbilityDataString);

        //Splits said data by semi colon - so it's separated by each row
        units = UnitDataString.Split(';');
        ranks = RankDataString.Split(';');
        abilities = AbilityDataString.Split(';');

        //Calls Method that prints the stats of Unit this is assigned to
        GetStatsOfCurrentUnit();
        GetAbilities();
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

    //Will be changed in the future
    //Checks which User
    //Gets the EXP of the User
    //Compares it to Rank Data to get Rank of User
    void GetRank()
    {

    }

    //Checks which Unit it is
    //Retrieves Ability data
    void GetAbilities()
    {
        //Check if GetAbilities called
        print("Get Abilities called");

        //find which element based on unitName
        for (int i = 0; i < abilities.Length - 1; i++)
        {
            //Checks if ability name retrieved equals the ability of the gameObject
            //Retrieves Data and assigns to individual variables
            //For boolean values, it checks if 1 (true) or 0 (false)
            if (GetDataValue(abilities[i], getAbilityName).Equals(ability))
            {
                abilityName = GetDataValue(abilities[i], getAbilityName);
                if (GetDataValue(abilities[i], getAbilityAOE) == "1")
                    abilityAOE = true;
                else
                    abilityAOE = false;
                if (GetDataValue(abilities[i], getAbilitySingleTarget) == "1")
                    abilitySingleTarget = true;
                else
                    abilitySingleTarget = false;
                abilityDamage = int.Parse(GetDataValue(abilities[i], getAbilityDamage));
                abilityType = GetDataValue(abilities[i], getAbilityType);
                abilityLevel = int.Parse(GetDataValue(abilities[i], getAbilityLevel));
            }
        }
    }

    //Retrieves stats of the Pokemon
    void GetStatsOfCurrentUnit()
    {
        //Debugging purposes
        //print("Ran this method");

        //what is the current unit?
        name = gameObject.tag;
        //print(name);

        //find which element based on unitName
        for (int i = 0; i < units.Length-1; i++)
        {
            //Checking for the name of the indexing
            //print(GetDataValue(units[i], getName));

            //Checks if name retrieved equals the tag of the gameObject
            //Retrieves Data and assigns to individual Strings
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

        //Final debugging
        //print("found Element based on name");
    }
}
