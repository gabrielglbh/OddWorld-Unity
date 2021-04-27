# OddWorld

Proyecto Final de MDASDM para la asignatura de Videojuegos @ UPM hecho con Unity.

Un juego estilo Zelda con los sprites sacados de [OpenGameArt](https://opengameart.org/content/zelda-like-tilesets-and-sprites). El motivo principal del juego es aguantar lo máximo posible matando enemigos que aparecen constantmente y, si el jugador quiere, observar e interactuar con el pequeño mundo. Se lleva un sistema de puntuación en base a los enemigos matados y el tiempo transcurrido desde que el jugador comience a luchar.

Principales funciones a destacar:

- Se han creado las animaciones mediante Animator para el Player, Enemy y varios objetos. Se han creado las Transitions y Conditions con el Animator (con nodos) y los Blend Trees con sus Motions y Parámetros para los distintos estados del objeto y su determinación de movimiento.

- Se crea un Sprite Atlas para eliminar los errores de Unity al tratar los sprites como objetos 3D.

- Se ha creado un TileMap para crear el mapa: un mapa de colisiones (TileMap Collider 2D con Composite Collider) y un mapa de suelo por donde el jugador puede moverse.

- La cámara está limitada al TileMap de manera explícita en el código.

- Hay varias pantallas y la cámara se mueve entre ellas con transiciones al estilo Zelda.

- Se han creado HitBoxes para las 4 animaciones de ataque con Polygon Collider 2D. La hitbox se activa en la animación y puede empujar y dañar a los enemigos.

- Los enemigos y el jugador tienen Hurtbox con Collision Box 2D.

- Se han creado cuadros de dialogo con distintos elementos del juego (señales, estatuas, cadáveres) con los que interactuar.

- Los jarrones y las briznas de hierba se pueden romper.

- IA enemigos simple: Te persiguen si estás dentro de su rango. Animaciones añadidas.

- Se han usado ScriptableObjects para definir algunas variables globales de los actores del juego: vida del enemigo, vida del jugador, contador de enemigos y puntuación. La ventaja es que se puede cambiar la vida de todos los enemigos desde un solo sitio.

- El jugador tiene 3 vidas. El sistema de vida, daño de enemigos, spawn de enemigos, sistema de puntuación y el game over están hechos con Listeners, UnityEvents y ScriptableObjects.

- Hay un spawn de enemigos el cual el jugador debe aguantar lo máximo posible para conseguir la máxima puntuación.

- Creado menú de Game Over para volver a empezar desde donde se ha muerto o salir del juego.

- Añadidos NPC con los que interactuar con diálogo. Hay dos tipos: NPCs que se mueven por un camino predeterminado y NPC que simplemente se quedan en su sitio. Se interactúa con ellos automáticamente al pasar cerca.
