using System.Collections.Generic;
using UnityEngine;

public enum BillType
{
    Rent,
    Medical,
    Internet,
    CellPhone,
    Groceries
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
    public List<Bill> BillList = new List<Bill>();

    public void AddBill(BillType type, int amt)
    {
        BillList.Add(new Bill(type,amt));
    }

    public void RemoveBill()
    {

    }
}
