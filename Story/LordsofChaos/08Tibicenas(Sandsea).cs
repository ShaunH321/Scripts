//cs_include Scripts/CoreBots.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
using RBot;

public class SagaSandsea
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public Core13LoC LOC => new Core13LoC();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.AcceptandCompleteTries = 5;
        Core.SetOptions();

        LOC.Tibicenas();

        Core.SetOptions(false);
    }
}