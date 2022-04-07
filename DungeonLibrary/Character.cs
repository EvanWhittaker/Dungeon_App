namespace DungeonLibrary
{
    //The "abstract" modifier denotes this datatype class 
    //is "incomplete" -- we don't intend to make any Character
    //objects. Instead, we'll use Character as a base class 
    //for more specific types (Player & Monster).
    public abstract class Character
    {
        //FIELDS
        private int _life;
        private string _name;
        private int _hitChance;
        private int _block;
        private int _maxLife;

        //PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    //If trying to set a life value less than or equal
                    //to max life, that's fine.
                    _life = value;
                }
                else
                {
                    //Otherwise, if trying to set life higher than 
                    //max life, set it to their max life value instead.
                    _life = MaxLife;
                }
            }
        }

        //CONSTRUCTORS
        public Character(string name, int hitChance, int block, int maxLife, int life)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = life;
        }

        public Character() { }

        //METHODS
        public override string ToString()
        {
            return string.Format("----- {0}--------\n" +
                "Life: {1} of {2}\nHit Chance: {3}%\n" +
                "Block: {4}",
                Name,
                Life,
                MaxLife,
                HitChance,
                Block);
        }

        //The "virtual" keyword is needed for methods
        //we intend to override in child classes.
        public virtual int CalcBlock()
        {
            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
        }
    }
}