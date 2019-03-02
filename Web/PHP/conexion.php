<?php

try{
	$db = new PDO("mysql:host=HOST_HERE;dbname=DBNAME_HERE", "USER_NAME_HERE", "PASS_HERE");
}catch(Exception $e){
	die ("Error Fatal: ".$e->getMessage());
}


?>