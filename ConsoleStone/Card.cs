namespace ConsoleStone
{
    public class Card
    {
        private Card(int damage)
        {
            Damage = damage;
        }

        public int Damage { get; }

        public static Card CreateInstance(int damage)
        {
            return new Card(damage);
        }
    }
}