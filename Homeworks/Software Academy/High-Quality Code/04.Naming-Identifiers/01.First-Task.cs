class SampleClass{
	const int maxCount = 6;

	class SampleNestedClass{
		void WriteLineBooleanAsString(bool input)   {
			string inputAsString = input.ToString();
			Console.WriteLine(inputAsString);   
		}
	}    
	public static void Main(){
		SampleClass.SampleNestedClass instance = new SampleClass.SampleNestedClass();
		instance.WriteLineBooleanAsString(true); 
	}
}