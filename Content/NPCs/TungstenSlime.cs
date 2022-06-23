using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace OreSlimes.Content.NPCs;

public class TungstenSlime : ModNPC {
    public override void SetStaticDefaults() {
        Main.npcFrameCount[NPC.type] = 2;
    }
    
    public override void SetDefaults() {
        NPC.width = 36;
        NPC.height = 36;
        NPC.aiStyle = NPCAIStyleID.Slime;
        AnimationType = 1;
        NPC.damage = 15;
        NPC.defense = 4;
        NPC.lifeMax = 50;
        NPC.HitSound = new SoundStyle("OreSlimes/Assets/Sounds/NPCs/OreSlimeHit") with {
            PitchVariance = 0.1f
        };
        NPC.DeathSound = new SoundStyle("OreSlimes/Assets/Sounds/NPCs/OreSlimeKill") with {
            PitchVariance = 0.05f
        };
        NPC.value = 550f;
        NPC.lavaImmune = true; // Made of metal
    }
    
    public override void HitEffect(int hitDirection, double damage) {
        for(int i = 0; i < 12; i++) {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Tungsten, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) {
        npcLoot.Add(new CommonDrop(ItemID.TungstenOre, 3, 1, 5, 4));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) {
        if(spawnInfo.Player.ZoneRockLayerHeight) return 0.075f;
        return 0f;
    }
}