﻿//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using RBot;

public class TaintedGem
{
    public CoreBots Core => CoreBots.Instance;
    public CoreNation Nation = new();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        Nation.SwindleBulk();

        Core.SetOptions(false);
    }
}