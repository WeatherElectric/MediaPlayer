namespace MediaPlayer.Melon;

internal static class BoneMenuExtensions
{
    public static void CreateBoolPreference(this MenuCategory category, string name, Color color, MelonPreferences_Entry<bool> pref, MelonPreferences_Category prefCategory)
    {
        category.CreateBoolElement(name, color, pref.Value, v =>
        {
            pref.Value = v;
            prefCategory.SaveToFile(false);
        });
    }
    
    public static void CreateBoolPreference(this MenuCategory category, string name, string hexColor, MelonPreferences_Entry<bool> pref, MelonPreferences_Category prefCategory)
    {
        category.CreateBoolElement(name, hexColor, pref.Value, v =>
        {
            pref.Value = v;
            prefCategory.SaveToFile(false);
        });
    }
    
    public static void CreateFloatPreference(this MenuCategory category, string name, Color color, float increment, float min, float max, MelonPreferences_Entry<float> pref, MelonPreferences_Category prefCategory)
    {
        category.CreateFloatElement(name, color, pref.Value, increment, min, max, v =>
        {
            pref.Value = v;
            prefCategory.SaveToFile(false);
        });
    }
    
    public static void CreateFloatPreference(this MenuCategory category, string name, string hexColor, float increment, float min, float max, MelonPreferences_Entry<float> pref, MelonPreferences_Category prefCategory)
    {
        category.CreateFloatElement(name, hexColor, pref.Value, increment, min, max, v =>
        {
            pref.Value = v;
            prefCategory.SaveToFile(false);
        });
    }
    
    public static void CreateIntPreference(this MenuCategory category, string name, Color color, int increment, int min, int max, MelonPreferences_Entry<int> pref, MelonPreferences_Category prefCategory)
    {
        category.CreateIntElement(name, color, pref.Value, increment, min, max, v =>
        {
            pref.Value = v;
            prefCategory.SaveToFile(false);
        });
    }
    
    public static void CreateIntPreference(this MenuCategory category, string name, string hexColor, int increment, int min, int max, MelonPreferences_Entry<int> pref, MelonPreferences_Category prefCategory)
    {
        category.CreateIntElement(name, hexColor, pref.Value, increment, min, max, v =>
        {
            pref.Value = v;
            prefCategory.SaveToFile(false);
        });
    }
    
    public static void CreateEnumPreference<TEnum>(this MenuCategory category, string name, Color color, MelonPreferences_Entry<TEnum> pref, MelonPreferences_Category prefCategory) where TEnum : Enum
    {
        category.CreateEnumElement(name, color, pref.Value, v =>
        {
            pref.Value = v;
            prefCategory.SaveToFile(false);
        });
    }
    
    public static void CreateEnumPreference<TEnum>(this MenuCategory category, string name, string hexColor, MelonPreferences_Entry<TEnum> pref, MelonPreferences_Category prefCategory) where TEnum : Enum
    {
        category.CreateEnumElement(name, hexColor, pref.Value, v =>
        {
            pref.Value = v;
            prefCategory.SaveToFile(false);
        });
    }
}