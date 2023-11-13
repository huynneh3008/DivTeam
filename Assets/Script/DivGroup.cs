using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class DivGroup : MonoBehaviour
{
    [SerializeField] SerializableSet _set;

    [SerializeField]
    private int numberTeam = 2;
    private int sum = 0;
    private int numberMemberPerTeam = 0;
    private List<int> listMemberRemain = new List<int>();
    private List<int> team = new List<int>();
    private bool isFound;
    private static System.Random rng = new System.Random();

    private void Awake()
    {
        Deserializer.Deserialize(_set);
    }

    void Start()
    {
        Handle();
    }

    private void Handle()
    {
        for(int i = 1; i <= MemberSheet.GetDictionary().Count; i++)
        {
            sum += MemberSheet.Get(i).value;
            listMemberRemain.Add(i);
        }

        listMemberRemain = listMemberRemain.OrderBy(x => rng.Next()).ToList();
        if(sum % numberTeam != 0)
        {
            Debug.LogError("Can't found");
            return;
        }

        sum = sum / numberTeam;
        numberMemberPerTeam = MemberSheet.GetDictionary().Count / numberTeam;

        for (int i = 0; i < numberMemberPerTeam; i++)
        {
            team.Add(0);
        }    

        for (int i = 1; i <= numberTeam; i++)
        {
            isFound = false;
            Debug.LogError("Team - " + i);
            Try(0, sum, numberMemberPerTeam);
        }    
    }   
    
    private void Try(int i, int sum, int numberMember)
    {
        if (isFound) return;
        if (sum == 0 && numberMember == 0)
        {
            isFound = true;
            foreach(var member in team)
            {
                Debug.LogError("ID - " + member + " - " + MemberSheet.Get(member).name + " - value - " + MemberSheet.Get(member).value);
                listMemberRemain.Remove(member);
            }
            return;
        }  
        
        if(i >= listMemberRemain.Count)
        {
            return;
        }

        Try(i + 1, sum, numberMember);

        if (i < listMemberRemain.Count && MemberSheet.Get(listMemberRemain[i]).value <= sum)
        {
            team[numberMember - 1] = listMemberRemain[i];
            Try(i + 1, sum - MemberSheet.Get(listMemberRemain[i]).value, numberMember - 1);
        }
    }

    private void GetTeam()
    {
        List<List<bool>> dp = new List<List<bool>>();
        for(int i = 0; i <= listMemberRemain.Count; i++)
        {
            dp.Add(new List<bool>());
            for(int j = 0; j <= sum; j++)
            {
                dp[i].Add(false);
            }    
        }

        dp[0][0] = true;
    }    
}
