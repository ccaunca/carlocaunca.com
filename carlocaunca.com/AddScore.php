﻿<?php
        // Configuration
        $hostname = 'FallDown.db.6186410.hostedresource.com';
        $username = 'FallDown';
        $password = 'F@llD0wnDem0';
        $database = 'FallDown';
 
        $secretKey = "F@llD0wnDem0Key"; // Change this value to match the value stored in the client javascript below 
        
        $insertStatement = 'INSERT INTO HighScores VALUES (null, :score, :name, date("Y-m-d H:i:s"))';
 
        try {
            $dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, $username, $password);
        } catch(PDOException $e) {
            echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
        }
 
        $realHash = md5($_GET['name'] . $_GET['score'] . $secretKey); 
        if($realHash == $hash) { 
            $sth = $dbh->prepare($insertStatement);
            try {
                $sth->execute($_GET);
            } catch(Exception $e) {
                echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
            }
        } 
?>