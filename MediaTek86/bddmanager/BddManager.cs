namespace MediaTek86.bddmanager
{
    // Accès à la base de données MySQL (singleton)
    public class BddManager
    {
        private static BddManager instance = null;

        private BddManager(string stringConnect)
        {
        }

        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }
            return instance;
        }
    }
}
