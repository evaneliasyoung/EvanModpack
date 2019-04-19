﻿/**
*  @file      YoyoGauntletAccessory.cs
*  @brief     Adds a cool yoyo bag-fire gauntlet accessory.
*
*  @author    Evan Elias Young
*  @date      2017-04-23
*  @date      2019-04-16
*  @copyright Copyright 2017-2019 Evan Elias Young. All rights reserved.
*/

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanModpack.Items.Accessories
{
	internal class YoyoGauntletAccessory : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yoyo Gauntlet");
			Tooltip.SetDefault("Gives the user master yoyo skills and 15% increased melee damage and speed.\nIncreases melee knockback and inflicts fire damage on attack.");

			DisplayName.AddTranslation(GameCulture.Spanish, "Guantelete del Yoyó");
			Tooltip.AddTranslation(GameCulture.Spanish, "Da al usuario habilidades maestro yoyó y 15% aumentado daño cuerpo a cuerpo y velocidad.\nAumentado revancha cuerpo a cuerpo y inflige daño de fuego.");
			DisplayName.AddTranslation(GameCulture.German, "Jojo Stulpenhandschuh");
			Tooltip.AddTranslation(GameCulture.German, "Gibt dem Benutzer Meister yoyo Fähigkeiten und 15% erhöhten Nahkampfschaden und Geschwindigkeit.\nErhöht Nahkampf-Rückschlag und verursacht Brandschaden beim Angriff.");
			base.SetStaticDefaults();
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 30;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 7;
			item.accessory = true;
			base.SetDefaults();
		}

		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			target.AddBuff(BuffID.OnFire, 180);
			knockBack *= 1.8f;
			base.ModifyHitNPC(player, target, ref damage, ref knockBack, ref crit);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage *= 1.15f;
			player.meleeSpeed *= 1.15f;
			player.yoyoGlove = true;
			player.yoyoString = true;
			ModdedPlayer ModPlayer = player.GetModPlayer<ModdedPlayer>(mod);
			ModPlayer.AllParticles = true;
			base.UpdateAccessory(player, hideVisual);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FireGauntlet);
			recipe.AddIngredient(ItemID.YoyoBag);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}