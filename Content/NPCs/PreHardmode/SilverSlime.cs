﻿using OreSlimes.Common.Configs;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace OreSlimes.Content.NPCs.PreHardmode;

public class SilverSlime : OreSlime {
    public override void SetDefaults() {
        base.SetDefaults();
        NPC.damage = 15;
        NPC.defense = 4;
        NPC.lifeMax = 50;
        NPC.value = 550f;
    }
    
    public override void HitEffect(int hitDirection, double damage) {
        for(int i = 0; i < 12; i++) {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Silver, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) {
        npcLoot.Add(new CommonDrop(ItemID.SilverOre, 1, 2, 7));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        if(spawnInfo.Player.ZoneRockLayerHeight) return 0.06f * ModContent.GetInstance<OreSlimeConfig>().SpawnRateMultiplier;
        return 0f;
    }
}