namespace SimpleGame
{
    public class Character
    {
        public string Name { get; set; } = "Hero";
        public int Level { get; set; } = 1;
        public Inventory Inventory { get; set; } = new Inventory();
        public Equipment Equipment { get; set; } = new Equipment();

        public int CalculateTotalDamage()
        {
            int baseDamage = 10 + (Level * 2);
            int weaponDamage = Equipment.Weapon?.Damage ?? 0;
            return baseDamage + weaponDamage;
        }

        public void ViewCharacterStats()
        {
            Console.WriteLine($"=== {Name} ===");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Damage: {CalculateTotalDamage()}");
            Console.WriteLine($"Inventory: {Inventory.UsedSlots}/{Inventory.Capacity}");
        }

    }
}
