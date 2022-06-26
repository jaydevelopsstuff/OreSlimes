using OreSlimes.Common.Configs;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace OreSlimes.Content.NPCs.Hardmode; 

public class PalladiumSlime : OreSlime {
    public override void SetDefaults() {
        base.SetDefaults();
        NPC.damage = 95;
        NPC.defense = 10;
        NPC.lifeMax = 130;
        NPC.value = 1000f;
    }
    
    public override void HitEffect(int hitDirection, double damage) {
        for(int i = 0; i < 12; i++) {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Palladium, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) {
        npcLoot.Add(new CommonDrop(ItemID.PalladiumOre, 1, 2, 7));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        if(Main.hardMode && spawnInfo.Player.ZoneRockLayerHeight) return 0.03f * ModContent.GetInstance<OreSlimeConfig>().SpawnRateMultiplier;
        return 0f;
    }
}