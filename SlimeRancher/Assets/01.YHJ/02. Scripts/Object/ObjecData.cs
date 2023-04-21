using UnityEngine;

public class ObjecData : MonoBehaviour
{
    [SerializeField] public ObjectType objectType = default;
    [SerializeField] public FoodType foodType = default;
    [SerializeField] public FoodName foodName = default;
}

public enum ObjectType
{
    none,
    Slime,
    Food
}

public enum FoodType
{
    none,
    Vegetable,
    Fruit,
    Meat
}

public enum FoodName
{
    none,
    Carrot,
    Heartbeet,
    OcaOca,
    OddOnion,
    SilverParsnip,
    GildedGinger,

    PogoFruit,
    Cuberry,
    MintMango,
    PhaseLemon,
    PricklePear,
    Kookadoba,

    Chickadoo,
    HenHen,
    Roostro,
    StonyChickadoo,
    StonyHen,
    BriarChickadoo,
    BriarHen,
    PaintedChickadoo,
    PaintedHen,
    ElderHen,
    ElderRoostro
}