# Taller Conversión formatos 3D
Sebastián Andrade Cedano 

Entregado el: 11 Feb 2022

## Objetivo
El taller consiste en cargar archivos 3D en diferentes formatos, realizar conversiones entre estos con Python, y posteriormente cargar los modelos convertidos en una aplicación con React y Three.js

## Implementaciones
### Carga de modelos y conversión entre formatos con Python
Para poder cargar los archivos de los modelos se utilizó la librería "open3d", la cual permite cargar modelos en diferentes formatos de manera sencilla.

```
bunny = o3d.io.read_triangle_mesh("bunny.obj")
bear = o3d.io.read_triangle_mesh("bear.gltf")
teapot = o3d.io.read_triangle_mesh("teapot.stl")
```

Para poder comparar los vértices, caras, etc, se realizó una tabla comparativa utilizando un dataframe de Pandas
<img src="./media/table.png" alt="Sample Image" width="400"/>

Para poder visualizar los modelos dentro del notebook se definió una función que toma como parámetro el objeto mesh que retorna `o3d.io.read_triangle_mesh`.
```
def plotMesh(modelMesh):
  mesh = copy.deepcopy(modelMesh);
  # Compute normals
  mesh.compute_vertex_normals()
  mesh.compute_triangle_normals()

  # Turn into np array
  vertices = np.asarray(mesh.vertices)
  triangles = np.asarray(mesh.triangles)

  # plotly
  fig = go.Figure(data=[
      go.Mesh3d(
          x=vertices[:, 0],
          y=vertices[:, 1],
          z=vertices[:, 2],
          i=triangles[:, 0],
          j=triangles[:, 1],
          k=triangles[:, 2],
          color='lightblue',
          opacity=1.0
      )
  ],
  layout=dict(
          scene=dict(
              xaxis=dict(visible=False),
              yaxis=dict(visible=False),
              zaxis=dict(visible=False)
          )
      )

  )

  fig.show()
```
Por último, para realizar las conversiones se utilizó `pyassimp` de la siguiente manera.
```
# OBJ -> STL
with pyassimp.load("bunny.obj") as scene:
    pyassimp.export(scene, "bunny.stl", file_type="stl")

# GLTF -> OBJ
with pyassimp.load("bear.gltf") as scene:
    pyassimp.export(scene, "bear.obj", file_type="obj")

# STL -> GLTF
with pyassimp.load("teapot.stl") as scene:
    pyassimp.export(scene, "teapot.gltf", file_type="gltf2")
```

### Three.js con React Three fiber
Para poder realizar esta implementación se siguieron los siguientes pasos:
1. Iniciar proyecto de React.js con Vite
2. Instalar dependencias necesarias
3. Descargar los 3 modelos generados por Python
4. Crear un componente de React (por modelo) el cual cargue el modelo
5. Usar un dropdown que permita escoger el modelo a visualizar

#### Selector para cambiar entre modelos
![idk](./media/threejs.gif)

## Aprendizajes y dificultadoes
* El tamaño del modelo puede generar problemas al cargarlo.
