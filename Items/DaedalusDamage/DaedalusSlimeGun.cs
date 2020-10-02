﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DaedalusClass.Items.DaedalusDamage
{
    class DaedalusSlimeGun : DaedalusDamageItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Slime gun but good");
        }
        public override void SafeSetDefaults()
        {
            item.width = 99;
            item.height = 99;
            item.useTime = 27;
            item.useAnimation = 27;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.damage = 10;
            item.knockBack = 1.2f;
            item.maxStack = 1;
            item.shoot = ProjectileID.WaterStream;
            item.shootSpeed = 9f;
            item.rare = ItemRarityID.Green;
            item.crit = 4;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3 + Main.rand.Next(2);
            for (int index = 0; index < numberProjectiles; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)(player.position.X + player.width * 0.5 + Main.rand.Next(201) * -player.direction + (Main.mouseX + (double)Main.screenPosition.X - player.position.X)), (float)(player.position.Y + player.height * 0.5 - 600.0));
                vector2_1.X = (float)((vector2_1.X + (double)player.Center.X) / 2.0) + Main.rand.Next(-200, 201);
                vector2_1.Y -= 100 * index;
                float num12 = Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if (num13 < 0.0)
                {
                    num13 *= -1f;
                }

                if (num13 < 20.0)
                {
                    num13 = 20f;
                }

                float num14 = (float)Math.Sqrt(num12 * (double)num12 + num13 * (double)num13);
                float num15 = item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + Main.rand.Next(-10, 11) * 0.02f;
                float SpeedY = num17 + Main.rand.Next(-5, 6) * 0.02f;
                Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, Main.rand.Next(5));
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SlimeGun, 1);
            recipe.AddIngredient(ItemID.PlatinumBow, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddIngredient(ItemID.SlimeGun, 1);
            recipe1.AddIngredient(ItemID.GoldBow, 1);
            recipe1.AddTile(TileID.Anvils);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
