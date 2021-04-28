# OddWorld

Proyecto Final de MDASDM para la asignatura de Videojuegos @ UPM hecho con Unity.

Un juego estilo Zelda con los sprites sacados de [OpenGameArt](https://opengameart.org/content/zelda-like-tilesets-and-sprites). El motivo principal del juego es aguantar lo máximo posible matando enemigos que aparecen constantmente y, si el jugador quiere, observar e interactuar con el pequeño mundo. Se lleva un sistema de puntuación en base a los enemigos matados y el tiempo transcurrido desde que el jugador comience a luchar.

## Funciones a Destacar

- Se han creado botones táctiles (DPad [Creating a Virtual Joystick por Epitome](https://www.youtube.com/watch?v=2GQe1cvHx9U) y botones normales) para manejar el juego desde dispositivo iOS y Android.

- Se han creado las animaciones mediante Animator para el Player, Enemy y varios objetos. Se han creado las Transitions y Conditions con el Animator (con nodos) y los Blend Trees con sus Motions y Parámetros para los distintos estados del objeto y su determinación de movimiento.

- Se ha creado un Sprite Atlas para eliminar los errores de Unity al tratar los sprites como objetos 3D.

- Se ha creado un TileMap para crear el mapa: un mapa de colisiones (TileMap Collider 2D con Composite Collider) y un mapa de suelo por donde el jugador puede moverse.

- La cámara está limitada al TileMap en el que el jugador esté de manera explícita en el código.

- Hay 4 TileMaps distintos: uno por cada 'habitación'. La cámara se mueve entre ellas con transiciones al estilo The Legend of Zelda: A Link to the Past.

- Se han creado HitBoxes para las 4 animaciones de ataque con Polygon Collider 2D. La hitbox se activa en la animación y puede empujar y dañar a los enemigos.

- Los enemigos y el jugador tienen Hurtbox con Collision Box 2D, de tal manera que el jugador pueda dañar al enemigo y el enemigo al jugador.

- Se han creado cuadros de dialogo con distintos elementos del juego (señales, estatuas, cadáveres, NPCs) con los que interactuar en el mundo.

- Los jarrones y las briznas de hierba se pueden romper. Tienen 1 posibilidad entre 3 de albergar un corazón para que el jugador recupere la vida. Siempre se recupera vida con un corazón completo.

- IA enemigos simple: Te persiguen si estás dentro de su rango. Animaciones añadidas.

- Se han usado ScriptableObjects para definir algunas variables globales (estáticas) de los actores del juego: vida del enemigo y jugador, contador de enemigos, puntuación, dirección del movimiento del jugador. La ventaja de estos ScriptableObjects es que se puede cambiar el valor de estas variables desde un solo sitio y su valor se preserva a lo largo de todo el runtime del juego y se comparte por clases.

- El sistema de vida, daño de enemigos, acción de botones en UI, spawn de enemigos, sistema de puntuación y el game over están hechos con Listeners, UnityEvents y ScriptableObjects. Básicamente, hay objetos que están observando (Listeners) a ciertos eventos personalizados (Event ScriptableObjects) y cuando cierto objeto notifica el evento, los objetos que estaban observándolo, ejecutan un código cualquiera (UnityEvent).

- Se ha creado un spawn de enemigos (el castillo/la Prueba) el cual el jugador debe aguantar lo máximo posible para conseguir la máxima puntuación, siempre pudiendo salir de esa 'habitación' cuando se quiera.

- Se han creado menús de Start Game, de Pause y de Game Over para volver a empezar desde donde se ha muerto o salir del juego en el que se muestra la puntuación total.

- Se han añadido NPCs con los que interactuar con diálogos. Hay dos tipos: NPCs que se mueven por un camino predeterminado y NPC que simplemente se quedan en su sitio. Se interactúa con ellos automáticamente al pasar cerca.

- Se han añadido sonidos: ataque, game over, menú de inicio, canción del mundo y canción de batalla. Se puede silenciar el audio en la pantalla de inicio.

## TODOs

- Parar NPCs con Path predefinido cuando el Player entra en su rango

- Sprites personalizados con Piskel para los NPCs

- Añadir escena de la casa por dentro

- Añadir icono de App
