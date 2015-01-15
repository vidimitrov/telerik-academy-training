<html>
	<head>
		<title>Calculator form</title>
		<script>
			function validateForm()
			{
				var x=document.forms["calculatorForm"]["firstNum"].value;
				if (x==null || x=="")//!x	
				{
					alert("First number must be filled out");
					return false;
				}
				var x=document.forms["calculatorForm"]["symbol"].value;
				if (x==null || x=="")
				{
					alert("A mathematical symbol must be filled out");
					return false;
				}
				var x=document.forms["calculatorForm"]["secondNum"].value;
				if (x==null || x=="")
				{
					alert("Second number must be filled out");
					return false;
				}
				
			}
		</script>
	</head>
	<body>
		<form action="Calculate.php" method="POST" name="calculatorForm" onsubmit="return validateForm()" >
			<label>First number:</label>
			<input type="text" name="firstNum"/></br>
			<label>Mathematical symbol:</label>
			<input type="text" name="symbol"/></br>
			<label>Second number:</label>
			<input type="text" name="secondNum"/></br>
			
			<input type="submit"/>
		</form>
	</body>
</html>