using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public ToplanabilirTipi tipi;
        public int sayý;
        public int slotSinir;

        public Slot()
        {
            tipi = ToplanabilirTipi.NONE;
            sayý = 0;
            slotSinir = 99;
        }
        public bool itemeklemekontrol()
        {
            if (sayý < slotSinir)
            {
                return true;
            }
            return false;
        }

        public void itemEkle(ToplanabilirTipi tipi)
        {
            this.tipi = tipi;
            sayý++;
        }
    }
    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(ToplanabilirTipi eklenecekTip)
    {
        foreach (Slot slot in slots)
        {
            if (slot.tipi == eklenecekTip && slot.itemeklemekontrol())
            {
                slot.itemEkle(eklenecekTip);
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.tipi == ToplanabilirTipi.NONE)
            {
                slot.itemEkle(eklenecekTip);
                return;
            }
        }
    }

}
