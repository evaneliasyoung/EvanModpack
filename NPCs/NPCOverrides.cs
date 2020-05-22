﻿/**
*  @file      VanillaOverrides.cs
*  @brief     Basic overrides for the default NPC in the game.
*
*  @author    Evan Elias Young
*  @date      2017-07-20
*  @date      2020-03-25
*  @copyright Copyright 2017-2020 Evan Elias Young. All rights reserved.
*/

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EvanMod.NPCs
{
	internal class NPCOverrides : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			switch (npc.type)
			{
				case NPCID.WallofFlesh:
					// FIX: Slag generation seems broken.
					// GenerateSlag();
					return;
			}
			base.NPCLoot(npc);
		}

		public void GenerateSlag()
		{
			int slagVeins = 45;
			int slagLoop = (int)Math.Round((float)(Main.maxTilesY * slagVeins) / 9);
			Main.NewText(Language.GetTextValue("Mods.EvanMod.Misc.SlagEnter"), Utils.ChatColors.Info);

			for (int i = 0; i < slagLoop; ++i)
			{
				GenerateSlagVein();
			}
		}

		public void GenerateSlagVein()
		{
			Point minPos = new Point(0, Main.maxTilesY - 200);
			Point maxPos = new Point(Main.maxTilesX, Main.maxTilesY);
			int slagStrength = WorldGen.genRand.Next(4, 8);
			int slagStep = WorldGen.genRand.Next(5, 9);

			WorldGen.OreRunner(WorldGen.genRand.Next(minPos.X, maxPos.X), WorldGen.genRand.Next(minPos.Y, maxPos.Y), slagStrength, slagStep, (ushort)mod.TileType("SlagTile"));
		}

		/// <summary>
		/// Override the defaults from the base-game.
		/// </summary>
		/// <param name="npc">The npc to edit.</param>
		public override void SetDefaults(NPC npc)
		{
			switch (npc.type)
			{
				case NPCID.SkeletonMerchant:
					npc.rarity = 2;
					break;
			}
			base.SetDefaults(npc);
		}

		/// <summary>
		/// Overrides any of the shops in the base-game.
		/// </summary>
		/// <param name="type">The vendor.</param>
		/// <param name="shop">The vendor's shop.</param>
		/// <param name="nextSlot">The vendor's shop's next index.</param>
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			// The George set of vanity armor.
			List<string> clothierGeorgeSet = new List<string> { "GeorgeHat", "GeorgeSuit", "GeorgePants" };
			// The 4th Doctor set of vanity armor.
			List<string> clothierDoctorSet = new List<string> { "LongScarf" };

			switch (type)
			{
				case NPCID.ArmsDealer:
					shop.item[nextSlot++].SetDefaults(ItemID.AmmoBox);
					break;
				case NPCID.Merchant:
					shop.item[nextSlot++].SetDefaults(ItemID.SharpeningStation);
					if (Main.player[Main.myPlayer].statLifeMax > 400)
					{
						shop.item[7].SetDefaults(ItemID.SuperHealingPotion);
					}
					else if (Main.player[Main.myPlayer].statLifeMax > 300)
					{
						shop.item[7].SetDefaults(ItemID.GreaterHealingPotion);
					}
					else if (Main.player[Main.myPlayer].statLifeMax > 200)
					{
						shop.item[7].SetDefaults(ItemID.HealingPotion);
					}
					else
					{
						shop.item[7].SetDefaults(ItemID.LesserHealingPotion);
					}
					break;
				case NPCID.Clothier:
					if (Main.player[Main.myPlayer].Male && Main.bloodMoon)
					{
						foreach (string e in clothierGeorgeSet)
						{
							shop.item[nextSlot++].SetDefaults(mod.ItemType(e));
						}
					}
					if (Main.player[Main.myPlayer].Male && Main.moonPhase == 2)
					{
						foreach (string e in clothierDoctorSet)
						{
							shop.item[nextSlot++].SetDefaults(mod.ItemType(e));
						}
					}
					break;
				case NPCID.Dryad:
					if (NPC.downedBoss3)
					{
						shop.item[nextSlot].SetDefaults(ItemID.HerbBag);
						shop.item[nextSlot++].shopCustomPrice = Item.buyPrice(0, 1, 0, 0);
					}
					break;
				case NPCID.Wizard:
					shop.item[nextSlot++].SetDefaults(ItemID.BewitchingTable);
					if (Main.player[Main.myPlayer].statManaMax2 > 200)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.SuperManaPotion);
					}
					else if (Main.player[Main.myPlayer].statManaMax2 == 200)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.GreaterManaPotion);
					}
					else if (Main.player[Main.myPlayer].statManaMax2 > 100)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.ManaPotion);
					}
					else if (Main.player[Main.myPlayer].statManaMax2 > 0)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.LesserManaPotion);
					}
					if (NPC.downedBoss3)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.ClothierVoodooDoll);
					}
					if (NPC.downedBoss3)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.ClothierVoodooDoll);
					}
					if (Main.hardMode)
					{
						shop.item[nextSlot++].SetDefaults(ItemID.GuideVoodooDoll);
					}
					break;
			}
			base.SetupShop(type, shop, ref nextSlot);
		}
	}
}
