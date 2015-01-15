class Human
{
	enum Gender { Male, Female };

	class Person
	{
		public Gender Gender { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
	}
	
	public void CreatePerson(int personId)
	{
		Person newPerson = new Person();
		newPerson.Age = personId;
		
		if (personId % 2 == 0)
		{
			newPerson.Name = "Батката";
			newPerson.Gender = Gender.Male;
		}
		else
		{
			newPerson.Name = "Мацето";
			newPerson.Gender = Gender.Female;
		}
	}
}
