﻿//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailys.cs
//cs_include Scripts/Nulgath/CoreNulgath.cs
//cs_include Scripts/Nulgath/AssistingCragAndBamboozle.cs
//cs_include Scripts/Nulgath/VHL/CoreVHL.cs
using RBot;
public class VoidHighlordsChallenge
{
    public CoreBots Core => CoreBots.Instance;
    public CoreVHL VHL = new CoreVHL();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        VHL.VHLChallenge(15);

        Core.SetOptions(false);
    }
}