<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitylogintpredes";

$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error){
	die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT username FROM usuario WHERE username = '" . $loginUser . "'";

$result = $conn->query($sql);

if($result->num_rows > 0){
	
	echo "Username is already taken.";

}
else{
	
	echo "Creating user...";
	$sql2 = "INSERT INTO usuario(username, password) VALUES ('" . $loginUser . "', '" . $loginPass. "')";
	if($conn->query($sql2) === TRUE){
		echo "New user successfully created";
	}
	else{
		echo "Error: " . $sql2 . "<br>" . $conn->error;
	}
}
$conn->close();

?>