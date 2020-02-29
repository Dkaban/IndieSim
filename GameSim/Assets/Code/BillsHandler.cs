using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum BillType
{
    Rent,
    Medical,
    Internet,
    CellPhone,
    Groceries,
    Travel,
    Conventions
}

public class Bill
{
    public BillType TypeOfBill;
    public int Amount = 0;
    public Bill(BillType type, int amt)
    {
        TypeOfBill = type;
        Amount = amt;
    }
}

public class BillsHandler : MonoBehaviour
{
    public Dictionary<BillType,Bill> BillDictionary = new Dictionary<BillType, Bill>();

    [System.NonSerialized]
    public int BillTotal = 0;

    public void AddBill(BillType type, int amt)
    {
        if (BillDictionary.ContainsKey(type)) return; //If the bill already exists, we don't want to add it.
        BillDictionary.Add(type,new Bill(type,amt));
    }

    public void RemoveBill(BillType type)
    {
        if (!BillDictionary.ContainsKey(type)) return; //We want to kick out if we don't find a bill.

        BillDictionary.Remove(type);
    }

    public void CalculateBills()
    {
        BillTotal = BillDictionary.Sum(element => element.Value.Amount);
    }
}
