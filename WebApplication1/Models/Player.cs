namespace WebApplication1.Models
{
    public class Player
    {
        private int _id;

        private string _name;


        public int Id 
        { 
            get => _id; 

            private set 
            { 
                _id = value; 
            } 
        }

        public string Name
        {
            get => _name;
            private set
            { 
                _name = value; 
            }
        }
    }
}
