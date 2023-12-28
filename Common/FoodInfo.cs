namespace CookingDelight.Common;

public enum FoodCategory
{
	Meat,		//Effect: 
	Vegetable,	//Effect: Temporary max HP
	Fruit,		//Effect: Life regen
	Sweet,		//Effect: Speed
	Fish,		//Effect: Damage
	Soup,		//Effect: 
	Drink,		//Effect: 
	Sandwich,	//Effect: 
	Salad,		//Effect: 
	Seafood,	//Effect: 
	Alcohol,	//Effect: 
	Other		//Custom effects
}

public class FoodInfo
{
	public List<FoodCategory> Categories { get; set; }
	public int BuffDuration { get; set; }
}