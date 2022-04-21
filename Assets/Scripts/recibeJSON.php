<?php
    if ($_POST) {
        $datos = $_POST["datosJSON"];
        $datosJson = json_decode($datos, true);
        echo "JSON: " . strtoupper($datos) . "\n";
        $nombre = $datosJson["nombre"];
        $puntos = $datosJson["puntos"];
        echo "Nombre: " . strtoupper($nombre) . "\n";
        echo "Puntos: " . $puntos*10 . "\n";
        echo "FIN";
        
    } else {
        echo "No hay método POST";
    }
?>