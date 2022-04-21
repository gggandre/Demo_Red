<?php
    if ($_POST) {
        $nombre = $_POST["nombre"];
        $puntos = $_POST["puntos"];
        echo "Nombre: " . strtoupper($nombre) . "\n";
        echo "Puntos: " . $puntos*10 . "\n";

        
    } else {
        echo "No hay método POST";
    }
?>