using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace OreSlimes.Content.NPCs; 

public class OreSlime : ModNPC {
    public override void SetStaticDefaults() {
        Main.npcFrameCount[NPC.type] = 2;
    }

    public override void SetDefaults() {
        NPC.width = 36;
        NPC.height = 36;
        NPC.aiStyle = NPCAIStyleID.Slime;
        AnimationType = 1;
        NPC.HitSound = new SoundStyle("OreSlimes/Assets/Sounds/NPCs/OreSlimeHit") with {
            PitchVariance = 0.1f
        };
        NPC.DeathSound = new SoundStyle("OreSlimes/Assets/Sounds/NPCs/OreSlimeKill") with {
            PitchVariance = 0.05f
        };
        NPC.lavaImmune = true; // Made of metal
    }
}