using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace OreSlimes.Content.NPCs; 

public class GoldSlime : ModNPC {
    public override void SetStaticDefaults() {
        Main.npcFrameCount[NPC.type] = 2;
    }
    
    public override void SetDefaults() {
        NPC.width = 36;
        NPC.height = 36;
        NPC.aiStyle = NPCAIStyleID.Slime;
        AnimationType = 1;
        NPC.damage = 20;
        NPC.defense = 5;
        NPC.lifeMax = 50;
        NPC.HitSound = new SoundStyle("OreSlimes/Assets/Sounds/NPCs/OreSlimeHit") with {
            PitchVariance = 0.1f
        };
        NPC.DeathSound = new SoundStyle("OreSlimes/Assets/Sounds/NPCs/OreSlimeKill") with {
            PitchVariance = 0.05f
        };
        NPC.value = 25f;
        NPC.lavaImmune = true; // Made of metal
    }
    
    public override void HitEffect(int hitDirection, double damage) {
        for(int i = 0; i < 12; i++) {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Gold, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) {
        npcLoot.Add(new CommonDrop(ItemID.GoldOre, 3, 1, 6, 4));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        if(spawnInfo.Player.ZoneRockLayerHeight) return 0.04f;
        return 0f;
    }
}