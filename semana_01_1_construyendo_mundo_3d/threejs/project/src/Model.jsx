import { useGLTF } from "@react-three/drei";

function Model() {
  const { scene } = useGLTF("/models/scene.gltf");

  scene.traverse((child) => {
    if (child.isMesh) { // If this thing is renderable
      child.material.wireframe = true; // Set to false for rendering the textures, true to render only the borders and see the triangles themselves
    }
  });

  return <primitive object={scene} />;
}

export default Model; 