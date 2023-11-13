using System.Collections.Generic;
using MagicExcel;

[System.Serializable]
public class MemberSheet
{
    /// <summary>
    /// comment
    /// </summary>
    public int id;

    /// <summary>
    /// comment
    /// </summary>
    public string name;

    /// <summary>
    /// comment
    /// </summary>
    public int value;


    private static Dictionary<int, MemberSheet> dictionary = new Dictionary<int, MemberSheet>();

    /// <summary>
    /// Get MemberSheet by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>MemberSheet</returns>
    public static MemberSheet Get(int id)
    {
        return dictionary[id];
    }
    
    public static Dictionary<int, MemberSheet> GetDictionary()
    {
        return dictionary;
    }

    public static void SetDictionary(Dictionary<int, MemberSheet> dic) {
        dictionary = dic;
    }
}
