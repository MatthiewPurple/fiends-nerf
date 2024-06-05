using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using fiends_nerf;

[assembly: MelonInfo(typeof(FiendsNerf), "Fiends nerf (Zeikar variant)", "1.0.2", "Matthiew Purple")]
[assembly: MelonGame("アトラス", "smt3hd")]

namespace fiends_nerf;
public class FiendsNerf : MelonMod
{
    private static bool isAnalyzing = false;

    // After getting the affinities of a demon
    [HarmonyPatch(typeof(datAisyoName), nameof(datAisyoName.Get))]
    private class Patch
    {
        public static void Postfix(ref int id, ref string __result)
        {
            if (!isAnalyzing)
            {
                switch (id)
                {
                    case 199:
                        __result = "Null: Force/Light/Dark • Str: Nerve"; // Matador
                        break;
                    case 201:
                        __result = "Null: Light/Dark/Mind • Str: Curse"; // Daisoujou
                        break;
                    case 200:
                        __result = "Drn: Force • Null: Fire/Light/Dark • Str: Nerve"; // Hell Biker
                        break;
                    case 196:
                        __result = "Null: Fire/Light/Dark/Nerve"; // White Rider
                        break;
                    case 197:
                        __result = "Null: Elec/Force/Light/Dark/Mind"; // Red Rider
                        break;
                    case 198:
                        __result = "Drn: Ice • Null: Light/Dark/Curse"; // Black Rider
                        break;
                    case 195:
                        __result = "Null: Ice/Light/Dark/Curse/Mind"; // Pale Rider
                        break;
                    case 202:
                        __result = "Rpl: Phys • Drn: Elec • Null: Light/Dark • Str: Ailments"; // Mother Harlot
                        break;
                }
            }

            isAnalyzing = false;
        }
    }

    // After getting the affinities of a demon
    [HarmonyPatch(typeof(datDevilFormat), nameof(datDevilFormat.Analyze))]
    private class Patch2
    {
        public static void Prefix()
        {
            isAnalyzing = true;
        }
    }

    // When launching the game
    public override void OnInitializeMelon()
    {
        // Changes Matador's affinities
        datAisyo.tbl[199][8] = 100; // Neutral to Curse
        datAisyo.tbl[199][9] = 50; // Resist Nerve
        datAisyo.tbl[199][10] = 100; // Neutral to Mind

        // Changes Daisoujou's affinities
        datAisyo.tbl[201][6] = 65536; // Null Light
        datAisyo.tbl[201][7] = 65536; // Null Dark
        datAisyo.tbl[201][8] = 50; // Resist Curse
        datAisyo.tbl[201][9] = 100; // Neutral to Nerve
        datAisyo.tbl[201][10] = 65536; // Null Mind

        // Changes Hell Biker's affinities
        datAisyo.tbl[200][8] = 100; // Neutral to Curse
        datAisyo.tbl[200][9] = 50; // Resist Nerve
        datAisyo.tbl[200][10] = 100; // Neutral to Mind

        // Changes White Rider's affinities
        datAisyo.tbl[196][8] = 100; // Neutral to Curse
        datAisyo.tbl[196][10] = 100; // Neutral to Mind

        // Changes Red Rider's affinities
        datAisyo.tbl[197][8] = 100; // Neutral to Curse
        datAisyo.tbl[197][9] = 100; // Neutral to Nerve

        // Changes Black Rider's affinities
        datAisyo.tbl[198][9] = 100; // Neutral to Nerve
        datAisyo.tbl[198][10] = 100; // Neutral to Mind

        // Changes Pale Rider's affinities
        datAisyo.tbl[195][9] = 100; // Neutral to Nerve

        // Changes Mother Harlot's affinities
        datAisyo.tbl[202][8] = 50; // Resist Curse
        datAisyo.tbl[202][9] = 50; // Resist Nerve
        datAisyo.tbl[202][10] = 50; // Resist Mind

        // Changes Trumpeter's affinities
        datAisyo.tbl[203][1] = 75; // 25% Resist Fire
        datAisyo.tbl[203][2] = 75; // 25% Resist Ice
        datAisyo.tbl[203][3] = 75; // 25% Resist Elec
        datAisyo.tbl[203][4] = 75; // 25% Resist Force
    }
}
