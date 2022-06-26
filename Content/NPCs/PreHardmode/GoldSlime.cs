using OreSlimes.Common.Configs;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace OreSlimes.Content.NPCs.PreHardmode; 

public class GoldSlime : OreSlime {
    public override void SetDefaults() {
        base.SetDefaults();
        NPC.damage = 20;
        NPC.defense = 5;
        NPC.lifeMax = 50;
        NPC.value = 750f;
    }
    
    public override void HitEffect(int hitDirection, double damage) {
        for(int i = 0; i < 12; i++) {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Gold, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) {
        npcLoot.Add(new CommonDrop(ItemID.GoldOre, 1, 2, 7));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        if(spawnInfo.Player.ZoneRockLayerHeight) return 0.035f * ModContent.GetInstance<OreSlimeConfig>().SpawnRateMultiplier;
        return 0f;
    }
}