[System.Serializable]
public class SlotInventory
{
    public int amount = 0;
    public Item item;

    public SlotInventory(Item item, int amount =1) 
    { 
        this.item = item;
        this.amount = amount;
    }
}
