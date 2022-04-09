using UnityEngine;

public class MONSTER_WEIGHT
{
    public const int BOMBER = 2;
    public const int SKELETON_MAGE = 3;
    public const int ZOMBUNNY = 1;
    public const int ZOMBEAR = 1;
    public const int ZOMHELLEPHANT = 3;
    public const int BOSS = 0;

    public static int GetWeightByTag(int tag)
    {
        switch (tag)
        {
            case 0:
                return BOMBER;
            case 1:
                return SKELETON_MAGE;
            case 2:
                return ZOMBUNNY;
            case 3:
                return ZOMBEAR;
            case 4:
                return ZOMHELLEPHANT;
            case 5:
                return BOSS;
            default:
                return ZOMBUNNY;
        }
    }
}
