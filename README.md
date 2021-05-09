![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/Resources/Icon/iOS/120.png?raw=true)

# OddWorld

Proyecto Final de MDASDM para la asignatura de Videojuegos @ UPM hecho con Unity.

Un juego estilo Zelda con los sprites sacados de [OpenGameArt](https://opengameart.org/content/zelda-like-tilesets-and-sprites). El motivo principal del juego es aguantar lo máximo posible matando enemigos que aparecen constantmente y, si el jugador quiere, observar e interactuar con el pequeño mundo. Se lleva un sistema de puntuación en base a los enemigos matados y el tiempo transcurrido desde que el jugador comience a luchar.

## A Destacar: Desarrollo

### Lanzamiento a Google Play y App Store

- Se ha lanzado el juego a Google Play y a la App Store. Para Google Play se ha creado una nueva keystore para firmar la aplicación mediante el gestor de Unity. Para App Store se han usado los certificados del desarrollador previamente creados.

### UI y Sonidos

- Se han creado botones táctiles (DPad [Creating a Virtual Joystick por Epitome](https://www.youtube.com/watch?v=2GQe1cvHx9U) y botones normales) para manejar el juego desde dispositivo iOS y Android.

- Se ha añadido una fuente para texto customizada de 8 bits extraída de [FontSpace](https://www.fontspace.com/press-start-2p-font-f11591) para mostrar en todo el juego: diálogos, menús e información.

- Se han creado menús de Start Game y de Game Over para volver a empezar desde donde se ha muerto o salir del juego en el que se muestra la puntuación total.

![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/menu.png?raw=true)

- Se han añadido sonidos: ataque, menú de inicio, canción del mundo, canción de batalla y canción secreta (las canciones sin copyright se han descargado de [FesliyanStudios](https://www.fesliyanstudios.com/es/royalty-free-music/downloads-c/8-bit-music/6)). Se puede silenciar el audio en cualquier momento.

- Se han añadido el icono de la app para Android e iOS. El icono ha sido extraído de un asset del juego.

### Animaciones

- Se han creado las animaciones mediante Animator para el jugador, los enemigos y varios objetos del mundo. Se han creado las Transitions y Conditions con el Animator (con nodos) y los Blend Trees con sus Motions y Parámetros para los distintos estados del objeto y su determinación de movimiento mediante script.

### Mundo con TileMaps

- Se ha creado un Sprite Atlas para eliminar los errores de Unity al tratar los sprites como objetos 3D (esto elimina una delgada línea negra entre sprites cuando se corre el juego).

- Se han creado varios TileMaps para crear el mapa. Cada uno de ellos consta de un mapa de colisiones (TileMap Collider 2D con Composite Collider), un mapa de suelo por donde el jugador puede moverse y un mapa de decoraciones.

### Hitboxes y Vida

- Se han creado HitBoxes para las 4 animaciones de ataque con Polygon Collider 2D. La hitbox se activa en la animación. Empuja y daña a los enemigos.

- Los enemigos y el jugador tienen Hurtbox (Collision Box 2D), de tal manera que el enemigo pueda dañar al jugador, evento que se observa mediante OnTriggerEnter2D.

- El jugador tiene 5 corazones y cada enemigo tiene 3 corazones. El ataque del jugador quita 1 corazón entero al enemigo y un enemigo quita medio corazón al jugador cada vez que le ataca.

### Diálogos

- Se han creado cuadros de dialogo con distintos elementos del juego (señales, estatuas, NPCs) con los que interactuar en el mundo. Estos cuadros se pueden activar automáticamente o pulsando la A.

### IA

- IA enemigos simple: Te persiguen si estás dentro de su rango.

### Eventos y Observadores con ScriptableObjects

- Se han usado ScriptableObjects para definir algunas variables globales (estáticas) de los actores del juego: vida del enemigo y jugador, contador de enemigos, puntuación, dirección del movimiento del jugador. La ventaja de estos ScriptableObjects es que se puede cambiar el valor de estas variables desde un solo sitio y su valor se preserva a lo largo de todo el runtime del juego y se comparte por clases.

- El sistema de vida, daño de enemigos, acción de botones en UI, spawn de enemigos, sistema de puntuación y el game over están hechos con Listeners, UnityEvents y ScriptableObjects. Básicamente, hay objetos que están observando (Listeners) a ciertos eventos personalizados (Event ScriptableObjects) y cuando cierto objeto notifica el evento, los objetos que estaban observándolo, ejecutan un código cualquiera (UnityEvent).

## A Destacar: Vistas y Jugabilidad

### Mapa

- Hay 5 TileMaps distintos: cuatro (uno por cada 'habitación' del Overworld) y una 'habitación' secreta. La cámara se mueve entre ellas con transiciones al estilo The Legend of Zelda: A Link to the Past y está limitada al TileMap en el que el jugador esté de manera explícita en el código.

![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/map.png?raw=true)

### Objetos Rompibles

- Los jarrones y las briznas de hierba se pueden romper. Tienen 1 posibilidad entre 3 de albergar un corazón para que el jugador recupere la vida. Siempre se recupera vida con un corazón completo.

![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/pot.png?raw=true)
![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/potWithHeart.png?raw=true)

### La Prueba

- Se ha creado un spawn de enemigos en el cual el jugador debe aguantar lo máximo posible para conseguir la máxima puntuación, siempre pudiendo salir de esa 'habitación' cuando se quiera. Los enemigos hacen spawn aleatoriamente en una de las cuatro esquinas de esta 'habitación' hasta que haya un máximo de 12 en la estancia. El proceso de spawn se realiza infinitamente mientras el número de enemigos sea menor que 12 hasta que el jugador muere en la prueba o simplemente se vaya.

![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/trial.png?raw=true)

### Non-Playable Characters (NPCs)

- Se han añadido NPCs con los que interactuar con diálogos. Hay dos tipos: NPCs que se mueven por un camino predeterminado y paran cuando te ven; y NPC que simplemente se quedan en su sitio. Se interactúa con ellos automáticamente al pasar cerca. Todos los NPC al hablar con ellos te miran y cuando te vas, vuelven a su estado normal.

![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/dialog.png?raw=true)

- Se han añadido Custom Sprites para todos los NPC que hemos personalizado con la temática de nuestros amigos de la carrera. Estos sprites se han realizado con [Piskel](https://www.piskelapp.com/)

![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/fer.png?raw=true)
![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/gabo.png?raw=true)
![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/guille.png?raw=true)
![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/isma.png?raw=true)
![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/sergio.png?raw=true)
![](https://github.com/gabrielglbh/OddWorld-Unity/blob/main/Assets/PreviewImages/toni.png?raw=true)
