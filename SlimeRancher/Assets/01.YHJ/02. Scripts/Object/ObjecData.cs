using UnityEngine;

public class ObjecData : MonoBehaviour
{
    [SerializeField] public ObjectType objectType = default;
    [SerializeField] public ButtonType buttonType = default;
    [SerializeField] public FoodType foodType = default;
    [SerializeField] public FoodName foodName = default;

    //[HT] add Var
    public Sprite foodIcon = default;
}

public enum ObjectType
{
    none,
    Slime,
    Food,
    Button
}

public enum ButtonType
{
    none,
    UpgradeStation,
    Facility_1,
    Facility_2,
    Facility_3,
    Facility_4,
    Facility_5,
    Facility_6,
    Facility_7,
    Facility_8,
    test



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

