
using CookingDelight.Common.Players;
using System.Linq;

namespace CookingDelight.Common;

public class VanillaFoodCategorizer : GlobalItem
{

	public static Dictionary<FoodCategory, List<int>> VanillaFoodByCategory = new Dictionary<FoodCategory, List<int>>();

	public static int VanillaFoodBuffTime = 300;

	public override void Unload() {
		VanillaFoodByCategory = null;
	}

	public VanillaFoodCategorizer() {
		VanillaFoodByCategory.Add(FoodCategory.Meat, new List<int>() {
			ItemID.Bacon,
			ItemID.BBQRibs,
			ItemID.Bird,
			ItemID.BlackScorpion,
			ItemID.BlueJay,
			ItemID.BlueMacaw,
			ItemID.Bunny,
			ItemID.BunnyStew,
			ItemID.Buggy,
			ItemID.Burger,
			ItemID.Cardinal,
			ItemID.ChickenNugget,
			ItemID.Duck,
			ItemID.GoldBird,
			ItemID.GoldBunny,
			ItemID.GoldenDelight,
			ItemID.GoldMouse,
			ItemID.SquirrelGold,
			ItemID.GrayCockatiel,
			ItemID.Grebe,
			ItemID.GrilledSquirrel,
			ItemID.Grubby,
			ItemID.GrubSoup,
			ItemID.TurtleJungle,
			ItemID.MallardDuck,
			ItemID.MonsterLasagna,
			ItemID.Mouse,
			ItemID.Owl,
			ItemID.Penguin,
			ItemID.Pho,
			ItemID.Rat,
			ItemID.RoastedBird,
			ItemID.RoastedDuck,
			ItemID.RottenChunk,
			ItemID.ScarletMacaw,
			ItemID.Scorpion,
			ItemID.Seagull,
			ItemID.Spaghetti,
			ItemID.Squirrel,
			ItemID.SquirrelRed,
			ItemID.Steak,
			ItemID.Toucan,
			ItemID.Turtle,
			ItemID.Vertebrae,
			ItemID.YellowCockatiel
		});

		VanillaFoodByCategory.Add(FoodCategory.Seafood, new List<int>() {
			ItemID.AmanitaFungifin,
			ItemID.Angelfish,
			ItemID.ArmoredCavefish,
			ItemID.AtlanticCod,
			ItemID.Bass,
			ItemID.Batfish,
			ItemID.Bladetongue,
			ItemID.BloodyManowar,
			ItemID.BlueJellyfish,
			ItemID.BombFish,
			ItemID.Bonefish,
			ItemID.BowlofSoup,
			ItemID.BumblebeeTuna,
			ItemID.Bunnyfish,
			ItemID.CapnTunabeard,
			ItemID.Catfish,
			ItemID.ChaosFish,
			ItemID.Cloudfish,
			ItemID.Clownfish,
			ItemID.CookedFish,
			ItemID.CookedShrimp,
			ItemID.CrimsonTigerfish,
			ItemID.Cursedfish,
			ItemID.Damselfish,
			ItemID.DemonicHellfish,
			ItemID.Derpfish,
			ItemID.Dirtfish,
			ItemID.DoubleCod,
			ItemID.DynamiteFish,
			ItemID.EaterofPlankton,
			ItemID.Ebonkoi,
			ItemID.Escargot,
			ItemID.FallenStarfish,
			ItemID.Fishotron,
			ItemID.Fishron,
			ItemID.FlarefinKoi,
			ItemID.Flounder,
			ItemID.Frog,
			ItemID.FroggleBunwich,
			ItemID.FrostDaggerfish,
			ItemID.FrostMinnow,
			ItemID.GlowingSnail,
			ItemID.Goldfish,
			ItemID.GoldFrog,
			ItemID.GoldGoldfish,
			ItemID.GoldSeahorse,
			ItemID.GreenJellyfish,
			ItemID.GuideVoodooFish,
			ItemID.Harpyfish,
			ItemID.Hemopiranha,
			ItemID.Honeyfin,
			ItemID.Hungerfish,
			ItemID.Ichorfish,
			ItemID.InfectedScabbardfish,
			ItemID.Jewelfish,
			ItemID.LobsterTail,
			ItemID.MirageFish,
			ItemID.Mudfish,
			ItemID.MutantFlinxfin,
			ItemID.NeonTetra,
			ItemID.ObsidianSwordfish,
			ItemID.Obsidifish,
			ItemID.Oyster,
			ItemID.Pengfish,
			ItemID.PinkJellyfish,
			ItemID.Pixiefish,
			ItemID.PrincessFish,
			ItemID.Prismite,
			ItemID.Pupfish,
			ItemID.PurpleClubberfish,
			ItemID.ReaverShark,
			ItemID.RedSnapper,
			ItemID.Rockfish,
			ItemID.RockLobster,
			ItemID.Salmon,
			ItemID.Sashimi,
			ItemID.SauteedFrogLegs,
			ItemID.SawtoothShark,
			ItemID.ScarabFish,
			ItemID.ScorpioFish,
			ItemID.SeafoodDinner,
			ItemID.Seahorse,
			ItemID.Seaweed,
			ItemID.SharkFin,
			ItemID.Shrimp,
			ItemID.ShrimpPoBoy,
			ItemID.ShuckedOyster,
			ItemID.Slimefish,
			ItemID.Sluggy,
			ItemID.Snail,
			ItemID.SpecularFish,
			ItemID.Spiderfish,
			ItemID.Stinkfish,
			ItemID.Swordfish,
			ItemID.TheFishofCthulu,
			ItemID.Toxikarp,
			ItemID.TropicalBarracuda,
			ItemID.Trout,
			ItemID.Tuna,
			ItemID.TundraTrout,
			ItemID.UnicornFish,
			ItemID.VariegatedLardfish,
			ItemID.Wyverntail,
			ItemID.ZephyrFish,
			ItemID.ZombieFish
		});

		VanillaFoodByCategory.Add(FoodCategory.Fruit, new List<int>() {
			ItemID.Apple,
			ItemID.AppleJuice,
			ItemID.ApplePie,
			ItemID.Apricot,
			ItemID.Banana,
			ItemID.BananaSplit,
			ItemID.BlackCurrant,
			ItemID.BloodOrange,
			ItemID.BlueBerries,
			ItemID.Cherry,
			ItemID.Coconut,
			ItemID.Dragonfruit,
			ItemID.Elderberry,
			ItemID.FruitJuice,
			ItemID.FruitSalad,
			ItemID.Grapefruit,
			ItemID.GrapeJuice,
			ItemID.Grapes,
			ItemID.Lemon,
			ItemID.Lemonade,
			ItemID.Mango,
			ItemID.Peach,
			ItemID.Pineapple,
			ItemID.PinkPricklyPear,
			ItemID.Plum,
			ItemID.Pomegranate,
			ItemID.Rambutan,
			ItemID.SmoothieofDarkness,
			ItemID.Starfruit,
			ItemID.TropicalSmoothie
		});

		VanillaFoodByCategory.Add(FoodCategory.Vegetable, new List<int>() {
			ItemID.Cactus,
			ItemID.GlowingMushroom,
			ItemID.GreenMushroom,
			ItemID.Mushroom,
			ItemID.PadThai,
			ItemID.Pumpkin,
			ItemID.PumpkinPie,
			ItemID.SpicyPepper,
			ItemID.TealMushroom,
			ItemID.ViciousMushroom,
			ItemID.VileMushroom
		});

		VanillaFoodByCategory.Add(FoodCategory.Sweet, new List<int>() {
			ItemID.AppleJuice,
			ItemID.ApplePie,
			ItemID.BananaSplit,
			ItemID.BottledHoney,
			ItemID.CandyCorn,
			ItemID.ChocolateChipCookie,
			ItemID.ChristmasPudding,
			ItemID.CookedMarshmallow,
			ItemID.CreamSoda,
			ItemID.Eggnog,
			ItemID.FruitJuice,
			ItemID.GingerbreadCookie,
			ItemID.GrapeJuice,
			ItemID.IceCream,
			ItemID.JojaCola,
			ItemID.Lemonade,
			ItemID.Marshmallow,
			ItemID.Milkshake,
			ItemID.PrismaticPunch,
			ItemID.PumpkinPie,
			ItemID.SugarCookie
		});

		VanillaFoodByCategory.Add(FoodCategory.Alcohol, new List<int>() {
			ItemID.Ale,
			ItemID.BananaDaiquiri,
			ItemID.BloodyMoscato,
			ItemID.PeachSangria,
			ItemID.PinaColada,
			ItemID.Sake
		});

		VanillaFoodByCategory.Add(FoodCategory.Spice, new List<int>() {
			ItemID.Blinkroot,
			ItemID.Daybloom,
			ItemID.Deathweed,
			ItemID.Fireblossom,
			ItemID.Moonglow,
			ItemID.Shiverthorn,
			ItemID.SpicyPepper,
			ItemID.StarAnise,
			ItemID.Waterleaf
		});

		VanillaFoodByCategory.Add(FoodCategory.Other, new List<int>() {
			ItemID.CoffeeCup,
			ItemID.FriedEgg,
			ItemID.Fries,
			ItemID.MilkCarton,
			ItemID.Nachos,
			ItemID.Pizza,
			ItemID.PotatoChips,
			ItemID.Teacup
		});
	}

	public override void OnConsumeItem(Item item, Player player) {
		if (item.type > ItemID.None && item.type < ItemID.Count && ItemID.Sets.IsFood[item.type] == true) {
			var foodPlayer = player.GetModPlayer<CDFoodPlayer>();

			foreach (var values in VanillaFoodByCategory.Values) {
				if (values.Contains(item.type)) {
					// Clear already applied buffs 
					foodPlayer.FoodLevels = new int[7];
					foodPlayer.FoodTimers = new int[7];
					break;
				}
			}

			foreach (var (category, value) in VanillaFoodByCategory) {
				if (value.Contains(item.type)) {
					foodPlayer.FoodLevels[(int)category]++;
					foodPlayer.FoodTimers[(int)category] = VanillaFoodBuffTime;
					Main.NewText(foodPlayer.FoodLevels[(int)category]);
				}
			}
		}
	}
}