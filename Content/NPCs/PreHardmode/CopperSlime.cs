﻿using OreSlimes.Common.Configs;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace OreSlimes.Content.NPCs.PreHardmode;

public class CopperSlime : OreSlime {
    public override void SetDefaults() {
        base.SetDefaults();
        NPC.damage = 10;
        NPC.defense = 2;
        NPC.lifeMax = 20;
        NPC.value = 150f;
    }

    public override void HitEffect(int hitDirection, double damage) {
        for(int i = 0; i < 12; i++) {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Copper, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) {
        npcLoot.Add(new CommonDrop(ItemID.CopperOre, 1, 2, 7));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        if(spawnInfo.Player.ZoneRockLayerHeight) return 0.15f * ModContent.GetInstance<OreSlimeConfig>().SpawnRateMultiplier;
        return 0f;
    }
}    