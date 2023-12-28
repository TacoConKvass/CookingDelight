using CookingDelight.Common;

namespace CookingDelight.Common;

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
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Apple,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.AppleJuice,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.ApplePie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit, FoodCategory.Sweet },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.Apricot,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.Bacon,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.Banana,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.BananaDaiquiri,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Alcohol, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.BananaSplit,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit, FoodCategory.Sweet },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.BBQRibs,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.BlackCurrant,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.BloodOrange,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.BowlofSoup,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fish, FoodCategory.Soup },
					BuffDuration = 60.Seconds()
				}
			},

			{
				ItemID.Burger,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat, FoodCategory.Sandwich },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.BunnyStew,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat, FoodCategory.Soup },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Cherry,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.ChickenNugget,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.ChocolateChipCookie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.ChristmasPudding,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Coconut,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.CoffeeCup,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.CookedFish,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fish },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.CookedMarshmallow,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 15.Seconds()
				}
			},

			{
				ItemID.CookedShrimp,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.CreamSoda,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},
			{
				ItemID.Dragonfruit,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Elderberry,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Escargot,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.FriedEgg,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Fries,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.FroggleBunwich,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood, FoodCategory.Sandwich },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.FruitJuice,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.FruitSalad,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit, FoodCategory.Salad },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.GingerbreadCookie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.GoldenDelight,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Grapefruit,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.GrapeJuice,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Grapes,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.GrilledSquirrel,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.GrubSoup,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat, FoodCategory.Soup },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Hotdog,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.IceCream,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.JojaCola,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Lemon,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Lemonade,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.LobsterTail,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Mango,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Marshmallow,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.MilkCarton,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Drink },
					BuffDuration = 20.Seconds()
				}
			},

			{
				ItemID.Milkshake,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.MonsterLasagna,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Nachos,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.PadThai,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Peach,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.PeachSangria,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Pho,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat, FoodCategory.Soup },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.PinaColada,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Pineapple,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Pizza,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Plum,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Pomegranate,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.PotatoChips,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.PrismaticPunch,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.PumpkinPie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Vegetable, FoodCategory.Sweet },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Rambutan,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.RoastedBird,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.RoastedDuck,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Sake,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Alcohol },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Sashimi,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fish },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.SauteedFrogLegs,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.ShrimpPoBoy,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Other },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.SmoothieofDarkness,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.ShuckedOyster,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Seafood },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Spaghetti,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.SpicyPepper,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Vegetable },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Starfruit,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Steak,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Meat },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.SugarCookie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Sweet },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.Teacup,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},

			{
				ItemID.TropicalSmoothie,
				new FoodInfo() {
					Categories = new List<FoodCategory> { FoodCategory.Fruit, FoodCategory.Drink },
					BuffDuration = 30.Seconds()
				}
			},
		};
	}
}