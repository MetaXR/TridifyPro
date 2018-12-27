using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class ScriptingRuntimeCheck
{
    private const string TridifyDoNotRemindScriptingRuntimeVersion = "TrifidyDoNotRemindScriptingRuntimeVersion";
    static ScriptingRuntimeCheck()
    {
        ShowRuntimeVersionWarningIfNeeded();
    }

    static void ShowRuntimeVersionWarningIfNeeded()
    {
        var doNotRemind = EditorPrefs.GetBool(TridifyDoNotRemindScriptingRuntimeVersion);

        if (!doNotRemind && PlayerSettings.scriptingRuntimeVersion != ScriptingRuntimeVersion.Latest)
        {
            var result = EditorUtility.DisplayDialogComplex("Tridify Tools requires scripting runtime 4.x",
                "Use 4.x scripting runtime (requires restart)", "Use", "Cancel", "Do not remind me again");
            if (result == 0)
            {
                PlayerSettings.scriptingRuntimeVersion = ScriptingRuntimeVersion.Latest;
                EditorUtility.DisplayDialog("Restart required", "Scripting runtime changed. Please restart unity for changes to take effect.", "Ok");
            } else if (result == 2)
            {
                EditorPrefs.SetBool(TridifyDoNotRemindScriptingRuntimeVersion, true);
            }
        }
    }
}
