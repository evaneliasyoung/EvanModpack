/**
*  @file      GenocidePotion.cs
*  @brief     Adds a 7x super-battle potion.
*
*  @author    Evan Elias Young
*  @date      2017-04-22
*  @date      2019-04-27
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Potions
{
	internal class GenocidePotion : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.BattlePotion);
			item.width = 20;
			item.height = 28;
			item.buffType = mod.BuffType("GenocideBuff");
			base.SetDefaults();
		}

		public override bool UseItem(Player player)
		{
			if (player.itemTime == 0)
			{
				player.AddBuff(item.buffType, Utils.FrameTime(7, 0), false);
			}
			return base.UseItem(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddRecipeGroup("EvanModpack:EvilPowder", 5);
			recipe.AddRecipeGroup("EvanModpack:EvilGuts", 2);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
