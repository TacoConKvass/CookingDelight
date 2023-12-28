namespace CookingDelight.Common.Old;

public enum FoodCategory
{
	Alcohol,    //Effect: -Defense. -speed, +damage OR funny shader effect / screenshake, +damage
	Drink,      //Effect: Shorten duration, effect++
	Fish,       //Effect: Attack speed
	Fruit,      //Effect: Life regen
	Meat,       //Effect: Damage
	Salad,      //Effect: Add a random effect
	Sandwich,   //Effect: effect+
	Seafood,    //Effect: Water breathing / Extended breath
	Soup,       //Effect: Lengthen the effect
	Sweet,      //Effect: Speed
	Vegetable,  //Effect: Temporary max HP
	Other       //Custom effects
}

[Obsolete("Old. Do not touch")]
public class FoodInfo
{
	public List<FoodCategory> Categories { get; set; }
	public int BuffDuration { get; set; }
	public float BuffIntensity { get; set; }
}