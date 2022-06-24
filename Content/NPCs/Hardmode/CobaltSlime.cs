using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace OreSlimes.Content.NPCs.Hardmode; 

public class CobaltSlime : OreSlime {
    public override void SetDefaults() {
        base.SetDefaults();
        NPC.damage = 45;
        NPC.defense = 8;
        NPC.lifeMax = 90;
        NPC.value = 1000f;
    }
    
    public override void HitEffect(int hitDirection, double damage) {
        for(int i = 0; i < 12; i++) {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Cobalt, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) {
        npcLoot.Add(new CommonDrop(ItemID.CobaltOre, 3, 1, 6, 4));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        if(Main.hardMode && spawnInfo.Player.ZoneRockLayerHeight) return 0.04f;
        return 0f;
    }
}