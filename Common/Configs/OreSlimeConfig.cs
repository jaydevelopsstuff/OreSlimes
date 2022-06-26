using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace OreSlimes.Common.Configs; 

public class OreSlimeConfig : ModConfig {
    public override ConfigScope Mode => ConfigScope.ServerSide;

    [Header("$Mods.OreSlimes.Config.GeneralHeader")]
    [Label("$Mods.OreSlimes.Config.SpawnRateMultiplier.Label")]
    [Tooltip("$Mods.OreSlimes.Config.SpawnRateMultiplier.Tooltip")]
    [DefaultValue(1)]
    public float SpawnRateMultiplier;
}