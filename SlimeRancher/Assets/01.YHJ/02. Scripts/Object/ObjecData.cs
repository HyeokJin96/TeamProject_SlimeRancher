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
    Food,
    Button
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

    PogoFruit,
    Cuberry,

    Chickadoo,
    HenHen,
    Roostro,
}