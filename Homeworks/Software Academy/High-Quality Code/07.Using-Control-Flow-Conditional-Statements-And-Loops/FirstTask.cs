public class Chef
{
    private Potato GetPotato()
    {
        //...
    }
    
    private Carrot GetCarrot()
    {
        //...
    }
    
    private Bowl GetBowl()
    {   
        //... 
    }
    
    private void Cut(Vegetable potato)
    {
        //...
    }
    
    public void Cook()
    {
        Potato potato = GetPotato();
        Carrot carrot = GetCarrot();
        
        Peel(potato);        
        Peel(carrot);
        Cut(potato);
        Cut(carrot);
        
        Bowl bowl = GetBowl();
        bowl.Add(carrot);
        bowl.Add(potato);
    }
    
}