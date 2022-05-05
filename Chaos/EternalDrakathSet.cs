//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Chaos/DrakathArmorBot.cs
//cs_include Scripts/Story/StarSinc.cs
//cs_include Scripts/Nulgath/CoreNulgath.cs

using RBot;

public class EternalDrakath
{
    public ScriptInterface Bot => ScriptInterface.Instance;

    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public DrakathArmorBot Armor = new();
    public CoreBLOD BLOD = new();
    public StarSinc Star = new();

    private string[] Rewards = new[] { "Drakath the Eternal", "Drakath the Eternal's Visor", "Eternal Chaos Tassels", "Eternal Chaos Tassels", "Dual Everlasting Blades of Chaos" };

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        getSet();

        Core.SetOptions(false);
    }

    public void getSet()
    {
        if (Core.CheckInventory(Rewards))
            return;

        Core.AddDrop(Rewards);

        Armor.DrakathArmor();

        if (!Core.CheckInventory("Drakath's Sword"))
            Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("ultradrakath", "Champion of Chaos", "Drakath's Sword", isTemp: false);

        Core.EnsureAccept(8457);

        BLOD.SpiritOrb(2000);

        if (!Core.CheckInventory("Crystallized Chaos", 800))
            Core.EquipClass(ClassType.Farm);
        Core.KillMonster("chaoslab", "r3", "Center", "Chaorrupted Moglin", "Crystallized Chaos", 800, false);

        if (!Core.CheckInventory("Star Fragment", 33))
        {
            Star.StarSincQuests();
            Core.EquipClass(ClassType.Farm);
            Core.AddDrop("Star Fragment");
            Core.RegisterQuests(4413);

            while (!Core.CheckInventory("Star Fragment", 33))
            {
                Core.HuntMonster("starsinc", "Living Star", "Living Star Defeated", 30);
                Bot.Wait.ForPickup("Star Fragment");
            }
        }

        if (!Core.CheckInventory("Death's Oversight", 5))
            Core.EquipClass(ClassType.Solo);
        Core.HuntMonster("shadowattack", "Death", "Death's Oversight", 5, false);

        if (!Core.CheckInventory("Reality Shard", 300))
        {
            Core.EquipClass(ClassType.Solo);
            Core.AddDrop("Reality Shard");
            Core.RegisterQuests(8455);

            while (!Core.CheckInventory("Reality Shard", 200))
            {
                Core.HuntMonster("eternalchaos", "Eternal Drakath", "Eternal Drakath Defeated", 1);
                Bot.Wait.ForPickup("Reality Shard");
            }
        }

        Core.EnsureComplete(8457);
    }
}