﻿/**
*  @file      FrostburnBoots.cs
*  @brief     Adds a successor to the frostspark boots and lava waders.
*
*  @author    Evan Elias Young
*  @date      2019-05-30
*  @date      2019-05-30
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EvanModpack.Items.Accessories
{
	[AutoloadEquip(EquipType.Shoes)]
	internal class FrostburnBoots : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 28;
			item.value = Item.sellPrice(0, 12, 50, 0);
			item.rare = ItemRarityID.Lime;
			item.accessory = true;
			base.SetDefaults();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.accRunSpeed = 6.75f;
			player.rocketBoots = 3;
			player.moveSpeed += 0.08f;
			player.waterWalk = true;
			player.fireWalk = true;
			player.lavaMax += Utils.FrameTime(7);
			player.iceSkate = true;
			base.UpdateAccessory(player, hideVisual);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FrostsparkBoots);
			recipe.AddIngredient(ItemID.LavaWaders);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddIngredient(ItemID.SoulofMight);
			recipe.AddIngredient(ItemID.SoulofSight);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
			base.AddRecipes();
		}
	}
}
