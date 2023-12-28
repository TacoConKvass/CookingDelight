/*
namespace CookingDelight.Common.Old;

[Obsolete("Old. Do not touch")]
public class GlobalFoodCategorizer : GlobalItem
{
	public static Dictionary<int, FoodInfo> vanillaFoodCategories;
	public override void Unload() {
		vanillaFoodCategories = null;
	}

	public GlobalFoodCategorizer() {
		vanillaFoodCategories = new Dictionary<int, FoodInfo>() {
			{
				ItemID.Ale,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Alcohol },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Apple,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.AppleJuice,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.ApplePie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit, FoodCategory.Sweet },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Apricot,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Bacon,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Banana,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.BananaDaiquiri,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Alcohol, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.BananaSplit,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit, FoodCategory.Sweet },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.BBQRibs,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.BlackCurrant,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.BloodOrange,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.BowlofSoup,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fish, FoodCategory.Soup },
					BuffDuration = 60.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Burger,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat, FoodCategory.Sandwich },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.BunnyStew,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat, FoodCategory.Soup },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Cherry,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.ChickenNugget,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.ChocolateChipCookie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.ChristmasPudding,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Coconut,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.CoffeeCup,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.CookedFish,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fish },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.CookedMarshmallow,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 15.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.CookedShrimp,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.CreamSoda,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},
			{
				ItemID.Dragonfruit,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Elderberry,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Escargot,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.FriedEgg,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Fries,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.FroggleBunwich,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood, FoodCategory.Sandwich },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.FruitJuice,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.FruitSalad,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit, FoodCategory.Salad },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.GingerbreadCookie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.GoldenDelight,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Grapefruit,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.GrapeJuice,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Grapes,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.GrilledSquirrel,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.GrubSoup,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat, FoodCategory.Soup },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Hotdog,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.IceCream,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.JojaCola,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Lemon,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Lemonade,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.LobsterTail,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Mango,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Marshmallow,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.MilkCarton,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Drink },
					BuffDuration = 20.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Milkshake,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.MonsterLasagna,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Nachos,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.PadThai,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Peach,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.PeachSangria,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Pho,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat, FoodCategory.Soup },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.PinaColada,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Pineapple,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Pizza,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Plum,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Pomegranate,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.PotatoChips,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.PrismaticPunch,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.PumpkinPie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Vegetable, FoodCategory.Sweet },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Rambutan,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.RoastedBird,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.RoastedDuck,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Sake,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Alcohol },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Sashimi,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fish },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.SauteedFrogLegs,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.ShrimpPoBoy,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.SmoothieofDarkness,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.ShuckedOyster,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Spaghetti,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.SpicyPepper,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Vegetable },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Starfruit,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Steak,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.SugarCookie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.Teacup,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},

			{
				ItemID.TropicalSmoothie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 30.Seconds(),
					BuffIntensity = 1.15f
				}
			},
		};
	}
}
*/