using System;
using BoneLib.BoneMenu.Elements;
using MelonLoader;
using UnityEngine;

namespace MediaPlayer.Melon
{
    internal static class BoneMenuExtensions
    {
        #region Bool
        
        public static BoolElement CreateBoolPreference(this MenuCategory category, string name, Color color, MelonPreferences_Entry<bool> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var boolElement = category.CreateBoolElement(name, color, pref.Value, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return boolElement;
        }
    
        public static BoolElement CreateBoolPreference(this MenuCategory category, string name, string hexColor, MelonPreferences_Entry<bool> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var boolElement = category.CreateBoolElement(name, hexColor, pref.Value, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return boolElement;
        }
        
        public static BoolElement CreateBoolPreference(this SubPanelElement category, string name, Color color, MelonPreferences_Entry<bool> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var boolElement = category.CreateBoolElement(name, color, pref.Value, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return boolElement;
        }
    
        public static BoolElement CreateBoolPreference(this SubPanelElement category, string name, string hexColor, MelonPreferences_Entry<bool> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var boolElement = category.CreateBoolElement(name, hexColor, pref.Value, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return boolElement;
        }
        
        #endregion
    
        #region Float
        
        public static FloatElement CreateFloatPreference(this MenuCategory category, string name, Color color, float increment, float min, float max, MelonPreferences_Entry<float> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var floatElement = category.CreateFloatElement(name, color, pref.Value, increment, min, max, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return floatElement;
        }
    
        public static FloatElement CreateFloatPreference(this MenuCategory category, string name, string hexColor, float increment, float min, float max, MelonPreferences_Entry<float> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var floatElement = category.CreateFloatElement(name, hexColor, pref.Value, increment, min, max, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return floatElement;
        }
        
        public static FloatElement CreateFloatPreference(this SubPanelElement category, string name, Color color, float increment, float min, float max, MelonPreferences_Entry<float> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var floatElement = category.CreateFloatElement(name, color, pref.Value, increment, min, max, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return floatElement;
        }
    
        public static FloatElement CreateFloatPreference(this SubPanelElement category, string name, string hexColor, float increment, float min, float max, MelonPreferences_Entry<float> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var floatElement = category.CreateFloatElement(name, hexColor, pref.Value, increment, min, max, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return floatElement;
        }
        
        #endregion
        
        #region Int
    
        public static IntElement CreateIntPreference(this MenuCategory category, string name, Color color, int increment, int min, int max, MelonPreferences_Entry<int> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var intElement = category.CreateIntElement(name, color, pref.Value, increment, min, max, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return intElement;
        }
    
        public static IntElement CreateIntPreference(this MenuCategory category, string name, string hexColor, int increment, int min, int max, MelonPreferences_Entry<int> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var intElement = category.CreateIntElement(name, hexColor, pref.Value, increment, min, max, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return intElement;
        }
        
        public static IntElement CreateIntPreference(this SubPanelElement category, string name, Color color, int increment, int min, int max, MelonPreferences_Entry<int> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var intElement = category.CreateIntElement(name, color, pref.Value, increment, min, max, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return intElement;
        }
    
        public static IntElement CreateIntPreference(this SubPanelElement category, string name, string hexColor, int increment, int min, int max, MelonPreferences_Entry<int> pref, MelonPreferences_Category prefCategory, bool autoSave = true)
        {
            var intElement = category.CreateIntElement(name, hexColor, pref.Value, increment, min, max, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return intElement;
        }
        
        #endregion
        
        #region Enum
    
        public static EnumElement<TEnum> CreateEnumPreference<TEnum>(this MenuCategory category, string name, Color color, MelonPreferences_Entry<TEnum> pref, MelonPreferences_Category prefCategory, bool autoSave = true) where TEnum : Enum
        {
            var enumElement = category.CreateEnumElement(name, color, pref.Value, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return enumElement;
        }
    
        public static EnumElement<TEnum> CreateEnumPreference<TEnum>(this MenuCategory category, string name, string hexColor, MelonPreferences_Entry<TEnum> pref, MelonPreferences_Category prefCategory, bool autoSave = true) where TEnum : Enum
        {
            var enumElement = category.CreateEnumElement(name, hexColor, pref.Value, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return enumElement;
        }
        
        public static EnumElement<TEnum> CreateEnumPreference<TEnum>(this SubPanelElement category, string name, Color color, MelonPreferences_Entry<TEnum> pref, MelonPreferences_Category prefCategory, bool autoSave = true) where TEnum : Enum
        {
            var enumElement = category.CreateEnumElement(name, color, pref.Value, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return enumElement;
        }
    
        public static EnumElement<TEnum> CreateEnumPreference<TEnum>(this SubPanelElement category, string name, string hexColor, MelonPreferences_Entry<TEnum> pref, MelonPreferences_Category prefCategory, bool autoSave = true) where TEnum : Enum
        {
            var enumElement = category.CreateEnumElement(name, hexColor, pref.Value, v =>
            {
                pref.Value = v;
                if (autoSave) prefCategory.SaveToFile(false);
            });
            return enumElement;
        }
        
        #endregion
    }
}