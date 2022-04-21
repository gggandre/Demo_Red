<?php

try{
	$pdo = new PDO ('mysql:host=btnam0nanjfwlzeupw2w-mysql.services.clever-cloud.com;dbname=btnam0nanjfwlzeupw2w', 'ulci3442prwdcqzr', 'vyfQsQZXvkLwqNoxkwo0');
	$pdo->setAttribute (PDO::ATTR_ERRMODE , PDO::ERRMODE_EXCEPTION);
	$pdo->exec('SET NAMES "utf8"');
}
catch (PDOException $e){
	echo "ERROR CONECTING TO DATABASE " . $e->getMessage();
	exit();
}
?>
