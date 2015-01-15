<?php
	$firstNum = $_POST ['firstNum'];
	$secondNum = $_POST ['secondNum'];
	$mathSymbol = $_POST ['symbol'];
	
	switch($mathSymbol){
		case '+': echo "Result : " . $firstNum . $mathSymbol . $secondNum . "=" . ($firstNum + $secondNum); break;
		case '-': echo "Result : " . $firstNum . $mathSymbol . $secondNum . "=" . ($firstNum - $secondNum); break;
		case '*': echo "Result : " . $firstNum . $mathSymbol . $secondNum . "=" . ($firstNum * $secondNum); break;
		case '/': echo "Result : " . $firstNum . $mathSymbol . $secondNum . "=" . ($firstNum / $secondNum); break;
	}
