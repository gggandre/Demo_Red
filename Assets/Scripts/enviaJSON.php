<?php
    $datos = new stdClass();
    $datos->nombre = "rMr";
    $datos->puntos = 255;
    
    $json = json_encode($datos);
    
    echo $json;
?>

