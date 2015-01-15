/*================== Statement 1 =======================*/

Potato potato;
//... 
if (potato != null)
{
    if(potato.HasBeenPeeled && !potato.IsRotten)
    {
	   Cook(potato); 
    }
}
   

/*================== Statement 2 =======================*/
    
bool inYRestrictions = MAX_Y >= y && MIN_Y <= y;
bool inXRestrictions = x >= MIN_X && x =< MAX_X;

if (inXRestrictions && inYRestrictions && shouldVisitCell)
{
   VisitCell();
}
